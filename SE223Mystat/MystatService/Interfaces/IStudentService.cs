using Mystat.Models;

namespace MystatService.Interfaces
{
    public interface IStudentService
    {
        List<Student> GetAllStudents();
        void AddNewStudent(Student student);
        Student GetStudentById(int id);
        void UpdateStudent(Student student);
        void DeleteStudent(int id);
    }
}
