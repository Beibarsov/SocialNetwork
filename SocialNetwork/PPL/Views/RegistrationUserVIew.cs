using SocialNetwork.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SocialNetwork.BLL.Services;

namespace SocialNetwork.PPL.Views
{


    public class RegistrationUserVIew
    {

        UserService userService;

        public RegistrationUserVIew()
        {
            userService = new UserService();
        }

        public void Show()
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
