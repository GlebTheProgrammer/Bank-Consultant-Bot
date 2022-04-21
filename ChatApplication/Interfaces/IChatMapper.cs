using ChatApplication.Models;

namespace ChatApplication.Interfaces
{
    public interface IChatMapper
    {
        public IEnumerable<ChatMessage> MapIntoChat();
    }
}
