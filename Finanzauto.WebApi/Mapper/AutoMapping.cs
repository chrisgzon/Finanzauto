using Finanzauto.Application.Students;
using Finanzauto.Dominio.Students;
using Finanzauto.WebApi.Students;

namespace Finanzauto.WebApi.Mapper
{
    public class AutoMapping : AutoMapper.Profile
    {
        public AutoMapping()
        {
            CreateMap<StudentModel, StudentDto>().ReverseMap();
            CreateMap<StudentDto, Student>().ReverseMap();
            CreateMap<StudentUpdateModel, StudentDto>().ReverseMap();
        }
    }
}
