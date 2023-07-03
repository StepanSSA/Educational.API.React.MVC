using System.ComponentModel.DataAnnotations;

namespace Educational.Domein
{
    public class Teacher
    {
        [Key]
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public virtual List<Course> Course { get; set; } = new List<Course>();

    }
}
