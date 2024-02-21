namespace Finanzauto.Application.Students
{
    /// <summary>
    /// DTO for the transfer of student data between the entry and the domain
    /// </summary>
    public class StudentDto
    {
        public int? Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Identification { get; set; } = string.Empty;
        public DateTime Birthdate { get; set; }
    }
}
