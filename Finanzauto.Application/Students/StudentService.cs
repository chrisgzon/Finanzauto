using AutoMapper;
using ErrorOr;
using Finanzauto.Application.Common.Interfaces;
using Finanzauto.Dominio.Common;
using Finanzauto.Dominio.Students;

namespace Finanzauto.Application.Students
{
    public class StudentService : IStudentService
    {
        private readonly IRepositoryBase<Student> _studentRepository;
        private readonly IAuthentication _authentication;
        private readonly IMapper _mapper;
        public StudentService(
            IRepositoryBase<Student> studentRepository,
            IMapper mapper,
            IAuthentication authentication)
        {
            _studentRepository = studentRepository;
            _mapper = mapper;
            _authentication = authentication;
        }
        public async Task<ErrorOr<int>> CreateStudent(StudentDto student)
        {
            if (student == null)
                return StudentErrors.StudentIsRequired;

            if (string.IsNullOrEmpty(student.Identification) || string.IsNullOrEmpty(student.Name))
            {
                return StudentErrors.StudentInvalid;
            }

            var exist = await _studentRepository.GetByParams(x => x.Identification == student.Identification);
            if (!(exist is null))
            {
                return StudentErrors.StudentExist;
            }

            var entity = _mapper.Map<Student>(student);
            entity.Created = DateTime.Now;
            await _studentRepository.Add(entity);
            return entity.Id;

        }

        public async Task<ErrorOr<string>> AuthenticateStudent(string identification)
        {
            Student? student = await _studentRepository.GetByParams(x => x.Identification == identification);
            if (student is null)
            {
                return StudentErrors.StudentNotFound;
            }

            return _authentication.Authenticate(student.Identification, student.Name);
        }

        public async Task<ErrorOr<bool>> EditStudent(StudentDto student)
        {
            if (student.Id == null)
            {
                return StudentErrors.StudentWithoutId;
            }

            if (string.IsNullOrEmpty(student.Identification) || string.IsNullOrEmpty(student.Name))
            {
                return StudentErrors.StudentInvalid;
            }

            var exist = await _studentRepository.GetByParams(x => x.Id != student.Id && x.Identification == student.Identification);
            if (!(exist is null))
            {
                return StudentErrors.StudentExist;
            }

            var entity = await _studentRepository.GetByParams(x => x.Id == student.Id);
            if (entity is null)
            {
                return StudentErrors.StudentNotFound;
            }
            entity.Birthdate = student.Birthdate;
            entity.Name = student.Name;
            entity.Identification = student.Identification;
            entity.LastModified = DateTime.Now;
            return await _studentRepository.Update(entity);
        }

        public async Task<ErrorOr<StudentDto>> GetByIdentification(string identification)
        {
            if (identification == null)
            {
                return StudentErrors.StudentWithoutIdentification;
            }

            Student? student = await _studentRepository.GetByParams(x => x.Identification == identification);
            if (student is null)
            {
                return StudentErrors.StudentNotFound;
            }


            return _mapper.Map<StudentDto>(student);
        }

        public async Task<ErrorOr<bool>> Delete(int id)
        {
            if (id == 0)
            {
                return StudentErrors.StudentWithoutId;
            }

            Student? student = await _studentRepository.GetByParams(x => x.Id == id);
            if (student is null)
            {
                return StudentErrors.StudentNotFound;
            }

            return await _studentRepository.Delete(id);
        }
    }
}
