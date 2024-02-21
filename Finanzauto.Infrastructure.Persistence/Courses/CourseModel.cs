using Finanzauto.Dominio.Courses;
using Finanzauto.Infrastructure.Persistence.Califications;
using Finanzauto.Infrastructure.Persistence.Students;
using Finanzauto.Infrastructure.Persistence.Teachers;

namespace Finanzauto.Infrastructure.Persistence.Courses
{
    public class CourseModel : Course
    {
        public CourseModel()
        {
            Students = new HashSet<StudentModel>();
            Califications = new HashSet<CalificationModel>();
        }

        public virtual TeacherModel Teacher { get; set; } = null!;
        public virtual ICollection<StudentModel> Students { get; set; }
        public virtual ICollection<CalificationModel> Califications { get; set; }
    }
}