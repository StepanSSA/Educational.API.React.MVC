using Educational.Chat.Data;
using Educational.Chat.Domeins;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;

namespace Educational.Chat.Hubs
{
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class CommunicationHub : Hub<ICommunicationHub>
    {
        private const string _defaultGroupName = "General";
        private readonly IChatCRUDRepository _repository;

        public CommunicationHub(IChatCRUDRepository repository)
        {
            _repository = repository;
        }

        public override async Task OnConnectedAsync()
        {
            var userId = Context.User?.Claims?.ToArray()[6].Value;
            var connectionId = Context.ConnectionId;

            _repository.AddConnection(new Guid(userId), connectionId);
            await Groups.AddToGroupAsync(connectionId, _defaultGroupName);

            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            var isUserRemoved = _repository.RemoveConnection(Context.ConnectionId);
            if (isUserRemoved)
                await base.OnDisconnectedAsync(exception);

            await Groups.RemoveFromGroupAsync(Context.ConnectionId, _defaultGroupName);
            await base.OnDisconnectedAsync(exception);
        }

        public async Task SendMessageRecipientAsync(string senderId, string message, string recipientId)
        {
            
            var connections = _repository.GetUserConnections(new Guid(recipientId));

            var user = _repository.GetUserById(new Guid(senderId));

            await Clients.Clients(connections).SendMessageAsync(user.UserName, message);
            
            _repository.AddMessage(new Message()
            {
                Id = new Guid(),
                MessageText = message,
                RecipientId = new Guid(recipientId),
                SenderId = new Guid(senderId),
                Time = DateTime.Now,
            });
        }
            
        public async Task SendMessageEveryoneAsync(string senderName, string message)
        {
            await Clients.Others.SendMessageAsync(senderName, message);
        }
            
    }

}
