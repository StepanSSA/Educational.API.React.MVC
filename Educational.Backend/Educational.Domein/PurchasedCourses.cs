using System.ComponentModel.DataAnnotations;

namespace Educational.Domein
{
    public class PurchasedCourses
    {
        [Key]
        public Guid Id { get; set; }
        public DateTime date { get; set; }
        public double purchasePrice { get; set; }

        public virtual Course Course { get; set; }
        public virtual Student Student { get; set; }


    }
}
