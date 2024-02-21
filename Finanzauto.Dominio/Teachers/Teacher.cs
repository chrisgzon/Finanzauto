using Finanzauto.Dominio.Common;

namespace Finanzauto.Dominio.Teachers
{
    public class Teacher : BaseAuditableEntity<int>, ITeacher
    {
        public string Name { get; set; } = string.Empty;
        public DateTime Birtdhay { get; set; }
    }
}
