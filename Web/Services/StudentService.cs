using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Web.Entities;
using Web.Interfaces;
using Web.Models.Student;

namespace Web.Services
{
    public class StudentService : IStudentService
    {
        //private readonly IStudentRepository _studentRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public StudentService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<List<StudentViewDto>> GetAllStudents()
        {
            return await _mapper.ProjectTo<StudentViewDto>(_unitOfWork.studentRepository.GetAll()).ToListAsync();
        }

        public async Task<StudentDto> GetStudentById(Guid id)
        {
            var student = await _unitOfWork.studentRepository.GetById(id);
            if (student == null)
            {
                throw new BadHttpRequestException("Not found student");
            }
            return _mapper.Map<StudentDto>(student);
        }

        public async Task<List<StudentViewDto>> GetStudentByName(string name)
        {
            var allStudent = await _mapper.ProjectTo<StudentViewDto>(_unitOfWork.studentRepository.GetByName(name)).ToListAsync();
            if (allStudent.Count() == 0)
            {
                throw new BadHttpRequestException("Not found student");
            }
            return allStudent;
        }

        public async Task<StudentViewDto> AddStudent(CreateStudentDto createStudentDto)
        {
            var newStudent = new Student
            {
                Id = Guid.NewGuid(),
                FullName = createStudentDto.FullName,
                Gender = createStudentDto.Gender,
                Address = createStudentDto.Address,
                Email = createStudentDto.Email,
            };
           
            await _unitOfWork.studentRepository.Add(newStudent);
            await _unitOfWork.CompeteAsync();

            return _mapper.Map<StudentViewDto>(newStudent);
        }

        public async Task<StudentViewDto> UpdateStudent(Guid id, UpdateStudentDto updateStudentDto)
        {

            var student = await _unitOfWork.studentRepository.GetById(id);
            if (student == null)
            {
                throw new BadHttpRequestException("Not found student");
            }
            try
            {
                student.Email = updateStudentDto.Email;
                student.FullName = updateStudentDto.FullName;
                student.Gender = updateStudentDto.Gender;
                student.Address = updateStudentDto.Address;
                int success = await _unitOfWork.CompeteAsync();
                return _mapper.Map<StudentViewDto>(student);
            }
            catch (Exception e)
            { 
                throw new Exception(e.Message);
            }
            
        }

        public async Task<StudentViewDto> DeleteStudent(Guid id)
        {
            var student  = await _unitOfWork.studentRepository.GetById(id);
            if (student == null)
            {
                throw new BadHttpRequestException("Not found student");
            }
            await _unitOfWork.studentRepository.Delete(id);
            await _unitOfWork.CompeteAsync();
            return _mapper.Map<StudentViewDto>(student);
        }
    }
}
