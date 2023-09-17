using Microsoft.Data.SqlClient;
using Mystat.Models;
using MystatService.Interfaces;
using System.Data;
using System.Net.NetworkInformation;

namespace MystatService
{
    public class TeacherService : ITeacherService
    {
        public async Task AddNewTeacherAsync(Teacher teacher)
        {
            const string sqlExpression = "sp_addNewTeacher";

            using (SqlConnection connection = new(HelperConfig.ConnectionString))
            {
                try
                {
                    SqlCommand command = new(sqlExpression, connection);
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("firstName", teacher.FirstName);
                    command.Parameters.AddWithValue("lastName", teacher.LastName);
                    command.Parameters.AddWithValue("pin", teacher.Pin);
                    command.Parameters.AddWithValue("phoneNumber", teacher.PhoneNumber);
                    command.Parameters.AddWithValue("email", teacher.Email);

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

        public async Task DeleteTeacherAsync(int id)
        {
            const string sqlExpression = "sp_deleteTeacher";

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

        public async Task<List<Teacher>> GetAllTeachersAsync()
        {
            List<Teacher> result = new();
            const string sqlExpression = "sp_getAllTeachers";

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
                            result.Add(new Teacher
                            {
                                Id = reader.GetInt32(0),
                                FirstName = !reader.IsDBNull(1) ? reader.GetString(1) : string.Empty,
                                LastName = !reader.IsDBNull(2) ? reader.GetString(2) : string.Empty,
                                Pin = !reader.IsDBNull(3) ? reader.GetString(3) : string.Empty,
                                PhoneNumber = !reader.IsDBNull(4) ? reader.GetString(4) : string.Empty,
                                Email = !reader.IsDBNull(5) ? reader.GetString(5) : string.Empty
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

        public async Task<Teacher> GetTeacherByIdAsync(int id)
        {
            Teacher result = new();
            const string sqlExpression = "sp_getTeacherById";

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
                            result.Pin = !reader.IsDBNull(3) ? reader.GetString(3) : string.Empty;
                            result.PhoneNumber = !reader.IsDBNull(4) ? reader.GetString(4) : string.Empty;
                            result.Email = !reader.IsDBNull(5) ? reader.GetString(5) : string.Empty;
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

        public async Task UpdateTeacherAsync(Teacher teacher)
        {
            const string sqlExpression = "sp_updateTeacher";

            using (SqlConnection connection = new(HelperConfig.ConnectionString))
            {
                try
                {
                    SqlCommand command = new(sqlExpression, connection);
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("firstName", teacher.FirstName);
                    command.Parameters.AddWithValue("lastName", teacher.LastName);
                    command.Parameters.AddWithValue("pin", teacher.Pin);
                    command.Parameters.AddWithValue("phoneNumber", teacher.PhoneNumber);
                    command.Parameters.AddWithValue("email", teacher.Email);
                    command.Parameters.AddWithValue("id", teacher.Id);

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
