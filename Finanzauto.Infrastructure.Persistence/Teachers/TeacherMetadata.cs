using Finanzauto.Dominio.Teachers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Finanzauto.Infrastructure.Persistence.Teachers
{
    internal class TeacherMetadata : IEntityTypeConfiguration<Teacher>
    {
        public void Configure(EntityTypeBuilder<Teacher> builder)
        {
            builder.ToTable("Teachers").HasKey(p => p.Id);

            #region table properties
            builder.Property(p => p.Name).HasMaxLength(250).IsRequired();
            #endregion table properties
        }
    }
}
