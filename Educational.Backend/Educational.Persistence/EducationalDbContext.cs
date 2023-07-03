using Educational.Application.Interfaces;
using Educational.Domein;
using Educational.Persistence.Confidurations;
using Microsoft.EntityFrameworkCore;

namespace Educational.Persistence
{
    public class EducationalDbContext : DbContext, IEducationalDbContext
    {
        public DbSet<Course> Courses { get; set; }
        public DbSet<Homework> Homeworks { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<PurchasedCourses> PurchasedCourses { get; set; }

        public EducationalDbContext(DbContextOptions<EducationalDbContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new CourseConfiguration());
            builder.ApplyConfiguration(new HomeworkConfiguration());
            builder.ApplyConfiguration(new LessonConfiguration());
            builder.ApplyConfiguration(new PurchasedCoursesConfiguration());
            builder.ApplyConfiguration(new StudentConfiguration());
            builder.ApplyConfiguration(new TeacherConfiguration());

            base.OnModelCreating(builder);
        }

        public Task<int> SaveChengesAsync(CancellationToken cancellationToken) => base.SaveChangesAsync(cancellationToken);
    }
}
