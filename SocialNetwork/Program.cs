using SocialNetwork.BLL.Exceptions;
using SocialNetwork.BLL.Models;
using SocialNetwork.BLL.Services;
using SocialNetwork.PPL.Views;

namespace SocialNetwork
{
    class Program
    {
        public static UserService userService = new UserService();
        public static MessageService messageService = new MessageService();


        public static MainView MainView;
        public static AuthOnProfileView AuthOnProfileView;
        public static RegistrationUserVIew RegistrationUserVIew;
        public static UserMenuView UserMenuView;

        static void Main(string[] args)
        {
            MainView = new MainView();
            AuthOnProfileView = new AuthOnProfileView();
            RegistrationUserVIew = new RegistrationUserVIew();
            UserMenuView = new UserMenuView();

            while (true)
            {
                MainView.Show();
            }

            Console.WriteLine("Добро пожаловать в социальную сеть");
            while (true)
            {
                Console.WriteLine("Введите 1 чтобы зайти в профиль");
                Console.WriteLine("Введите 2 чтобы начать регистрацию");




            }

        }

    }




}



