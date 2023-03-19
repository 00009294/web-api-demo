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
            CreateMap<StudentDto, Student>();
            CreateMap<Subject, SubjectDto>();
            CreateMap<SubjectDto, Subject>();
            CreateMap<Teacher , TeacherDto>();
            CreateMap<TeacherDto, Teacher>();
        }
    }
}
