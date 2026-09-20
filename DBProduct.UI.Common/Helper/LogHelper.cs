using Microsoft.Data.SqlClient;

namespace DBProduct.UI.Common.Helper
{
    public class LogHelper
    {
        private readonly string connectionString =
            "Data Source=localhost\\SQLEXPRESS;Initial Catalog=DBProduct;Integrated Security=True;TrustServerCertificate=True;";

        public void Log(
            string message,
            string messageType,
            string logTier)
        {
            try
            {
                using (SqlConnection connection =
                    new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = @"
                        INSERT INTO ProductLogger
                        (Message, MessageType, LogTier)
                        VALUES
                        (@Message, @MessageType, @LogTier)";

                    using (SqlCommand command =
                        new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue(
                            "@Message",
                            message);

                        command.Parameters.AddWithValue(
                            "@MessageType",
                            messageType);

                        command.Parameters.AddWithValue(
                            "@LogTier",
                            logTier);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch
            {
                // Logging should never crash the main application.
            }
        }

        public void LogException(
            Exception exception,
            string logTier)
        {
            string message =
                $"{exception.GetType().Name}: {exception.Message}";

            Log(
                message,
                "Error",
                logTier);
        }
    }
}