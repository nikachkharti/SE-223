using Microsoft.Data.SqlClient;
using Mystat.Models;
using MystatService.Interfaces;
using System.Data;


namespace MystatService
{
    public class StudentService : IStudentService
    {
        public void AddNewStudent(Student student)
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
                    command.ExecuteNonQuery();
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

        public void DeleteStudent(int id)
        {
            throw new NotImplementedException();
        }

        public List<Student> GetAllStudents()
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
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
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

        public Student GetStudentById(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateStudent(Student student)
        {
            throw new NotImplementedException();
        }
    }
}
