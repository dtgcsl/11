using Web.Entities;

namespace Web.Contracts
{
    public interface IStudentRepository
    {
        public IQueryable<Student> GetAll();
        public Task<Student> GetById(Guid id);
        public IQueryable<Student> GetByName(string studentName);

        public Task Add(Student student);
        public Task Update(Student student);
        public Task Delete(Guid id);


    }
}
