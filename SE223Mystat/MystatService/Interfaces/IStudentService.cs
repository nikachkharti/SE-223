using Mystat.Abstraction.Interfaces;
using Mystat.Models;

namespace MystatService.Interfaces
{
    public interface IStudentService
    {
        Task<List<Student>> GetAllStudentsAsync();
        Task AddNewStudentAsync(Student student);
        Task<Student> GetStudentByIdAsync(int id);
        Task UpdateStudentAsync(Student student);
        Task DeleteStudentAsync(int id);
        Task DeleteManyStudentsAsync(params int[] ids);
    }
}
