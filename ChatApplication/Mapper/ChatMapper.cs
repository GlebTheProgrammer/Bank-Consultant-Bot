using ChatApplication.Interfaces;
using ChatApplication.Models;

namespace ChatApplication.Mapper
{
    public class ChatMapper : IChatMapper
    {
        private readonly IChatRepository repository;
        public ChatMapper(IChatRepository repository)
        {
            this.repository = repository;
        }
        public IEnumerable<ChatMessage> MapIntoChat()
        {
            var userMessages = repository.GetAllUserMessagesById(OnlineUser.Id);
            var botMessages = repository.GetAllBotMessagesForSpecialUserByUserId(OnlineUser.Id);

            List<ChatMessage> chatMessages = new List<ChatMessage>();

            foreach (var message in userMessages)
            {
                chatMessages.Add(new ChatMessage
                {
                    SenderName = OnlineUser.Nickname,
                    Message = message.Text,
                    MessageTime = message.DatePublished
                });
            }
            foreach (var message in botMessages)
            {
                chatMessages.Add(new ChatMessage
                {
                    SenderName = "Bot",
                    Message = message.Text,
                    MessageTime = message.DatePublished
                });
            }

            return chatMessages.OrderBy(message => message.MessageTime).ToList();
        }
    }
}
