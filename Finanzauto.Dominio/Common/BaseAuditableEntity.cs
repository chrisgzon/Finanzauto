namespace Finanzauto.Dominio.Common
{
    public abstract class BaseAuditableEntity<T> : BaseEntity<T>
    {
        public DateTime Created { get; set; }
        public DateTime LastModified { get; set; }
    }
}
