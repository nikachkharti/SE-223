using Mystat.Models;

namespace MystatService.Interfaces
{
    public interface IGroupService
    {
        Task AddGroupAsync(Group group);
        Task DeleteGroupAsync(string name);

        /// <summary>
        /// წაშალოს კონკრეტული სტუდენტი ჯგუფიდან
        /// </summary>
        /// <param name="studentId">წასაშლელი სტუდენტი</param>
        /// <returns>Task</returns>
        Task DeleteStudentForGroupAsync(int studentId);

        /// <summary>
        /// შეცვალოს არსებული სტუდენტი სხვა სტუდენტით
        /// </summary>
        /// <param name="existingStudentId">არსებუული</param>
        /// <param name="newStudentId">სხვა</param>
        /// <returns>Task</returns>
        Task UpdateStudentForGroupAsync(int existingStudentId, int newStudentId);

        /// <summary>
        /// შეიცავლოს არსებული მასწავლებელი სხვა მასწავლებლით
        /// </summary>
        /// <param name="existingTeacherId">არსებული</param>
        /// <param name="newTeacherId">ახალი</param>
        /// <returns>Task</returns>
        Task UpdateTeacherForGroup(int existingTeacherId, int newTeacherId);

        /// <summary>
        /// შეიცავლოს საგანი მასწავლებელი სხვა საგნით
        /// </summary>
        /// <param name="existingTeacherId">არსებული</param>
        /// <param name="newTeacherId">ახალი</param>
        /// <returns>Task</returns>
        Task UpdateSubjectForGroup(int existingSubjectId, int newSubjectId);
    }
}
