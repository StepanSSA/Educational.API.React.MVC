namespace Educational.Chat.Hubs
{
    public interface ICommunicationHub
    {

        Task SendMessageAsync(string senderName, string message);

        Task UpdateUserAsync(IEnumerable<string> users);
    }
}
