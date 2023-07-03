using System.ComponentModel.DataAnnotations;

namespace Educational.Domein
{
    public class Student
    {
        [Key]
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }

        public virtual List<Homework> Homeworks { get; set; } = new List<Homework>();

        public virtual List<PurchasedCourses> PurchasedCourses { get; set; } = new List<PurchasedCourses>();

    }
}
