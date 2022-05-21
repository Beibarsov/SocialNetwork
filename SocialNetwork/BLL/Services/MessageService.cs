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
    public class MessageService
    {
        MessageRepository messageRepository;
        UserRepository userRepository;

        public MessageService(){
            messageRepository = new MessageRepository();
            userRepository = new UserRepository();
        }

        public IEnumerable<Message> GetIncomingMessagesByUserID(int recepientID)
        {
            var messages = new List<Message>();

            messageRepository.FindByRecipientId(recepientID).ToList().ForEach(m =>
            {
                var senderEmail = userRepository.FindById(m.sender_id).email;
                var recepientEmail = userRepository.FindById(m.recipient_id).email;

                messages.Add(new Message { Content = m.content, Id = m.id, RecepientEmail = recepientEmail, SenderEmail = senderEmail });
            });
            return messages;
        }

        public IEnumerable<Message> GetOutGoingMessagesByUserID(int senderID)
        {
            var messages = new List<Message>();

            messageRepository.FindBySenderId(senderID).ToList().ForEach(m =>
            {
                var senderEmail = userRepository.FindById(m.sender_id).email;
                var recepientEmail = userRepository.FindById(m.recipient_id).email;

                messages.Add(new Message { Content = m.content, Id = m.id, RecepientEmail = recepientEmail, SenderEmail = senderEmail });
            });
            return messages;
        }

        public void CreateMessage(MessageSendingData messageSendingData)
        {

            if (String.IsNullOrEmpty(messageSendingData.Content)) throw new ArgumentNullException();
            if (messageSendingData.Content.Length > 5000) throw new ArgumentOutOfRangeException();

            var findUserEntity = userRepository.FindByEmail(messageSendingData.RecepientEmail);
            if (findUserEntity == null)
            {
                throw new ArgumentNullException();
            }

            var messageEntity = new MessageEntity()
            {
                content = messageSendingData.Content,
                sender_id = messageSendingData.SenderID,
                recipient_id = findUserEntity.id
            };

            messageRepository.Create(messageEntity);
        }
    }
}
