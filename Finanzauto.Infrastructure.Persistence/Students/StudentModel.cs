using Finanzauto.Dominio.Students;
using Finanzauto.Infrastructure.Persistence.Califications;
using Finanzauto.Infrastructure.Persistence.Courses;

namespace Finanzauto.Infrastructure.Persistence.Students
{
    public class StudentModel : Student
    {
        public StudentModel()
        {
            Courses = new HashSet<CourseModel>();
            Califications = new HashSet<CalificationModel>();
        }
        public virtual ICollection<CourseModel> Courses { get; set; }
        public virtual ICollection<CalificationModel> Califications { get; set; }
    }
}
