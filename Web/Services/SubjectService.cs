using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Web.Entities;
using Web.Interfaces;
using Web.Models.Subject;

namespace Web.Services
{
    public class SubjectService : ISubjectService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public SubjectService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<List<SubjectViewDto>> GetAllSubjects()
        {
            return await _mapper.ProjectTo<SubjectViewDto>(_unitOfWork.subjectRepository.GetAll()).ToListAsync();
        }

        public async Task<SubjectDto> GetSubjectById(Guid id)
        {
            var subject = await _unitOfWork.subjectRepository.GetById(id);
            if (subject == null)
            {
                throw new BadHttpRequestException("Not found subject");
            }
            return _mapper.Map<SubjectDto>(subject);    
        }

        public async Task<SubjectViewDto> AddSubject(CreateSubjectDto createSubjectDto)
        {
            var newSubject = new Subject
            {
                Id = Guid.NewGuid(),
                Name = createSubjectDto.Name,
                NumberOfCredits = createSubjectDto.NumberOfCredits,
                CreateAt = DateTime.UtcNow,
            };

            await _unitOfWork.subjectRepository.Add(newSubject);
            await _unitOfWork.CompeteAsync();
            return _mapper.Map<SubjectViewDto>(newSubject);
        }

        public async Task<SubjectViewDto> UpdateSubject(Guid id, UpdateSubjectDto updateSubjectDto)
        {
            var subject = await _unitOfWork.subjectRepository.GetById(id);
            if(subject == null)
            {
                throw new BadHttpRequestException("Not found subject");
            }
            subject.Name = updateSubjectDto.Name;
            subject.NumberOfCredits = updateSubjectDto.NumberOfCredits;
            subject.UpdateAt = DateTime.UtcNow;
            int sucess = await _unitOfWork.CompeteAsync();
            return _mapper.Map<SubjectViewDto>(subject);
        }

        public async Task<SubjectViewDto> DeleteSubject(Guid id)
        {
            var subject = await _unitOfWork.subjectRepository.GetById(id);
            if (subject == null)
            {
                throw new BadHttpRequestException("Not found subject");
            }
            await _unitOfWork.subjectRepository.Delete(id);
            await _unitOfWork.CompeteAsync();
            return _mapper.Map<SubjectViewDto>(subject);
        }

        public async Task<List<SubjectViewDto>> GetSubjectByName(string name)
        {
            var subjects = await _mapper.ProjectTo<SubjectViewDto>(_unitOfWork.subjectRepository.GetByName(name)).ToListAsync();
            if (subjects.Count() == 0)
            {
                throw new KeyNotFoundException("Not found subject");
            }
            return subjects;
        }

        
    }
}
