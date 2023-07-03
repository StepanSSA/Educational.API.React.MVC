using Educational.Chat.Domeins;
using Microsoft.EntityFrameworkCore;

namespace Educational.Chat.Data
{
    public class ChatDbContext: DbContext
    {
        public DbSet<User> User { get; set; }
        public DbSet<Connections> Connections { get; set; }
        public DbSet<Message> Messeges { get; set; }

        public ChatDbContext(DbContextOptions<ChatDbContext> options)
            : base(options) { } 
    }
}
