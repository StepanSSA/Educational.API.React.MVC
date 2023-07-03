namespace Educational.Chat.Hubs
{
    public class ChatUser
    {
        private readonly List<ChatConnection> _connection;
        public ChatUser(string userName)
        {
            UserName = userName ?? throw new ArgumentNullException(nameof(userName));
            _connection = new List<ChatConnection>();
        }

        public string UserName { get; set; } = null!;

        public DateTime? connectedAt 
        {
            get 
            {
                if(Connections.Any())
                {
                    return Connections
                        .OrderByDescending(x => x.ConnectedAt)
                        .Select(x => x.ConnectedAt)
                        .FirstOrDefault();
                }

                return null;
            }
        }

        public IEnumerable<ChatConnection> Connections => _connection;

        public void AddConnection(string connectionId)
        {
            if(connectionId == null) 
                throw new ArgumentNullException(nameof(connectionId));

            var connection = new ChatConnection
            {
                ConnectedAt = DateTime.UtcNow,
                ConnectionId = connectionId
            };

            _connection.Add(connection);
        }

        public void RemoveConnection(string connectionId) 
        {
            if (connectionId == null)
                throw new ArgumentNullException(nameof(connectionId));

            var connection = _connection.SingleOrDefault(x => x.ConnectionId.Equals(connectionId));
            if(connection == null)
            {
                return;
            }

            _connection.Remove(connection);
        }
    }
}
