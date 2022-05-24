using SocialNetwork.BLL.Exceptions;
using SocialNetwork.BLL.Models;
using SocialNetwork.DAL.Entities;
using SocialNetwork.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.BLL.Services
{
    public class FriendService
    {
        FriendRepository friendRepository;
        UserRepository userRepository;

        public FriendService(){
            userRepository = new UserRepository();
            friendRepository = new FriendRepository();
        }

        public IEnumerable<Friend> ShowUsersFriends(int senderID)
        {
            var friends = new List<Friend>();

            friendRepository.FindAllByUserId(senderID).ToList().ForEach(m =>
            {
                var FriendEmail = userRepository.FindById(m.friend_id).email;

                friends.Add(new Friend { FriendEmail = FriendEmail});
            });
            return friends;
        }

        public void CreateFriendship(AddFriendData addFriendData)
        {

            var findUserEntity = userRepository.FindByEmail(addFriendData.RecepientEmail);
            if (findUserEntity == null)
            {
                throw new UserNotFoundException();
            }

            var friendEntity = new FriendEntity()
            {
                user_id = addFriendData.SenderId,
                friend_id = findUserEntity.id
            };

            friendRepository.Create(friendEntity);
        }
    }
}
