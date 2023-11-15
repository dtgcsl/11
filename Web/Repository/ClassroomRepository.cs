using Microsoft.EntityFrameworkCore;
using Web.Contracts;
using Web.Data;
using Web.Entities;
using Web.Models.Student;
using Web.Repository.Common;

namespace Web.Repository
{
    public class ClassroomRepository : BaseRepository<Classroom>,  IClassroomRepository
    {
        /*+ lấy ra tất cả student học trong cùng 1 lớp 
	    + lấy ra student trong lop cntt5 có điểm cao nhất
	    + lấy điểm trung bình của lop cntt1*/
        public ClassroomRepository(SchoolContext dbContext) : base(dbContext)
        {
        }

        public  IQueryable<Student> GetAllStudentsInClass(Guid id)
        {
            var obj = _dbContext.Set<Student>().Where(s => s.ClassroomId == id);
            return obj;
        }

        public IQueryable<int> GetAverageInClass(Guid id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Object> GetTopPointsStudentInClass(Guid id)
        {
            var obj = _dbContext.Set<Student>()
                .Where(s => s.ClassroomId == id)
                .Select(s => new
                {
                    Student = s,
                    Point = s.Results.OrderBy(r => r.Point).LastOrDefault().Point
                })
                //.OrderByDescending(r => r.Point);
                ;
            var test = obj.FirstOrDefault();
            if (obj.FirstOrDefault() == null)
            {
                throw new Exception("Not found");
            }
            return obj;
        }
    }
}
