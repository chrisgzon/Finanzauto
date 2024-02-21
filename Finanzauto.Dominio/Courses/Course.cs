using Finanzauto.Dominio.Califications;
using Finanzauto.Dominio.Common;
using Finanzauto.Dominio.Students;
using Finanzauto.Dominio.Teachers;

namespace Finanzauto.Dominio.Courses
{
    public class Course : BaseAuditableEntity<int>, ICourse
    {
        public Course()
        {
            Students = new HashSet<Student>();
            Califications = new HashSet<Calification>();
        }

        public virtual Teacher Teacher { get; set; } = null!;
        public virtual ICollection<Student> Students { get; set; }
        public virtual ICollection<Calification> Califications { get; set; }
        public int TeacherID { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}
