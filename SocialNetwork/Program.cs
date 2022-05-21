using SocialNetwork.BLL.Exceptions;
using SocialNetwork.BLL.Models;
using SocialNetwork.BLL.Services;
namespace SocialNetwork
{
    class Program
    {
        public static UserService userService = new UserService();
        public static MessageService messageService = new MessageService();

        static void Main(string[] args)
        {
            Console.WriteLine("Добро пожаловать в социальную сеть");
            while (true)
            {
                Console.WriteLine("Введите 1 чтобы зайти в профиль");
                Console.WriteLine("Введите 2 чтобы начать регистрацию");

                switch (Console.ReadLine())
                {
                    case "1":
                        {
                            var autenticationData = new UserAuthenticationData();

                            Console.WriteLine("Процедура авторизации");
                            Console.WriteLine("Введите почту:");
                            autenticationData.Email = Console.ReadLine();
                            Console.WriteLine("Введите пароль:");
                            autenticationData.Password = Console.ReadLine();

                            try
                            {
                                User user = userService.Authenticate(autenticationData);

                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("Вы успешно вошли в социальную сеть! Добро пожаловать {0}", user.FirstName);
                                Console.ForegroundColor = ConsoleColor.White;

                                while (true)
                                {
                                    Console.WriteLine("Просмотреть информацию о моём профиле (нажмите 1)");
                                    Console.WriteLine("Редактировать мой профиль (нажмите 2)");
                                    Console.WriteLine("Добавить в друзья (нажмите 3)");
                                    Console.WriteLine("Написать сообщение (нажмите 4)");
                                    Console.WriteLine("Прочитать входящие сообщения (нажмите 5)");
                                    Console.WriteLine("Прочитать исходящие сообщения (нажмите 6)");
                                    Console.WriteLine("Выйти из профиля и завершить выполнение программы (нажмите 0)");

                                    switch (Console.ReadLine())
                                    {
                                        case "1":
                                            {
                                                Console.ForegroundColor = ConsoleColor.Green;
                                                Console.WriteLine("Информация о моем профиле");
                                                Console.WriteLine("Мой идентификатор: {0}", user.Id);
                                                Console.WriteLine("Меня зовут: {0}", user.FirstName);
                                                Console.WriteLine("Моя фамилия: {0}", user.LastName);
                                                Console.WriteLine("Мой пароль: {0}", user.Password);
                                                Console.WriteLine("Мой почтовый адрес: {0}", user.Email);
                                                Console.WriteLine("Ссылка на моё фото: {0}", user.Photo);
                                                Console.WriteLine("Мой любимый фильм: {0}", user.FavoriteMovie);
                                                Console.WriteLine("Моя любимая книга: {0}", user.FavoriteBook);
                                                Console.ForegroundColor = ConsoleColor.White;
                                                break;
                                            }
                                        case "2":
                                            {
                                                Console.Write("Меня зовут:");
                                                user.FirstName = Console.ReadLine();

                                                Console.Write("Моя фамилия:");
                                                user.LastName = Console.ReadLine();

                                                Console.Write("Ссылка на моё фото:");
                                                user.Photo = Console.ReadLine();

                                                Console.Write("Мой любимый фильм:");
                                                user.FavoriteMovie = Console.ReadLine();

                                                Console.Write("Моя любимая книга:");
                                                user.FavoriteBook = Console.ReadLine();

                                                userService.Update(user);

                                                Console.ForegroundColor = ConsoleColor.Green;
                                                Console.WriteLine("Ваш профиль успешно обновлён!");
                                                Console.ForegroundColor = ConsoleColor.White;

                                                break;
                                            }
                                        case "4":
                                            {
                                                MessageSendingData message = new MessageSendingData();

                                                message.SenderID = user.Id;
                                                Console.WriteLine("Напишите текст сообщения:");
                                                message.Content = Console.ReadLine();
                                                Console.WriteLine("Кому мы его отправляем? Укажите почту:");
                                                message.RecepientEmail = Console.ReadLine();

                                                try
                                                {
                                                    messageService.CreateMessage(message);
                                                    Console.WriteLine("Сообщение создано");
                                                }
                                                catch (Exception ex)
                                                {
                                                    Console.WriteLine(message.SenderID);
                                                    Console.WriteLine(message.Content);
                                                    Console.WriteLine(message.RecepientEmail);
                                                    Console.WriteLine("Какая-то ошибка" + ex.Message);
                                                }


                                                break;
                                            }
                                        case "5":
                                            {
                                                foreach (var message in messageService.GetIncomingMessagesByUserID(user.Id))
                                                {
                                                    Console.WriteLine("Вам писал: " + message.SenderEmail);
                                                    Console.WriteLine("Текст письма: " + message.Content);
                                                }
                                                break;
                                            }
                                        case "6":
                                            {
                                                foreach (var message in messageService.GetOutGoingMessagesByUserID(user.Id))
                                                {
                                                    Console.WriteLine("Вы писали: " + message.RecepientEmail);
                                                    Console.WriteLine("Текст письма: " + message.Content);
                                                }
                                                break;
                                            }
                                        case "0":
                                            {
                                                return;
                                            }
                                    }
                                }

                            }
                            catch (WrongPasswordException)
                            {
                                Console.WriteLine("Пароль введен с ошибкой");
                            }
                            catch (UserNotFoundException)
                            {
                                Console.WriteLine("Пользователя с такой почтой не существует");
                            }


                            break;

                        }
                    case "2":
                        {
                            Console.WriteLine("Для регистрации пользователя введите имя:");
                            string firsName = Console.ReadLine();
                            Console.WriteLine("Для регистрации пользователя введите фамилию:");
                            string lastName = Console.ReadLine();
                            Console.WriteLine("Для регистрации пользователя введите пароль:");
                            string password = Console.ReadLine();
                            Console.WriteLine("Для регистрации пользователя введите почту:");
                            string email = Console.ReadLine();


                            UserRegistrationDate userRegistrationDate = new UserRegistrationDate()
                            {
                                FirstName = firsName,
                                LastName = lastName,
                                Password = password,
                                Email = email
                            };

                            try
                            {
                                userService.Register(userRegistrationDate);
                                Console.WriteLine("Регистрация успешно совершена");
                            }
                            catch (ArgumentNullException ex)
                            {
                                Console.WriteLine("Введите корректное значение ");
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("Произошла ошибка при регистрации");
                            }
                            break;
                        }
                }


            }

        }

    }




}



