namespace Finanzauto.Dominio.Students
{
    public interface IStudent
    {
        int Id { get; set; }
        string Name { get; set; }
        string Identification { get; set; }
        DateTime Birthdate { get; set; }
    }
}
