using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Finanzauto.Infrastructure.Persistence.Teachers
{
    internal class TeacherMetadata : IEntityTypeConfiguration<TeacherModel>
    {
        public void Configure(EntityTypeBuilder<TeacherModel> builder)
        {
            builder.ToTable("Teachers").HasKey(p => p.Id);

            #region table properties
            builder.Property(p => p.Name).HasMaxLength(250).IsRequired();
            #endregion table properties
        }
    }
}
