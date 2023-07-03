using Educational.Identity.Data.Entity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Educational.Identity.Data
{
    public class IdentityDataBaseContext : IdentityDbContext<AppUser>
    {
        public DbSet<AppUser> appUser { get; set; }

        public IdentityDataBaseContext(DbContextOptions<IdentityDataBaseContext> options)
            : base(options) { }

    }
}
