using Finanzauto.Dominio.Common;
using Finanzauto.Dominio.Courses;
using Finanzauto.Dominio.Students;

namespace Finanzauto.Dominio.Califications
{
    public class Calification : BaseAuditableEntity<int>, ICalification
    {
        public virtual Student Student { get; set; } = null!;
        public virtual Course Course { get; set; } = null!;
        public int StudentID { get; set; }
        public int CourseID { get; set; }
        public decimal Note { get; set; }
    }
}