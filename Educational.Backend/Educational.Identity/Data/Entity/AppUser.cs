using Microsoft.AspNetCore.Identity;

namespace Educational.Identity.Data.Entity
{
    public class AppUser : IdentityUser
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public DateOnly BirthDate { get; set; }
    }
}
