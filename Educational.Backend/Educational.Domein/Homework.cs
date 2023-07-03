using System.ComponentModel.DataAnnotations;

namespace Educational.Domein
{
    public class Homework
    {
        [Key]
        public Guid Id { get; set; }
        public string FilePath { get; set; }
        public DateTime date { get; set; }
        public int Score { get; set; }

        public virtual Student Student { get; set; }

        public virtual Lesson Lesson { get; set; }

    }
}
