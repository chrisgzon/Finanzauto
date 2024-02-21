using Finanzauto.Dominio.Common;

namespace Finanzauto.Dominio.Califications
{
    public class Calification : BaseAuditableEntity<int>, ICalification
    {
        public int StudentID { get; set; }
        public int CourseID { get; set; }
        public decimal Note { get; set; }
    }
}