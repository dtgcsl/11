using Web.Contracts;
using Web.Data;
using Web.Entities;
using Web.Repository.Common;

namespace Web.Repository
{
    public class SubjectRepository : BaseRepository<Subject>, ISubjectRepository
    {
        public SubjectRepository(SchoolContext dbContext) : base(dbContext)
        {
        }

        

        public IQueryable<Subject> GetByName(string subjectName)
        {
            var obj = _dbContext.Set<Subject>().Where(s => s.Name == subjectName);
            if (obj == null)
            {
                throw new Exception("Not Found");
            }
            return obj;
        }
    }
}
