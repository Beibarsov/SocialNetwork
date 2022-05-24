using SocialNetwork.BLL.Exceptions;
using SocialNetwork.BLL.Models;
using SocialNetwork.BLL.Services;
using SocialNetwork.PPL.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.PPL.Views
{
    public class UserAddFriendView
    {

        FriendService friendService;

        public UserAddFriendView(FriendService friendService)
        {
            this.friendService = friendService;
        }

        public void Show(User user)
        {

            AddFriendData addFriendData = new AddFriendData();
            addFriendData.SenderId = user.Id;

            Console.WriteLine("Начат процесс добавления в друзья");
            Console.WriteLine("Введите почтовый адрес друга:");
            addFriendData.RecepientEmail = Console.ReadLine();

            try
            {
                friendService.CreateFriendship(addFriendData);
                Console.WriteLine("Дружба создана");
            }
            catch (UserNotFoundException)
            {
                ImportantMessageHelper.AlertMessageWriteLine("Пользователь не найден!");
            }
            catch (Exception)
            {
                ImportantMessageHelper.AlertMessageWriteLine("Произошла некая ошибка при отправке сообщения!");
            }
        }
    }

}
