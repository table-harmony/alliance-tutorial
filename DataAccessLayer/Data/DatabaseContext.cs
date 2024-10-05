using System.Data.SqlClient;
using System.Data;

namespace DataAccessLayer.Data {

    /// <summary>
    /// Provides helper methods for ADO.NET database operations.
    /// </summary>
    public class DatabaseContext {
        /// <summary>
        /// Establishes a connection to the database.
        /// </summary>
        /// <returns>An open SqlConnection to the database.</returns>
        private static SqlConnection GetConnection() {
            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            SqlConnection conn = new(connectionString);
            return conn;
        }

        /// <summary>
        /// Executes a SQL query and returns the results as a DataSet.
        /// </summary>
        /// <param name="query">The SQL query to execute.</param>
        /// <param name="parameters">Optional array of SqlParameters to use with the query.</param>
        /// <param name="isStoredProcedure">A boolean stating if the query is a stored procedure</param>
        /// <returns>A DataSet containing the query results.</returns>
        public static DataSet ExecuteQuery(string query,
                                            SqlParameter[] parameters = null,
                                            bool isStoredProcedure = false) {
            using (var connection = GetConnection()) {
                connection.Open();

                using (var command = new SqlCommand(query, connection)) {
                    if (isStoredProcedure) 
                        command.CommandType = CommandType.StoredProcedure;

                    if (parameters != null) {
                        command.Parameters.AddRange(parameters);
                    }

                    var dataSet = new DataSet();
                    using (var adapter = new SqlDataAdapter(command)) {
                        adapter.Fill(dataSet);
                    }

                    return dataSet;
                }
            }
        }
    }
}