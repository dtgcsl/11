using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Web.Entities;
using Web.Models.Classroom;
using Web.Interfaces;
using Web.Models.Student;

namespace Web.Services
{
    public class ClassService : IClassService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public ClassService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<List<ClassroomViewDto>> GetAllClassrom()
        {
            return await _mapper.ProjectTo<ClassroomViewDto>(_unitOfWork.classroomRepository.GetAll()).ToListAsync();
        }

        public async Task<ClassroomViewDto> GetClassroomById(Guid id)
        {
            var classroom = await _unitOfWork.classroomRepository.GetById(id);
            if (classroom == null)
            {
                throw new BadHttpRequestException("Not found student");
            }
            return _mapper.Map<ClassroomViewDto>(classroom);
        }

        public async Task<ClassroomViewDto> AddClassroom(CreateClassroomDto createStudentDto)
        {
            var newClassroom = new Classroom
            {
                Id = Guid.NewGuid(),
                Name = createStudentDto.Name,
                HomeroomTeacher = createStudentDto.HomeroomTeacher,
            };
            try
            {
                await _unitOfWork.classroomRepository.Add(newClassroom);
                await _unitOfWork.CompeteAsync();
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }

            return _mapper.Map<ClassroomViewDto>(newClassroom);
        }

        public async Task<ClassroomViewDto> UpdateClassroom(Guid id, UpdateClassroomDto updateClassroomDto)
        {
            var classroom = await _unitOfWork.classroomRepository.GetById(id);
            if (classroom == null)
            {
                throw new BadHttpRequestException("Not found student");
            }
            try
            {
                classroom.Name = updateClassroomDto.Name;
                classroom.HomeroomTeacher = updateClassroomDto.HomeroomTeacher;
                int success = await _unitOfWork.CompeteAsync();
                return _mapper.Map<ClassroomViewDto>(classroom);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<ClassroomViewDto> DeleteClassroom(Guid id)
        {
            var classroom = await _unitOfWork.classroomRepository.GetById(id);
            if (classroom == null)
            {
                throw new BadHttpRequestException("Not found classroom");
            }
            await _unitOfWork.classroomRepository.Delete(id);
            await _unitOfWork.CompeteAsync();
            return _mapper.Map<ClassroomViewDto>(classroom);
        }

        public async Task<List<StudentViewDto>> GetAllStudentsInClass(Guid id)
        {
            var classroom = await _unitOfWork.classroomRepository.GetById(id);
            if (classroom == null)
            {
                throw new BadHttpRequestException("Not found classroom");
            }
            return await _mapper.ProjectTo<StudentViewDto>(_unitOfWork.classroomRepository.GetAllStudentsInClass(id)).ToListAsync();
        }

        public async Task<object> GetTopPointsStudentInClass(Guid id)
        {
            var classroom = await _unitOfWork.classroomRepository.GetById(id);
            if (classroom == null)
            {
                throw new BadHttpRequestException("Not found classroom");
            }
            return await _unitOfWork.classroomRepository.GetTopPointsStudentInClass(id).FirstOrDefaultAsync();
        }

        public Task<int> GetAverageInClass(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
