using Microsoft.EntityFrameworkCore;
using Web.Contracts;
using Web.Data;
using Web.Entities;
namespace Web.Repository
{
    public class FacultyRepository :  IFacultyRepository
    {
        public SchoolContext _context;
        public FacultyRepository(SchoolContext context)
        {
            _context = context;
        }

        public void Add(Faculty faculty)
        {
            try
            {
                _context.Faculties.Add(faculty);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Delete(Guid id)
        {
            var obj = _context.Set<Faculty>().Where(f => f.Id == id).FirstOrDefault();
            if (obj == null)
            {
                throw new Exception("Not Found");
            }
            _context.Set<Faculty>().Remove(obj);
        }

        public IQueryable<Faculty> GetAll()
        {
            return _context.Set<Faculty>();
        }

        public IQueryable<Faculty> GetById(Guid id)
        {
            var obj = _context.Set<Faculty>().Where(s => s.Id == id);
            if (obj == null)
            {
                throw new Exception("Not Found");
            }
            return obj;
        }

        

        public void Update(Guid id, Faculty faculty)
        {
            var obj = _context.Set<Faculty>().Where(s => s.Id == id).FirstOrDefault();
            if (obj == null)
            {
                throw new Exception("Not Found");
            }
            obj.Name = faculty.Name;
        }

        public void Save()
        {
            throw new NotImplementedException();
        }
    }
}
