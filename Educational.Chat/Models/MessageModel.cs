namespace Educational.Chat.Models
{
    public class MessageModel
    {
        public string MessageText { get; set; }
        public string SenderName { get; set; }
        public Guid SenderId { get; set; }
        public DateTime Timestamp { get; set; }

    }
}
