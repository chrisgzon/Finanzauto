namespace Finanzauto.Dominio.Courses
{
    public interface ICourse
    {
        int Id { get; set; }
        int TeacherID { get; set; }
        string Name { get; set; }
        string Description { get; set; }
    }
}
