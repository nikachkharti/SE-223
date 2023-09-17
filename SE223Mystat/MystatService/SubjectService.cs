using Microsoft.Data.SqlClient;
using Mystat.Models;
using MystatService.Interfaces;
using System.Data;

namespace MystatService
{
    public class SubjectService : ISubjectService
    {
        public async Task AddNewSubjectAsync(Subject subject)
        {
            const string sqlExpression = "sp_addNewSubject";

            using (SqlConnection connection = new(HelperConfig.ConnectionString))
            {
                try
                {
                    SqlCommand command = new(sqlExpression, connection);
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("title", subject.Title);

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

        public async Task DeleteSubjectAsync(int id)
        {
            const string sqlExpression = "sp_deleteSubject";

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

        public async Task<List<Subject>> GetAllSubjectsAsync()
        {
            List<Subject> result = new();
            const string sqlExpression = "sp_getAllSubjects";

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
                            result.Add(new Subject
                            {
                                Id = reader.GetInt32(0),
                                Title = !reader.IsDBNull(1) ? reader.GetString(1) : string.Empty,
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

        public async Task<Subject> GetSubjectByIdAsync(int id)
        {
            Subject result = new();
            const string sqlExpression = "sp_getSubjectById";

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
                            result.Title = !reader.IsDBNull(1) ? reader.GetString(1) : string.Empty;
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

        public async Task UpdateSubjectAsync(Subject subject)
        {
            const string sqlExpression = "sp_updateSubject";

            using (SqlConnection connection = new(HelperConfig.ConnectionString))
            {
                try
                {
                    SqlCommand command = new(sqlExpression, connection);
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("title", subject.Title);
                    command.Parameters.AddWithValue("id", subject.Id);

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
