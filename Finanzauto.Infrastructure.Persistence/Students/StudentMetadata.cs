using Finanzauto.Dominio.Courses;
using Finanzauto.Infrastructure.Persistence.Courses;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Finanzauto.Infrastructure.Persistence.Students
{
    internal class StudentMetadata: IEntityTypeConfiguration<StudentModel>
    {
        public void Configure(EntityTypeBuilder<StudentModel> builder)
        {
            builder.ToTable("Students").HasKey(p => p.Id);

            #region table properties
            builder.Property(p => p.Name).HasMaxLength(250).IsRequired();
            builder.Property(p => p.Identification).HasMaxLength(50).IsRequired();
            #endregion table properties

            #region relationships
            builder.HasMany(s => s.Courses).WithMany(c => c.Students).UsingEntity("StudentCourse",
            l => l.HasOne(typeof(StudentModel)).WithMany().HasForeignKey("StudentID").HasPrincipalKey(nameof(StudentModel.Id)),
            r => r.HasOne(typeof(CourseModel)).WithMany().HasForeignKey("CourseID").HasPrincipalKey(nameof(Course.Id)),
            j => j.HasKey("StudentID", "CourseID"));
            #endregion relationships
        }
    }
}
