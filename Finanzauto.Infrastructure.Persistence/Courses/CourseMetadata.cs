using Finanzauto.Dominio.Courses;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Finanzauto.Infrastructure.Persistence.Courses
{
    internal class CourseMetadata : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.ToTable("Courses").HasKey(p => p.Id);

            #region table properties
            builder.Property(p => p.Name).HasMaxLength(250).IsRequired();
            builder.Property(p => p.Description).HasMaxLength(250).IsRequired();
            #endregion table properties

            #region relationships
            builder.HasOne(s => s.Teacher).WithMany(c => c.Courses).HasForeignKey(c => c.TeacherID);
            #endregion relationships
        }
    }
}