using IPWA01_01.Backend.DataAccess.Contracts;
using IPWA01_01.Backend.DataAccess.DatabaseConnection;
using IPWA01_01.Backend.DataAccess.Interface;

namespace IPWA01_01.Backend.DataAccess
{
    public class Bootstrapper
    {
        public static IDataAccessController CreateDatabaseAccessControllerSqlite(DatabaseConfiguration databaseConfugration)
        {
            var databaseConnection = CreateDatabaseConnectionSqlite(databaseConfugration);

            return new DataAccessController(databaseConnection);
        }

        private static IDatabaseConnection CreateDatabaseConnectionSqlite(DatabaseConfiguration databaseConfugration)
        {
            var connectionString = CreateConnectionStringSqlite(databaseConfugration);
            return new DatabaseConnectionSqlite(connectionString);
        }

        private static string CreateConnectionStringSqlite(DatabaseConfiguration databaseConfugration) 
        {
            if (databaseConfugration == null || string.IsNullOrEmpty(databaseConfugration.Location))
                throw new ArgumentNullException("Das DatabaseConfiguration darf nicht null sein oder die Location darf nicht null sein");

            return $"Data Source={databaseConfugration.Location};";
        }
    }
}
