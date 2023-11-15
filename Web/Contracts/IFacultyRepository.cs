using System.Collections.Generic;
using Web.Entities;

namespace Web.Contracts
{
    public interface IFacultyRepository
    {
        public IQueryable<Faculty> GetAll();
        public IQueryable<Faculty> GetById(Guid id);
        public void Add(Faculty faculty);
        public void Update(Guid id, Faculty faculty);
        public void Delete(Guid id);
        public void Save();
    }
}
