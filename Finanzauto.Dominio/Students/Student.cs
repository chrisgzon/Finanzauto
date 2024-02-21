using Finanzauto.Dominio.Common;

namespace Finanzauto.Dominio.Students
{
    public class Student : BaseAuditableEntity<int>, IStudent
    {
        public string Name { get; set; } = string.Empty;
        public string Identification { get; set; } = string.Empty;
        public DateTime Birthdate { get; set; }
    }
}
