using Mystat.Models;

namespace MystatService.Interfaces
{
    public interface ITeacherService
    {
        Task<List<Teacher>> GetAllTeachersAsync();
        Task AddNewTeacherAsync(Teacher teacher);
        Task<Teacher> GetTeacherByIdAsync(int id);
        Task UpdateTeacherAsync(Teacher teacher);
        Task DeleteTeacherAsync(int id);
    }
}
