using SocialNetwork.BLL.Models;
using SocialNetwork.BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.PPL.Views
{
    public class UserMenuView
    {
        UserService userService;
        MessageService messageService;

        public UserMenuView()
        {
            userService = new UserService();
            messageService = new MessageService();
        }

        public void Show(User user)
        {

            while (true)
            {
                Console.WriteLine("Просмотреть информацию о моём профиле (нажмите 1)");
                Console.WriteLine("Редактировать мой профиль (нажмите 2)");
                Console.WriteLine("Добавить в друзья (нажмите 3)");
                Console.WriteLine("Написать сообщение (нажмите 4)");
                Console.WriteLine("Прочитать входящие сообщения (нажмите 5)");
                Console.WriteLine("Прочитать исходящие сообщения (нажмите 6)");
                Console.WriteLine("Выйти из профиля (нажмите 0)");

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
    }
}
