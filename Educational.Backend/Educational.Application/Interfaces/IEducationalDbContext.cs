using Educational.Domein;
using Microsoft.EntityFrameworkCore;

namespace Educational.Application.Interfaces
{
    public interface IEducationalDbContext
    {
        public DbSet<Course> Courses { get; set; }
        public DbSet<Homework> Homeworks { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<PurchasedCourses> PurchasedCourses { get; set; }

        Task<int> SaveChengesAsync(CancellationToken cancellationToken);
    }
}
