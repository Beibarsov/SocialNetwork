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
    public class UserAllFriendView
    {

        FriendService friendService;

        public UserAllFriendView(FriendService friendService)
        {
            this.friendService = friendService;
        }

        public void Show(User user)
        {

            foreach(var friend in friendService.ShowUsersFriends(user.Id)){
                Console.WriteLine($"Ваш друг {friend.FriendEmail}");
            }
        }
    }

}
