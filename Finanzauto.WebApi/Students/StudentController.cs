using AutoMapper;
using Finanzauto.Application.Students;
using Finanzauto.WebApi.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Finanzauto.WebApi.Students
{
    [Authorize]
    [Route("[controller]/[action]")]
    public class StudentController : ApiController
    {
        private readonly IStudentService _studentService;
        private readonly IMapper _mapper;
        public StudentController(IStudentService studentService, IMapper mapper)
        {
            _studentService = studentService ?? throw new ArgumentNullException(nameof(studentService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        // POST: StudentController/Authenticate
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Authenticate([FromBody] string identification)
        {
            var createStudentResult = await _studentService.AuthenticateStudent(identification);
            return createStudentResult.Match(
                jwt => Ok(JsonSerializer.Serialize(jwt)),
                errors => Problem(errors)
            );
        }

        // POST: Student/Create
        [HttpPost]
        public async Task<IActionResult> Create(StudentModel student)
        {
            var dto = _mapper.Map<StudentDto>(student);
            var createStudentResult = await _studentService.CreateStudent(dto);
            return createStudentResult.Match(
                studentId => Ok(JsonSerializer.Serialize(studentId)),
                errors => Problem(errors)
            );
        }

        // POST: Student/Edit/1
        [HttpPut]
        public async Task<IActionResult> Edit(StudentUpdateModel student)
        {
            var dto = _mapper.Map<StudentDto>(student);
            var createStudentResult = await _studentService.EditStudent(dto);
            return createStudentResult.Match(
                result => Ok(),
                errors => Problem(errors)
            );
        }

        // POST: Student/GetStudent/{identification}
        [HttpGet("{identification}")]
        public async Task<IActionResult> GetStudent(string identification)
        {
            var createStudentResult = await _studentService.GetByIdentification(identification);
            return createStudentResult.Match(
                student => Ok(student),
                errors => Problem(errors)
            );
        }

        // POST: Student/Delete/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var createStudentResult = await _studentService.Delete(id);
            return createStudentResult.Match(
                result => Ok(),
                errors => Problem(errors)
            );
        }
    }
}
