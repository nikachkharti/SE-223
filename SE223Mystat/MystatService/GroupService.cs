using Mystat.Models;
using MystatService.Interfaces;

namespace MystatService
{
    public class GroupService : IGroupService
    {
        public Task AddGroupAsync(Group group)
        {
            throw new NotImplementedException();
        }

        public Task DeleteGroupAsync(string name)
        {
            throw new NotImplementedException();
        }

        public Task DeleteStudentForGroupAsync(int studentId)
        {
            throw new NotImplementedException();
        }

        public Task UpdateStudentForGroupAsync(int existingStudentId, int newStudentId)
        {
            throw new NotImplementedException();
        }

        public Task UpdateSubjectForGroup(int existingSubjectId, int newSubjectId)
        {
            throw new NotImplementedException();
        }

        public Task UpdateTeacherForGroup(int existingTeacherId, int newTeacherId)
        {
            throw new NotImplementedException();
        }
    }
}
