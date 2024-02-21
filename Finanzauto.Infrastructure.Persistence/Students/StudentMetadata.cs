using Finanzauto.Dominio.Courses;
using Finanzauto.Dominio.Students;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Finanzauto.Infrastructure.Persistence.Students
{
    internal class StudentMetadata: IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.ToTable("Students").HasKey(p => p.Id);

            #region table properties
            builder.Property(p => p.Name).HasMaxLength(250).IsRequired();
            builder.Property(p => p.Identification).HasMaxLength(50).IsRequired();
            #endregion table properties

            #region relationships
            builder.HasMany(s => s.Courses).WithMany(c => c.Students).UsingEntity("StudentCourse",
            l => l.HasOne(typeof(Course)).WithMany().HasForeignKey("CourseID").HasPrincipalKey(nameof(Student.Id)),
            r => r.HasOne(typeof(Student)).WithMany().HasForeignKey("StudentID").HasPrincipalKey(nameof(Course.Id)),
            j => j.HasKey("CourseID", "StudentID"));
            #endregion relationships
        }
    }
}
