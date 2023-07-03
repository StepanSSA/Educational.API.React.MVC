using Educational.Domein;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Educational.Persistence.Confidurations
{
    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.HasKey(x => x.UserId);
            builder.HasIndex(x => x.UserId).IsUnique();
            builder.HasMany(e => e.PurchasedCourses).WithOne(e => e.Student).OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(e => e.Homeworks).WithOne(e => e.Student).OnDelete(DeleteBehavior.Cascade);
            builder.ToTable(nameof(Student));

        }

    }
}
