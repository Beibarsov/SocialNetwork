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
    public class SendMessageView
    {

        MessageService messageService;
        UserService userService;

        public SendMessageView(MessageService messageService, UserService userService)
        {
            this.messageService = messageService;
            this.userService = userService;
        }

        public void Show(User user)
        {

            MessageSendingData message = new MessageSendingData();

            message.SenderID = user.Id;
            Console.WriteLine("Напишите текст сообщения:");
            message.Content = Console.ReadLine();
            Console.WriteLine("Кому мы его отправляем? Укажите почту:");
            message.RecepientEmail = Console.ReadLine();

            try
            {
                messageService.CreateMessage(message);
                Console.WriteLine("Сообщение создано");
            }
            catch (UserNotFoundException)
            {
                ImportantMessageHelper.AlertMessageWriteLine("Пользователь не найден!");
            }

            catch (ArgumentNullException)
            {
                ImportantMessageHelper.AlertMessageWriteLine("Введите корректное значение!");
            }

            catch (Exception)
            {
                ImportantMessageHelper.AlertMessageWriteLine("Произошла некая ошибка при отправке сообщения!");
            }
        }
    }

}
