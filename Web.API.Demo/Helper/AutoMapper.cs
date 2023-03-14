using AutoMapper;
using Web.API.Demo.Dto;
using Web.API.Demo.Models;

namespace Web.API.Demo.Helper
{
    public class AutoMapper:Profile
    {
        public AutoMapper()
        {
            CreateMap<Student, StudentDto>();
            CreateMap<Subject, SubjectDto>();
        }
    }
}
