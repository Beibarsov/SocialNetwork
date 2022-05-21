using SocialNetwork.BLL.Exceptions;
using SocialNetwork.BLL.Models;
using SocialNetwork.BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SocialNetwork.PPL.Helpers;

namespace SocialNetwork.PPL.Views
{
    public class AuthOnProfileView 
    {

        UserService userService;

        public AuthOnProfileView()
        {
            userService = new UserService();
        }

        public void Show()
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

                ImportantMessageHelper.SuccessMessageWriteLine($"Вы успешно вошли в социальную сеть! Добро пожаловать {user.FirstName}");
                Program.UserMenuView.Show(user);
            }





            catch (WrongPasswordException)
            {
                Console.WriteLine("Пароль введен с ошибкой");
            }
            catch (UserNotFoundException)
            {
                Console.WriteLine("Пользователя с такой почтой не существует");
            }




        }
    }
}

