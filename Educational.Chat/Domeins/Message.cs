namespace Educational.Chat.Domeins
{
    public class Message
    {
        public Guid Id { get; set; } = Guid.Empty!;
        public string MessageText { get; set; } = null!;
        public Guid SenderId { get; set; } = Guid.Empty!;
        public Guid RecipientId { get; set; } = Guid.Empty!;
        public DateTime Time { get; set; } = DateTime.Now;
    }
}
