using AutoMapper;
using Web.Entities;
using Web.Models.Subject;

namespace Web.Mapper
{
    public class SubjectProfile : Profile
    {
        public SubjectProfile() { 
            CreateMap<Subject,SubjectDto>().ReverseMap();
            CreateMap<Subject,SubjectViewDto>().ReverseMap();
            CreateMap<CreateSubjectDto, SubjectDto>();
            CreateMap<UpdateSubjectDto, SubjectDto>();
        }
    }
}
