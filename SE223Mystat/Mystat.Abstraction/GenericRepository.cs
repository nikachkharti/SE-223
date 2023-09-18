using Microsoft.Data.SqlClient;
using Mystat.Abstraction.Interfaces;
using System.Data;

namespace Mystat.Abstraction
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class, new()
    {
        public async Task<List<T>> GETAllAsyncProcedure(string procedure, params object[] parameters)
        {
            if (string.IsNullOrWhiteSpace(procedure))
                throw new ArgumentException($"'{nameof(procedure)}' cannot be null or whitespace.", nameof(procedure));

            List<T> result = new();

            using (SqlConnection connection = new(HelperConfig.ConnectionString))
            {
                try
                {
                    SqlCommand command = new(procedure, connection);
                    command.CommandType = CommandType.StoredProcedure;


                    if (parameters.Length != 0)
                    {
                        for (int i = 0; i < parameters.Length; i++)
                        {
                            string parameterName = $"param{i}";
                            command.Parameters.AddWithValue(parameterName, parameters[i]);
                        }
                    }


                    await connection.OpenAsync();
                    var reader = await command.ExecuteReaderAsync();

                    if (reader.HasRows)
                    {
                        var properties = typeof(T).GetProperties();

                        while (await reader.ReadAsync())
                        {
                            T item = new();

                            foreach (var property in properties)
                            {
                                if (!reader.IsDBNull(reader.GetOrdinal(property.Name)))
                                {
                                    var value = reader[property.Name];
                                    property.SetValue(item, value);
                                }
                            }

                            result.Add(item);
                        }
                    }

                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    await connection.CloseAsync();
                }
            }


            return result;
        }

        public async Task<List<T>> GETAllAsyncQuery(string query)
        {
            if (string.IsNullOrWhiteSpace(query))
                throw new ArgumentException($"'{nameof(query)}' cannot be null or whitespace.", nameof(query));

            List<T> result = new();

            using (SqlConnection connection = new(HelperConfig.ConnectionString))
            {
                try
                {
                    SqlCommand command = new(query, connection);
                    command.CommandType = CommandType.Text;


                    await connection.OpenAsync();
                    var reader = await command.ExecuteReaderAsync();

                    if (reader.HasRows)
                    {
                        var properties = typeof(T).GetProperties();

                        while (await reader.ReadAsync())
                        {
                            T item = new();

                            foreach (var property in properties)
                            {
                                if (!reader.IsDBNull(reader.GetOrdinal(property.Name)))
                                {
                                    var value = reader[property.Name];
                                    property.SetValue(item, value);
                                }
                            }

                            result.Add(item);
                        }
                    }

                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    await connection.CloseAsync();
                }
            }


            return result;
        }

        public async Task<T> GETAsyncProcedure(string procedure, params object[] parameters)
        {
            if (string.IsNullOrWhiteSpace(procedure))
                throw new ArgumentException($"'{nameof(procedure)}' cannot be null or whitespace.", nameof(procedure));

            T result = new();

            using (SqlConnection connection = new(HelperConfig.ConnectionString))
            {
                try
                {
                    SqlCommand command = new(procedure, connection);
                    command.CommandType = CommandType.StoredProcedure;


                    if (parameters.Length != 0)
                    {
                        for (int i = 0; i < parameters.Length; i++)
                        {
                            string parameterName = $"param{i}";
                            command.Parameters.AddWithValue(parameterName, parameters[i]);
                        }
                    }


                    await connection.OpenAsync();
                    var reader = await command.ExecuteReaderAsync();

                    if (reader.HasRows)
                    {
                        var properties = typeof(T).GetProperties();

                        while (await reader.ReadAsync())
                        {

                            foreach (var property in properties)
                            {
                                if (!reader.IsDBNull(reader.GetOrdinal(property.Name)))
                                {
                                    var value = reader[property.Name];
                                    property.SetValue(result, value);
                                }
                            }
                        }
                    }

                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    await connection.CloseAsync();
                }
            }

            return result;
        }

        public async Task<T> GETAsyncQuery(string query)
        {
            if (string.IsNullOrWhiteSpace(query))
                throw new ArgumentException($"'{nameof(query)}' cannot be null or whitespace.", nameof(query));

            T result = new();

            using (SqlConnection connection = new(HelperConfig.ConnectionString))
            {
                try
                {
                    SqlCommand command = new(query, connection);
                    command.CommandType = CommandType.Text;

                    await connection.OpenAsync();
                    var reader = await command.ExecuteReaderAsync();

                    if (reader.HasRows)
                    {
                        var properties = typeof(T).GetProperties();

                        while (await reader.ReadAsync())
                        {

                            foreach (var property in properties)
                            {
                                if (!reader.IsDBNull(reader.GetOrdinal(property.Name)))
                                {
                                    var value = reader[property.Name];
                                    property.SetValue(result, value);
                                }
                            }
                        }
                    }
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    await connection.CloseAsync();
                }
            }

            return result;
        }

        public async Task POSTAsyncProcedure(string procedure, params object[] parameters)
        {
            if (string.IsNullOrWhiteSpace(procedure))
                throw new ArgumentException($"'{nameof(procedure)}' cannot be null or whitespace.", nameof(procedure));

            string sqlExpression = procedure;
            using (SqlConnection connection = new(HelperConfig.ConnectionString))
            {
                try
                {
                    SqlCommand command = new(sqlExpression, connection);
                    command.CommandType = CommandType.StoredProcedure;

                    if (parameters.Length != 0)
                    {
                        for (int i = 0; i < parameters.Length; i++)
                        {
                            string parameterName = $"param{i}";
                            command.Parameters.AddWithValue(parameterName, parameters[i]);
                        }
                    }

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

        public async Task POSTAsyncQuery(string query)
        {
            if (string.IsNullOrWhiteSpace(query))
                throw new ArgumentException($"'{nameof(query)}' cannot be null or whitespace.", nameof(query));

            string sqlExpression = query;
            using (SqlConnection connection = new(HelperConfig.ConnectionString))
            {
                try
                {
                    SqlCommand command = new(sqlExpression, connection);
                    command.CommandType = CommandType.Text;

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
