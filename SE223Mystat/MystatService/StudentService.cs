using Microsoft.Data.SqlClient;
using Mystat.Abstraction;
using Mystat.Models;
using MystatService.Interfaces;
using System.Data;


namespace MystatService
{
    public class StudentService : GenericRepository<Student>, IStudentService
    {
        public async Task AddNewStudentAsync(Student student) => await POSTAsyncProcedure("sp_addNewStudent", student.FirstName, student.LastName, student.Attends, student.AttendsOnline, student.Brilliants, student.Comment);

        public async Task DeleteManyStudentsAsync(params int[] ids)
        {
            foreach (var idToDelete in ids)
            {
                string sqlExpression = $"DELETE FROM Student WHERE Id ={idToDelete}";


                using (SqlConnection connection = new(HelperConfig.ConnectionString))
                {
                    try
                    {
                        SqlCommand command = new(sqlExpression, connection);
                        command.CommandType = CommandType.Text;

                        await connection.OpenAsync();
                        await command.ExecuteNonQueryAsync();
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                    finally
                    {
                        await connection.OpenAsync();
                    }
                }
            }

        }

        public async Task DeleteStudentAsync(int id) => await POSTAsyncProcedure("sp_deleteStudent", id);

        public async Task<List<Student>> GetAllStudentsAsync() => await GETAllAsyncProcedure("sp_getAllStudents");

        public async Task<Student> GetStudentByIdAsync(int id) => await GETAsyncProcedure("sp_getStudentById", id);

        public async Task UpdateStudentAsync(Student student) => await POSTAsyncProcedure("sp_updateStudent", student.Id, student.FirstName, student.LastName, student.RegisterDate, student.Attends, student.AttendsOnline, student.Brilliants, student.Comment);
    }
}