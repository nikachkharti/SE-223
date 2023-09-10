using MystatService.Interfaces;

namespace MystatService
{
    public class UnitOfWork : IUnitOfWork
    {
        public IStudentService Student { get; private set; }

        public UnitOfWork()
        {
            Student = new StudentService();
        }
    }
}
