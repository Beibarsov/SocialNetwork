using SocialNetwork.BLL.Models;
using SocialNetwork.BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.PPL.Views
{
    public class UserShowIncomingMessagesView
    {

        MessageService messageService;

        public UserShowIncomingMessagesView(MessageService messageService)
        {
            this.messageService = messageService;
        }
        public void Show(User user)
        {
            foreach (var message in messageService.GetIncomingMessagesByUserID(user.Id))
            {
                Console.WriteLine("Вам писал: " + message.SenderEmail);
                Console.WriteLine("Текст письма: " + message.Content);
            }
        }
    }
}
