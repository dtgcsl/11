using Web.Contracts;
using Web.Data;
using Web.Entities;
using Web.Repository.Common;

namespace Web.Repository
{
    public class StudentRepository : BaseRepository<Student>, IStudentRepository
    {
        public StudentRepository(SchoolContext dbContext) : base(dbContext)
        {
        }

        public IQueryable<Student> GetByName(string studentName)
        {
            var obj = _dbContext.Set<Student>().Where(s => s.FullName == studentName);
            if (obj == null)
            {
                throw new Exception("Not Found");
            }
            return obj;
        }

        

        /*public IQueryable<Student> GetAll()
        {
            return _context.Set<Student>();
        }

        public IQueryable<Student> GetById(int id)
        {
            var obj = _context.Set<Student>().Where(s => s.Id == id);
            if (obj == null)
            {
                throw new Exception("Not Found");
            }
            return obj;
        }

        public async Task Add(Student student) {
            await _context.Set<Student>().AddAsync(student);
            await this.Save();
        }

        public async Task Update(int id, Student student)
        {
            var obj = _context.Set<Student>().Where(s => s.Id == id).FirstOrDefault();
            if (obj == null)
            {
                throw new Exception("Not Found");
            }
            obj.Email = student.Email;
            obj.Address = student.Address;
            obj.FullName = student.FullName;
            obj.ClassroomId = student.ClassroomId;
            obj.Gender = student.Gender;
        }

        public async Task Delete(int id)
        {
            var obj = _context.Set<Student>().Where(s => s.Id == id).FirstOrDefault();
            if (obj == null)
            {
                throw new Exception("Not Found");
            }
            _context.Set<Student>().Remove(obj);
        }*/
        //public IQueryable<Student> GetByClass(string className)
        //{
        //    var obj = _context.Set<Student>().Where(s => s.Classroom.Name == className);
        //    return obj;
        //}
        //public IQueryable<Student> GetTopInClass(string className)
        //{
        //    var obj = _context.Set<Student>()
        //        .Where(s => s.Classroom.Name == className).Include(s=> s.Results).OrderByDescending(s => s.Results.Select(r => r.Point).FirstOrDefault());
        //    if (obj == null)
        //    {
        //        throw new Exception("Not Found");
        //    }
        //    return obj;
        //}
        //public async Task<double> GetAverageOfStudent(int id)
        //{
        //    var avg = 0.0;
        //    var total = 0.0;

        //    var student = _context.Set<Student>()
        //        .Where(s => s.Id == id)
        //        .Include(s => s.Results)
        //        .FirstOrDefaultAsync();
        //    if (student == null )
        //    {
        //        throw new Exception("Not Found");
        //    }

        //    if (student.Result == null)
        //    {
        //        throw new Exception("Not Found");
        //    }

        //    var results = student.Result.ToList();

        //    foreach (var result in results)
        //    {
        //        var point = result.Point;
        //        total += result.Point;
        //    }

        //    avg = total / results.Count;

        //    return avg;
        //}

        //public async Task<double> GetAverageInClass(string className)
        //{
        //    var avg = 0.0;
        //    var total = 0.0;

        //    var students = await _context.Set<Student>()
        //        .Where(s => s.Classroom.Name == className)
        //        .ToListAsync();

        //    if (students.Count == 0)
        //    {
        //        throw new Exception("Not Found");
        //    }

        //    foreach (var student in students)
        //    {
        //        total += GetAverageOfStudent(student.Id, avg);
        //    }

        //    avg = total / students.Count;

        //    return avg;
        //}

    }
}
