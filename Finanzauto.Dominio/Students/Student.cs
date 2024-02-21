using Finanzauto.Dominio.Califications;
using Finanzauto.Dominio.Common;
using Finanzauto.Dominio.Courses;

namespace Finanzauto.Dominio.Students
{
    public class Student : BaseAuditableEntity<int>, IStudent
    {
        public Student()
        {
            Courses = new HashSet<Course>();
            Califications = new HashSet<Calification>();
        }
        public virtual ICollection<Course> Courses { get; set; }
        public virtual ICollection<Calification> Califications { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Identification { get; set; } = string.Empty;
        public DateTime Birthdate { get; set; }
    }
}
