using System;
using System.Data;
using System.Data.SqlClient;

namespace ClassLibTeam14.Data.Framework
{
    abstract class SqlServer
    {
        // Since connections are generally not thread-safe, create a new connection in each method
        protected SqlConnection CreateConnection()
        {
            return new SqlConnection(Settings.GetConnectionString());
        }

        protected SelectResult Select(SqlCommand selectCommand)
        {
            var result = new SelectResult();

            using (var connection = CreateConnection())
            {
                try
                {
                    selectCommand.Connection = connection;
                    connection.Open();

                    using (var adapter = new SqlDataAdapter(selectCommand))
                    {
                        result.DataTable = new DataTable();
                        adapter.Fill(result.DataTable);
                    }

                    result.Succeeded = true;
                }
                catch (Exception ex)
                {
                    result.AddError(ex.Message);
                }
            }

            return result;
        }

        protected SelectResult Select(string tableName)
        {
            if (string.IsNullOrWhiteSpace(tableName))
            {
                throw new ArgumentException("Table name must not be empty.");
            }

            var command = new SqlCommand($"SELECT * FROM {tableName}");
            return Select(command);
        }

        protected InsertResult InsertRecord(SqlCommand insertCommand)
        {
            var result = new InsertResult();

            using (var connection = CreateConnection())
            {
                try
                {
                    insertCommand.Connection = connection;
                    connection.Open();

                    insertCommand.CommandText += " SET @new_id = SCOPE_IDENTITY();";
                    insertCommand.Parameters.Add("@new_id", SqlDbType.Int).Direction = ParameterDirection.Output;

                    insertCommand.ExecuteNonQuery();

                    var newId = Convert.ToInt32(insertCommand.Parameters["@new_id"].Value);
                    result.NewId = newId;
                    result.Succeeded = true;
                }
                catch (Exception ex)
                {
                    // Preserve the original stack trace when rethrowing exceptions
                    result.Succeeded = false;
                    result.AddError(ex.Message);
                }
            }

            return result;
        }
    }
}
