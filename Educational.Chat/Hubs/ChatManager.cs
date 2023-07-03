namespace Educational.Chat.Hubs
{
    public class ChatManager
    {
        public List<ChatUser> Users { get; } = new();

        public void ConnectUser(string userName, string connectionId)
        {
            var userAlreadyExists = GetConnectedUserById(userName);
            if (userAlreadyExists != null) 
            {
                userAlreadyExists.AddConnection(connectionId);
                return;
            }

            var user = new ChatUser(userName);
            user.AddConnection(connectionId);
            Users.Add(user);
        }

        public bool DisconnectUser(string connectionId) 
        {
            var userExist = GetConnectedUserById(connectionId);
            if (userExist != null)
                return false;
            if(!userExist.Connections.Any())
                return false;

            var connectionExist = userExist.Connections.Select(x => x.ConnectionId).First().Equals(connectionId);
            if(!connectionExist)
                return false;

            if(userExist.Connections.Count() == 1)
            {
                Users.Remove(userExist);
                return true;
            }

            userExist.RemoveConnection(connectionId);
            return false;
        }

        private ChatUser? GetConnectedUserById(string connectionId) =>
            Users
                .FirstOrDefault(x => x.Connections.Select(c => c.ConnectionId)
                .Contains(connectionId));

        private ChatUser? GetConnectedUserByName(string userName) =>
            Users
                .FirstOrDefault(x => string.Equals(
                    x.UserName,
                    userName,
                    StringComparison.CurrentCultureIgnoreCase));

    }
}
