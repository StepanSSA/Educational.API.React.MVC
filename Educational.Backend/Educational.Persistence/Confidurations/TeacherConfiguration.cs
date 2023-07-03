using Educational.Domein;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Educational.Persistence.Confidurations
{
    public class TeacherConfiguration : IEntityTypeConfiguration<Teacher>
    {
        public void Configure(EntityTypeBuilder<Teacher> builder)
        {
            builder.HasKey(x => x.UserId);
            builder.HasIndex(x => x.UserId).IsUnique();
            builder.ToTable(nameof(Teacher));
        }

    }
}
