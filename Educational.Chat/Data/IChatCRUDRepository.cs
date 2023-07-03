using Educational.Chat.Domeins;
using Educational.Chat.Models;

namespace Educational.Chat.Data
{
    public interface IChatCRUDRepository
    {
        void AddUser(User user);
        User GetUserById(Guid id);
        User GetUserByName(string userName);
        User GetConnectedUserById(Guid id);
        User GetConnectedUserByName(string userName);
        bool RemoveConnection(string connectionId);
        void AddConnection(Guid userId, string connectionId);
        void AddMessage(Message message);
        Message GetMessageById(Guid id);
        IEnumerable<Message> GetRecipientMessages(Guid recipientId);
        IEnumerable<UserDialogs> GetUserDialogs(Guid userId);
        IEnumerable<MessageModel> GetDialogMessages(Guid recipientId, Guid userId);
        IEnumerable<string> GetUserConnections(Guid userId);

    }
}
