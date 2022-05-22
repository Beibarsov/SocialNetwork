using SocialNetwork.BLL.Exceptions;
using SocialNetwork.BLL.Models;
using SocialNetwork.BLL.Services;
using SocialNetwork.PPL.Views;

namespace SocialNetwork
{
    class Program
    {
        public static UserService userService;
        public static MessageService messageService;


        public static MainView MainView;
        public static AuthOnProfileView AuthOnProfileView;
        public static RegistrationUserVIew RegistrationUserVIew;
        public static UserMenuView UserMenuView;
        public static UserProfileDetailInfoView UserProfileDetailInfoView;
        public static UserProfileDetailEditView UserProfileDetailEditView;
        public static SendMessageView SendMessageView;
        public static UserShowIncomingMessagesView UserShowIncomingMessagesView;
        public static UserShowOutgoingMessagesView UserShowOutgoingMessagesView;

        static void Main(string[] args)
        {
            userService = new UserService();
            messageService = new MessageService();

            MainView = new MainView();
            AuthOnProfileView = new AuthOnProfileView(userService);
            RegistrationUserVIew = new RegistrationUserVIew(userService);
            UserMenuView = new UserMenuView(userService, messageService);
            UserProfileDetailInfoView = new UserProfileDetailInfoView();
            UserProfileDetailEditView = new UserProfileDetailEditView(userService);
            SendMessageView = new SendMessageView(messageService, userService);
            UserShowIncomingMessagesView = new UserShowIncomingMessagesView(messageService);
            UserShowOutgoingMessagesView = new UserShowOutgoingMessagesView(messageService);



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



