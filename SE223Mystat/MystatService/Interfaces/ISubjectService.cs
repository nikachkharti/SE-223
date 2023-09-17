using Mystat.Models;

namespace MystatService.Interfaces
{
    public interface ISubjectService
    {
        Task<List<Subject>> GetAllSubjectsAsync();
        Task AddNewSubjectAsync(Subject subject);
        Task<Subject> GetSubjectByIdAsync(int id);
        Task UpdateSubjectAsync(Subject subject);
        Task DeleteSubjectAsync(int id);
    }
}
