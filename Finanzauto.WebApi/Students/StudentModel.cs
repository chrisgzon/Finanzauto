namespace Finanzauto.WebApi.Students
{
    /// <summary>
    /// Class to receive the data to be inserted from the student
    /// </summary>
    public class StudentModel
    {
        public string Name { get; set; } = string.Empty;
        public string Identification { get; set; } = string.Empty;
        public DateTime Birthdate { get; set; }
    }
    /// <summary>
    /// Class to receive the data to be modify from the student
    /// </summary>
    public class StudentUpdateModel : StudentModel
    {
        public int Id { get; set; }
    }
}
