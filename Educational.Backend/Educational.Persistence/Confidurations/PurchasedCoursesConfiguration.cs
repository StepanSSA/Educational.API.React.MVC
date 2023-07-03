using Educational.Domein;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Educational.Persistence.Confidurations
{
    public class PurchasedCoursesConfiguration : IEntityTypeConfiguration<PurchasedCourses>
    {
        public void Configure(EntityTypeBuilder<PurchasedCourses> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasIndex(x => x.Id).IsUnique();
            builder.ToTable(nameof(PurchasedCourses));
        }

    }
}
