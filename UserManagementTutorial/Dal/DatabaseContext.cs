using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Threading.Tasks;

namespace SendersTutorial.Utils.Database {

    /// <summary>
    /// Represents a database command with its SQL text, parameters, and command type.
    /// </summary>
    public class DatabaseCommand {
        // SQL command text
        public string CommandText { get; set; }

        // SQL command parameters
        public SqlParameter[] Parameters { get; set; } 

        // Type of the SQL command (e.g., Text, StoredProcedure, etc.).
        public CommandType CommandType { get; set; } = CommandType.Text;
    } 

    /// <summary>
    /// Represents a context for interacting with the database, encapsulating methods for querying and executing commands.
    /// </summary>
    public class DatabaseContext {
        private readonly string _connectionString;

        public DatabaseContext() {
            _connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        /// <summary>
        /// Executes a SQL query that returns a result set (e.g., SELECT query) and returns it as a DataSet.
        /// </summary>
        /// <param name="dbCommand">The <see cref="DatabaseCommand"/> containing the SQL text and parameters to execute.</param>
        /// <returns>A <see cref="DataSet"/> containing the results of the query.</returns>
        public DataSet ExecuteQuery(DatabaseCommand dbCommand) {
            using (var connection = new SqlConnection(_connectionString)) {
                connection.Open();

                using (var sqlCommand = new SqlCommand(dbCommand.CommandText, connection)) {
                    sqlCommand.CommandType = dbCommand.CommandType;

                    if (dbCommand.Parameters != null) {
                        sqlCommand.Parameters.AddRange(dbCommand.Parameters);
                    }

                    using (var adapter = new SqlDataAdapter(sqlCommand)) {
                        var dataSet = new DataSet();
                        adapter.Fill(dataSet);
                        return dataSet;
                    }
                }
            }
        }

        /// <summary>
        /// Executes a SQL query that does not return a result set (e.g., INSERT, UPDATE, DELETE) and returns the number of affected rows.
        /// </summary>
        /// <param name="dbCommand">The <see cref="DatabaseCommand"/> containing the SQL text and parameters to execute.</param>
        /// <returns>The number of rows affected by the SQL query.</returns>
        public int ExecuteNonQuery(DatabaseCommand dbCommand) {
            using (var connection = new SqlConnection(_connectionString)) {
                connection.Open();

                using (var sqlCommand = new SqlCommand(dbCommand.CommandText, connection)) {
                    sqlCommand.CommandType = dbCommand.CommandType;

                    if (dbCommand.Parameters != null) {
                        sqlCommand.Parameters.AddRange(dbCommand.Parameters);
                    }

                    return sqlCommand.ExecuteNonQuery();
                }
            }
        }
    }
}
