using AutoMapper;
using Web.Entities;
using Web.Models.Student;

namespace Web.Mapper
{
    public class StudentProfile : Profile
    {
        public StudentProfile() {
            CreateMap<Student,StudentDto>().ReverseMap();
            CreateMap<Student,StudentViewDto>().ReverseMap();
            CreateMap<CreateStudentDto, Student>();
            CreateMap<UpdateStudentDto, Student>();
        }
    }
}
