using SocialNetwork.BLL.Models;
using SocialNetwork.BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.PPL.Views
{
    public class UserShowOutgoingMessagesView
    {

        MessageService messageService;

        public UserShowOutgoingMessagesView(MessageService messageService)
        {
            this.messageService = messageService;
        }
        public void Show(User user)
        {
            foreach (var message in messageService.GetOutGoingMessagesByUserID(user.Id))
            {
                Console.WriteLine("Вы писали: " + message.RecepientEmail);
                Console.WriteLine("Текст письма: " + message.Content);
            }
        }
    }
}
