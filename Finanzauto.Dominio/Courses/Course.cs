using Finanzauto.Dominio.Common;

namespace Finanzauto.Dominio.Courses
{
    public class Course : BaseAuditableEntity<int>, ICourse
    {
        public int TeacherID { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}
