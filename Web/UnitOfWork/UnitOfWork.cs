using Web.Data;
using Web.Interfaces;
using Web.Repository;

namespace Web.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SchoolContext _dbContext;

        private StudentRepository _studentRepository = null!;
        private ClassroomRepository _classroomRepository = null!;
        private SubjectRepository _subjectRepository = null!;


        public UnitOfWork(SchoolContext dbContext)
        {
            _dbContext = dbContext;
        }

        public StudentRepository studentRepository
        {
            get
            {
                if ( _studentRepository == null )
                {
                    _studentRepository = new StudentRepository(_dbContext);
                }
                return _studentRepository;
            }
        }

        public ClassroomRepository classroomRepository
        {
            get
            {
                if (_classroomRepository == null)
                {
                    _classroomRepository = new ClassroomRepository(_dbContext);
                }
                return _classroomRepository;
            }
        }

        public SubjectRepository subjectRepository
        {
            get
            {
                if (_subjectRepository == null)
                {
                    _subjectRepository = new SubjectRepository(_dbContext);
                }
                return _subjectRepository;
            }
        }   

        public async Task<int> CompeteAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }
    }
}
