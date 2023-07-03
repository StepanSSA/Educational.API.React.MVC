using System.ComponentModel.DataAnnotations;

namespace Educational.Domein
{
    public class Course
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Duration { get; set; }
        public double Price { get; set; }
        public bool Confirmed { get; set; } = false;
        public virtual List<Lesson> Lessons { get; set; } = new List<Lesson>();

        public virtual Teacher Teacher { get; set; }

    }
}
