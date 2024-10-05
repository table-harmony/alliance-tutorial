using System.Data.SqlClient;
using System.Data;

namespace DataAccessLayer.Data {

    /// <summary>
    /// Provides helper methods for ADO.NET database operations.
    /// </summary>
    public class DatabaseContext(string connectionString) {
        private readonly string _connectionString = connectionString;

        /// <summary>
        /// Executes a SQL query and retrieves the result set as a <see cref="DataSet"/>.
        /// Supports both parameterized queries and stored procedures.
        /// </summary>
        /// <param name="query">The SQL query or stored procedure name to execute.</param>
        /// <param name="parameters">Optional array of <see cref="SqlParameter"/> objects for parameterized queries.</param>
        /// <param name="isStoredProcedure">Specifies whether the query is a stored procedure.</param>
        /// <returns>A <see cref="DataSet"/> containing the results of the query execution.</returns>

        public DataSet ExecuteQuery(string query, SqlParameter[]? parameters = null, bool isStoredProcedure = false) {
            using SqlConnection connection = new(_connectionString);
            connection.Open();

            using SqlCommand command = new(query, connection);

            if (isStoredProcedure)
                command.CommandType = CommandType.StoredProcedure;

            if (parameters != null)
                command.Parameters.AddRange(parameters);

            using SqlDataAdapter adapter = new(command);
            DataSet dataSet = new();
            adapter.Fill(dataSet);

            return dataSet;
        }

    }
}