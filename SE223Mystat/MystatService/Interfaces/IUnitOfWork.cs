namespace MystatService.Interfaces
{
    public interface IUnitOfWork
    {
        public IStudentService Student { get; }
        public ITeacherService Teacher { get; }
        public ISubjectService Subject { get; }
        public IGroupService Group { get; }
    }
}
