namespace Educational.Chat.Domeins
{
    public class User
    {
        public Guid Id { get; set; }
        public string UserName { get; set; } = null!;
        public IEnumerable<Connections> UserConnections { get; set; } = new List<Connections>();
    }
}
