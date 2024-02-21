using Finanzauto.Dominio.Teachers;
using Finanzauto.Infrastructure.Persistence.Courses;

namespace Finanzauto.Infrastructure.Persistence.Teachers
{
    public class TeacherModel : Teacher
    {
        public TeacherModel()
        {
            Courses = new HashSet<CourseModel>();
        }
        public virtual ICollection<CourseModel> Courses { get; set; }
    }
}