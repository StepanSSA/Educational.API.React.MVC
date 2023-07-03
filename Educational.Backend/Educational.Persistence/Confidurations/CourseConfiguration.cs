using Educational.Domein;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
namespace Educational.Persistence.Confidurations
{
    public class CourseConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasIndex(x => x.Id).IsUnique();
            builder.HasOne(e => e.Teacher).WithMany(e => e.Course).OnDelete(DeleteBehavior.SetNull);
            builder.HasMany(e => e.Lessons).WithOne(e => e.Course).OnDelete(DeleteBehavior.SetNull);
            builder.ToTable(nameof(Course));
        }

    }
}
