using Finanzauto.Dominio.Califications;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Finanzauto.Infrastructure.Persistence.Califications
{
    internal class CalificationMetadata : IEntityTypeConfiguration<Calification>
    {
        public void Configure(EntityTypeBuilder<Calification> builder)
        {
            builder.ToTable("Califications").HasKey(p => p.Id);

            #region table properties
            builder.Property(p => p.Note).HasPrecision(4,2).IsRequired();
            #endregion table properties

            #region relationships
            builder.HasOne(s => s.Student).WithMany(c => c.Califications).HasForeignKey(c => c.StudentID);
            builder.HasOne(s => s.Course).WithMany(c => c.Califications).HasForeignKey(c => c.CourseID);
            #endregion relationships
        }
    }
}
