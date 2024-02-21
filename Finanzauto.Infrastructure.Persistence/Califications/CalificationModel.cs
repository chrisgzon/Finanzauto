using Finanzauto.Dominio.Califications;
using Finanzauto.Infrastructure.Persistence.Courses;
using Finanzauto.Infrastructure.Persistence.Students;

namespace Finanzauto.Infrastructure.Persistence.Califications
{
    public class CalificationModel : Calification
    {
        public virtual StudentModel Student { get; set; } = null!;
        public virtual CourseModel Course { get; set; } = null!;
    }
}