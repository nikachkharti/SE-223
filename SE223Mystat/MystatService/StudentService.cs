using Microsoft.Data.SqlClient;
using Mystat.Models;
using MystatService.Interfaces;
using System.Data;


namespace MystatService
{
    public class StudentService : IStudentService
    {
        public async Task AddNewStudentAsync(Student student)
        {
            const string sqlExpression = "sp_addNewStudent";

            using (SqlConnection connection = new(HelperConfig.ConnectionString))
            {
                try
                {
                    SqlCommand command = new(sqlExpression, connection);
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("firstName", student.FirstName);
                    command.Parameters.AddWithValue("lastName", student.LastName);
                    command.Parameters.AddWithValue("attends", student.Attends);
                    command.Parameters.AddWithValue("attendsOnline", student.AttendsOnline);
                    command.Parameters.AddWithValue("brilliants", student.Brilliants);
                    command.Parameters.AddWithValue("comment", student.Comment);

                    connection.Open();
                    await command.ExecuteNonQueryAsync();
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    connection.Close();
                }
            }
        }

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

        public async Task DeleteStudentAsync(int id)
        {
            const string sqlExpression = "sp_deleteStudent";

            using (SqlConnection connection = new(HelperConfig.ConnectionString))
            {
                try
                {
                    SqlCommand command = new(sqlExpression, connection);
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("id", id);

                    connection.Open();
                    await command.ExecuteNonQueryAsync();
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    connection.Close();
                }
            }

        }

        public async Task<List<Student>> GetAllStudentsAsync()
        {
            List<Student> result = new();
            const string sqlExpression = "sp_getAllStudents";

            using (SqlConnection connection = new(HelperConfig.ConnectionString))
            {
                try
                {
                    SqlCommand command = new(sqlExpression, connection);
                    command.CommandType = CommandType.StoredProcedure;

                    connection.Open();
                    SqlDataReader reader = await command.ExecuteReaderAsync();

                    if (reader.HasRows)
                    {
                        while (await reader.ReadAsync())
                        {
                            result.Add(new Student
                            {
                                Id = reader.GetInt32(0),
                                FirstName = !reader.IsDBNull(1) ? reader.GetString(1) : string.Empty,
                                LastName = !reader.IsDBNull(2) ? reader.GetString(2) : string.Empty,
                                RegisterDate = reader.GetDateTime(3),
                                FullName = !reader.IsDBNull(4) ? reader.GetString(4) : string.Empty,
                                Attends = reader.GetBoolean(5),
                                AttendsOnline = reader.GetBoolean(6),
                                Brilliants = reader.GetInt32(7),
                                Comment = !reader.IsDBNull(8) ? reader.GetString(8) : string.Empty
                            });
                        }
                    }
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    connection.Close();
                }
            }


            return result;
        }

        public async Task<Student> GetStudentByIdAsync(int id)
        {
            Student result = new();
            const string sqlExpression = "sp_getStudentById";

            using (SqlConnection connection = new(HelperConfig.ConnectionString))
            {
                try
                {
                    SqlCommand command = new(sqlExpression, connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("id", id);

                    connection.Open();
                    SqlDataReader reader = await command.ExecuteReaderAsync();

                    if (reader.HasRows)
                    {
                        while (await reader.ReadAsync())
                        {
                            result.Id = reader.GetInt32(0);
                            result.FirstName = !reader.IsDBNull(1) ? reader.GetString(1) : string.Empty;
                            result.LastName = !reader.IsDBNull(2) ? reader.GetString(2) : string.Empty;
                            result.RegisterDate = reader.GetDateTime(3);
                            result.FullName = !reader.IsDBNull(4) ? reader.GetString(4) : string.Empty;
                            result.Attends = reader.GetBoolean(5);
                            result.AttendsOnline = reader.GetBoolean(6);
                            result.Brilliants = reader.GetInt32(7);
                            result.Comment = !reader.IsDBNull(8) ? reader.GetString(8) : string.Empty;
                        }
                    }
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    connection.Close();
                }

                return result;
            }


        }

        public async Task UpdateStudentAsync(Student student)
        {
            const string sqlExpression = "sp_updateStudent";

            using (SqlConnection connection = new(HelperConfig.ConnectionString))
            {
                try
                {
                    SqlCommand command = new(sqlExpression, connection);
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("firstName", student.FirstName);
                    command.Parameters.AddWithValue("lastName", student.LastName);
                    command.Parameters.AddWithValue("registerDate", student.RegisterDate);
                    command.Parameters.AddWithValue("attends", student.Attends);
                    command.Parameters.AddWithValue("attendsOnline", student.AttendsOnline);
                    command.Parameters.AddWithValue("brilliants", student.Brilliants);
                    command.Parameters.AddWithValue("comment", student.Comment);
                    command.Parameters.AddWithValue("id", student.Id);

                    connection.Open();
                    await command.ExecuteNonQueryAsync();
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    connection.Close();
                }
            }
        }
    }
}