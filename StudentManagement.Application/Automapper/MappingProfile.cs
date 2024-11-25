using AutoMapper;
using StudentManagement.Domain.Entities;
using StudentManagement.Domain.Request.Student;

namespace StudentManagement.Application.Automapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Student, StudentRequest>().ReverseMap();
        }
    }
}