using Educational.Chat.Domeins;
using Educational.Chat.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Educational.Chat.Data
{
    public class ChatCRUDRepository : IChatCRUDRepository
    {
        private readonly ChatDbContext _context;

        public ChatCRUDRepository(ChatDbContext chatDbContext)
            => _context = chatDbContext;

        public void AddConnection(Guid userId, string connectionId)
        {
            var connection = new Connections()
            {
                ConnectedAt = DateTime.Now,
                Id = connectionId,
                UserId = userId,
            };

            _context.Connections.Add(connection);
            _context.User.Where(u => u.Id == userId).First().UserConnections.ToList().Add(connection);

            _context.SaveChanges();
        }

        public void AddMessage(Message message)
        {
            _context.Messeges.Add(message);
            _context.SaveChanges();
        }

        public  void AddUser(User user)
        {
            if(_context.User.Any())
            {
                var result = _context.User.Where(u => u.UserName == user.UserName).FirstOrDefault();
                if (result == null)
                {
                    _context.User.Add(user);
                    _context.SaveChanges();
                }
            }
            else
            {
                _context.User.Add(user);
                _context.SaveChanges();
            }
        }

        public User GetConnectedUserById(Guid id)
        {
            throw new NotImplementedException();
        }

        public User GetConnectedUserByName(string userName)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<MessageModel> GetDialogMessages(Guid recipientId, Guid userId)
        {
            var result = _context.Messeges
                .Where(m => m.RecipientId == recipientId && m.SenderId == userId)
                .OrderBy(m => m.Time).ToList();
            var messages = new List<MessageModel>();
            foreach (var item in result)
            {
                messages.Add(new MessageModel()
                {
                    MessageText = item.MessageText,
                    SenderName = GetUserById(item.SenderId).UserName,
                    SenderId = item.SenderId,
                    Timestamp = item.Time
                });
            }

            result = _context.Messeges
                .Where(m => m.SenderId == recipientId && m.RecipientId == userId)
                .OrderBy(m => m.Time).ToList();
            foreach (var item in result)
            {
                messages.Add(new MessageModel()
                {
                    MessageText = item.MessageText,
                    SenderName = GetUserById(item.SenderId).UserName,
                    SenderId = item.SenderId,
                    Timestamp = item.Time
                });
            }
            return messages.OrderBy(m => m.Timestamp);
        }

        public Message GetMessageById(Guid id)
        {
            return _context.Messeges.Where(m => m.Id == id).FirstOrDefault() ??
                throw new NullReferenceException(nameof(Message) + " Не найдено по данному идентификатору " + id);
        }

        public IEnumerable<Message> GetRecipientMessages(Guid recipientId)
        {
            return _context.Messeges.Where(m => m.RecipientId == recipientId).ToList();
        }

        public User GetUserById(Guid id)
        {
            return _context.User.Where(u => u.Id == id).FirstOrDefault() ??
                throw new NullReferenceException(nameof(User) + " Не найден по данному идентификатору " + id);
        }

        public User GetUserByName(string userName)
        {
            return _context.User.Where(u => u.UserName == userName).FirstOrDefault() ??
                throw new NullReferenceException(nameof(User) + " Не найден по данному имени " + userName);
        }

        public IEnumerable<string> GetUserConnections(Guid userId)
        {
            var connections = _context.Connections.Where(c => c.UserId == userId).ToList()
                ?? throw new NullReferenceException(typeof(Connections) + " Не найдено соединений с таким идентификатором пользователя " + userId);
            return connections.Select(c => c.Id).ToList();
        }

        public IEnumerable<UserDialogs> GetUserDialogs(Guid userId)
        {
            var result = _context.Messeges.Where(m => m.SenderId == userId).ToList();
            
            var userDialog = new List<UserDialogs>();
            for (var i = 1; i < result.Count(); i++)
            {
                if (result[i].RecipientId == result[i-1].RecipientId)
                {
                    result.Remove(result[i]);
                    i--;
                }
            }
            foreach (var item in result)
            {
                userDialog.Add(new UserDialogs()
                {
                    Interlocutor = GetUserById(item.RecipientId).UserName,
                    InterlocutorId = item.RecipientId,
                });
            }

            result = _context.Messeges.Where(m => m.RecipientId == userId).ToList();
            for (var i = 1; i < result.Count(); i++)
            {
                if (result[i].SenderId == result[i-1].SenderId)
                {
                    result.Remove(result[i]);
                    i--;
                }
            }
            for (int i = 0; i < result.Count; i++)
            {
                var dialog = new UserDialogs()
                {
                    Interlocutor = GetUserById(result[i].SenderId).UserName,
                    InterlocutorId = result[i].SenderId,
                };
                var data = userDialog.Where(u => u.InterlocutorId == dialog.InterlocutorId).FirstOrDefault();
                if(data == null)
                    userDialog.Add(dialog);
            }

            return userDialog;
        }

        public bool RemoveConnection(string connectionId)
        {
            var connection = _context.Connections.Where(c => c.Id == connectionId).FirstOrDefault() ??
                throw new NullReferenceException(nameof(Connections) + " Не содержит данного индентификатора соединения: " + connectionId);
            var user = _context.User.Where(u => u.UserConnections.Contains<Connections>(connection)).FirstOrDefault() ??
                throw new NullReferenceException(nameof(User) + " Не содержит данного соединения: " + connectionId);
            
            user.UserConnections.ToList().Remove(connection);
            _context.Connections.ToList().Remove(connection);

            _context.SaveChanges();

            return true;
        }
    }
}
