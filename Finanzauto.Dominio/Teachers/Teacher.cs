using Finanzauto.Dominio.Common;
using Finanzauto.Dominio.Courses;

namespace Finanzauto.Dominio.Teachers
{
    public class Teacher : BaseAuditableEntity<int>, ITeacher
    {
        public Teacher()
        {
            Courses = new HashSet<Course>();
        }
        public virtual ICollection<Course> Courses { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateTime Birtdhay { get; set; }
    }
}
