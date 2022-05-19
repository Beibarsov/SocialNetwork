using SocialNetwork.BLL.Models;
using SocialNetwork.BLL.Services;
namespace SocialNetwork
{
    class Program
    {
        public static UserService userService = new UserService();

        static void Main(string[] args)
        {
            Console.WriteLine("Добро пожаловать в социальную сеть");
            while (true)
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
            }
            
        }

    }




}



