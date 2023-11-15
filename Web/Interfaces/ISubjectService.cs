using Web.Models.Subject;

namespace Web.Interfaces
{
    public interface ISubjectService
    {
        Task<List<SubjectViewDto>> GetAllSubjects();
        Task<SubjectDto> GetSubjectById(Guid id);
        Task<List<SubjectViewDto>> GetSubjectByName(string name);
        Task<SubjectViewDto> AddSubject(CreateSubjectDto createSubjectDto);
        Task<SubjectViewDto> UpdateSubject(Guid id, UpdateSubjectDto updateSubjectDto);
        Task<SubjectViewDto> DeleteSubject(Guid id);
    }
}
