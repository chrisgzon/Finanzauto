using ErrorOr;

namespace Finanzauto.Application.Students
{
    public interface IStudentService
    {
        Task<ErrorOr<string>> AuthenticateStudent(string identification);
        Task<ErrorOr<int>> CreateStudent(StudentDto student);
        Task<ErrorOr<bool>> EditStudent(StudentDto student);
        Task<ErrorOr<StudentDto>> GetByIdentification(string identification);
        Task<ErrorOr<bool>> Delete(int id);
    }
}
