using System.ComponentModel.DataAnnotations;

namespace Educational.Domein
{
    public class Lesson
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string VideoPath { get; set; }
        public int Number { get; set; }

        public virtual Course Course { get; set; }

        public virtual List<Homework> Homeworks { get; set; } = new List<Homework>();

    }
}
