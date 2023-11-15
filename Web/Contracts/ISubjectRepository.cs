using Web.Entities;

namespace Web.Contracts
{
    public interface ISubjectRepository
    {
        public IQueryable<Subject> GetAll();
        public Task<Subject> GetById(Guid id);
        public IQueryable<Subject> GetByName(string subjectName);

        public Task Add(Subject subject);
        public Task Update(Subject subject);
        public Task Delete(Guid id);
    }
}
