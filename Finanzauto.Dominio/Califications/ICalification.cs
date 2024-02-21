namespace Finanzauto.Dominio.Califications
{
    public interface ICalification
    {
        int Id { get; set; }
        int StudentID { get; set; }
        int CourseID { get; set; }
        decimal Note { get; set; }
    }
}
