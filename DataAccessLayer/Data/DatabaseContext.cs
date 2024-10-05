using System.Data.SqlClient;
using System.Data;
using System.Web;

namespace DataAccessLayer.Data {

    /// <summary>
    /// Provides helper methods for ADO.NET database operations.
    /// </summary>
    public class DatabaseContext {
        private readonly string databaseName = "Database1.mdf";
        
        /// <summary>
        /// Establishes a connection to the database.
        /// </summary>
        /// <returns>An open SqlConnection to the database.</returns>
        public static SqlConnection GetConnection() {
            string path = HttpContext.Current.Server.MapPath("/App_Data/" + databaseName);
            string connString = @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = " + path + "; Integrated Security = True";

            SqlConnection conn = new SqlConnection(connString);
            return conn;
        }

        /// <summary>
        /// Executes a SQL query and returns the results as a DataSet.
        /// </summary>
        /// <param name="query">The SQL query to execute.</param>
        /// <param name="parameters">Optional array of SqlParameters to use with the query.</param>
        /// <param name="isStoredProcedures">A boolean stating if the query is a stored procedure</param>
        /// <returns>A DataSet containing the query results.</returns>
        public static DataSet ExecuteQuery(string query,
                                            SqlParameter[] parameters = null,
                                            bool isStoredProcedures = false) {
            using (var connection = GetConnection()) {
                connection.Open();

                using (var command = new SqlCommand(query, connection)) {
                    if (isStoredProcedures) 
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