using Educational.Domein;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Educational.Persistence.Confidurations
{
    public class LessonConfiguration : IEntityTypeConfiguration<Lesson>
    {
        public void Configure(EntityTypeBuilder<Lesson> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasIndex(x => x.Id).IsUnique();
            builder.HasMany(e => e.Homeworks).WithOne(e => e.Lesson).OnDelete(DeleteBehavior.Cascade);
            builder.ToTable(nameof(Lesson));

        }

    }
}
