using Finanzauto.Application.Common.Interfaces;
using Finanzauto.Dominio.Califications;
using Finanzauto.Dominio.Courses;
using Finanzauto.Dominio.Students;
using Finanzauto.Dominio.Teachers;
using Finanzauto.Infrastructure.Persistence.Califications;
using Finanzauto.Infrastructure.Persistence.Courses;
using Finanzauto.Infrastructure.Persistence.Students;
using Finanzauto.Infrastructure.Persistence.Teachers;
using Microsoft.EntityFrameworkCore;

namespace Finanzauto.Infrastructure.Persistence.Contexts
{
    public class FinanzautoDBContext : DbContext
    {
        public FinanzautoDBContext(
            DbContextOptions<FinanzautoDBContext> dbContextOptions)
            : base(dbContextOptions)
        { }

        #region tables
        public virtual DbSet<Student> Students { get; set; } = null!;
        public virtual DbSet<Course> Courses { get; set; } = null!;
        public virtual DbSet<Calification> Califications { get; set; } = null!;
        public virtual DbSet<Teacher> Teachers { get; set; } = null!;
        #endregion tables

        #region configuration
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new StudentMetadata());
            modelBuilder.ApplyConfiguration(new CourseMetadata());
            modelBuilder.ApplyConfiguration(new CalificationMetadata());
            modelBuilder.ApplyConfiguration(new TeacherMetadata());
        }
        #endregion configuration
    }
}