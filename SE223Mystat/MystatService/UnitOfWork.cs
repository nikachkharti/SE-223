using MystatService.Interfaces;

namespace MystatService
{
    public class UnitOfWork : IUnitOfWork
    {
        public IStudentService Student { get; private set; }
        public ITeacherService Teacher { get; private set; }
        public ISubjectService Subject { get; private set; }
        public IGroupService Group { get; private set; }

        public UnitOfWork()
        {
            Student = new StudentService();
            Teacher = new TeacherService();
            Subject = new SubjectService();
            Group = new GroupService();
        }
    }
}
