using Web.Repository;

namespace Web.Interfaces
{
    public interface IUnitOfWork
    {
        StudentRepository studentRepository { get; }

        ClassroomRepository classroomRepository { get; }

        SubjectRepository subjectRepository { get; }

        Task<int> CompeteAsync();
    }
}
