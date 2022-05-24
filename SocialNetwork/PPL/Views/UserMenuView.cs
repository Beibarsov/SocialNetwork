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

        public UserMenuView(UserService userService, MessageService messageService)
        {
            this.userService = userService;
            this.messageService = messageService;
        }

        public void Show(User user)
        {

            while (true)
            {
                Console.WriteLine("Просмотреть информацию о моём профиле (нажмите 1)");
                Console.WriteLine("Редактировать мой профиль (нажмите 2)");
                Console.WriteLine("Написать сообщение (нажмите 4)");
                Console.WriteLine("Прочитать входящие сообщения (нажмите 5)");
                Console.WriteLine("Прочитать исходящие сообщения (нажмите 6)");
                Console.WriteLine("Добавить друга (нажмите 7)");
                Console.WriteLine("Посмотреть своих друзей (нажмите 8)");
                Console.WriteLine("Выйти из профиля (нажмите 0)");

                switch (Console.ReadLine())
                {
                    case "1":
                        {
                            Program.UserProfileDetailInfoView.Show(user);
                            break;
                        }
                    case "2":
                        {
                            Program.UserProfileDetailEditView.Show(user);
                            break;
                        }
                    case "4":
                        {
                            Program.SendMessageView.Show(user);
                            break;
                        }
                    case "5":
                        {
                            Program.UserShowIncomingMessagesView.Show(user);
                            break;
                        }
                    case "6":
                        {
                            Program.UserShowOutgoingMessagesView.Show(user);
                            break;
                        }
                    case "7":
                        {
                            Program.UserAddFriendView.Show(user);
                            break;
                        }
                    case "8":
                        {
                            Program.UserAllFriendView.Show(user);
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
