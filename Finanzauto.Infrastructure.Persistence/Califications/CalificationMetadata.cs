using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Finanzauto.Infrastructure.Persistence.Califications
{
    internal class CalificationMetadata : IEntityTypeConfiguration<CalificationModel>
    {
        public void Configure(EntityTypeBuilder<CalificationModel> builder)
        {
            builder.ToTable("Califications").HasKey(p => p.Id);

            #region table properties
            builder.Property(p => p.Note).HasPrecision(2,2).IsRequired();
            #endregion table properties

            #region relationships
            builder.HasOne(s => s.Student).WithMany(c => c.Califications).HasForeignKey(c => c.StudentID);
            builder.HasOne(s => s.Course).WithMany(c => c.Califications).HasForeignKey(c => c.CourseID);
            #endregion relationships
        }
    }
}
