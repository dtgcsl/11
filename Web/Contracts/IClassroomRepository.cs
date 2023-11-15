using Web.Entities;

namespace Web.Contracts
{
    public interface IClassroomRepository
    {
        public IQueryable<Classroom> GetAll();
        public Task<Classroom> GetById(Guid id);
        public Task Add(Classroom classroom);
        public Task Update(Classroom classroom);
        public Task Delete(Guid id);
        public IQueryable<Student> GetAllStudentsInClass(Guid id);
        public IQueryable<Object> GetTopPointsStudentInClass(Guid id);
        public IQueryable<int> GetAverageInClass(Guid id);
    }
}
