using AutoMapper;
using Web.Entities;
using Web.Models.Classroom;

namespace Web.Mapper
{
    public class ClassroomProfile : Profile
    {
        public ClassroomProfile() { 
            CreateMap<Classroom,ClassroomDto>().ReverseMap();
            CreateMap<Classroom,ClassroomViewDto>().ReverseMap();
            CreateMap<CreateClassroomDto, Classroom>();
            CreateMap<UpdateClassroomDto, Classroom>();
        }
    }
}
