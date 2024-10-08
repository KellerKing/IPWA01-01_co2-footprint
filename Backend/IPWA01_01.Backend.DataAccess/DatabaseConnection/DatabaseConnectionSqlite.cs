using Dapper;
using IPWA01_01.Backend.DataAccess.Interface;
using IPWA01_01.Backend.DataAccess.Model;
using Microsoft.Data.Sqlite;
using System.Collections.Generic;

namespace IPWA01_01.Backend.DataAccess.DatabaseConnection
{
    internal class DatabaseConnectionSqlite : IDatabaseConnection
    {
        private readonly string m_ConnectionString;

        private readonly string m_TabelleCo2Verbrauch = "Co2Verbrauch";
        private readonly string m_TabelleLand = "Land";
        private readonly string m_TabelleUnternehmen = "Unternehmen";

        public DatabaseConnectionSqlite(string connectionString)
        {
            m_ConnectionString = connectionString;
        }

        public IEnumerable<Co2VerbrauchModel> GetCo2VerbauchGefiltert(string filterLand, string filterUnternehmen)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Co2VerbrauchModel> GetCo2Verbrauch()
        {
            var sql = $"Select * FROM {m_TabelleCo2Verbrauch}";

            using var connection = new SqliteConnection(m_ConnectionString);
            var result = connection.Query<Co2VerbrauchModel>(sql);

            return result;
        }

        public IEnumerable<LandModel> GetLand(LandModel land)
        {
            var sql = $"Select * From {m_TabelleLand} WHERE name = @Name";

            if (land.Id > 0)
                sql += " And id = @Id";

            sql += ";";

            using var connection = new SqliteConnection(m_ConnectionString);
            var result = connection.Query<LandModel>(sql, land);
            return result;
        }

        public IEnumerable<UnternehmenModel> GetUnternehmen(UnternehmenModel unternehmen)
        {
            var sql = $"Select * From {m_TabelleUnternehmen} WHERE name = @Name";

            if (!string.IsNullOrEmpty(unternehmen.Branche))
                sql += " And Branche = @Branche";

            if (unternehmen.Id > 0)
                sql += " And id = @Id";

            sql += ";";

            using var connection = new SqliteConnection(m_ConnectionString);
            var result = connection.Query<UnternehmenModel>(sql, unternehmen);
            return result;
        }

        public bool InsertCo2Verbrauch(Co2VerbrauchModel co2Verbrauch)
        {
            var sql = $"Insert into {m_TabelleCo2Verbrauch} (landId, unternehmenId, co2Verbrauch) Values (@LandId, @UnternehmenId, @Co2Verbrauch)";
            using var connection = new SqliteConnection(m_ConnectionString);

            var result = connection.Execute(sql, co2Verbrauch);
            return result > 0;
        }

        public bool InsertLand(LandModel land)
        {
            var sql = $"Insert into {m_TabelleLand} (Name) Values (@Name)";
            using var connection = new SqliteConnection(m_ConnectionString);

            var result = connection.Execute(sql, land);
            return result > 0;    
        }

        public bool InsertUnternehmen(UnternehmenModel unternehmen)
        {
            var sql = $"Insert into {m_TabelleUnternehmen} (Name, Branche) Values (@Name, @Branche)";
            using var connection = new SqliteConnection(m_ConnectionString);

            var result = connection.Execute(sql, unternehmen);
            return result > 0;
        }

        public void TruncateDatabase()
        {
            using var connection = new SqliteConnection(m_ConnectionString);

            var sql = $"Delete From {m_TabelleCo2Verbrauch};";
            connection.Execute(sql);

            sql = $"Delete From {m_TabelleUnternehmen};";
            connection.Execute(sql);

            sql = $"Delete From {m_TabelleLand};";
            connection.Execute(sql);

            sql = $"UPDATE sqlite_sequence SET seq = 0 WHERE name = '{m_TabelleCo2Verbrauch}'";
            connection.Execute(sql);

            sql = $"UPDATE sqlite_sequence SET seq = 0 WHERE name = '{m_TabelleLand}'";
            connection.Execute(sql);

            sql = $"UPDATE sqlite_sequence SET seq = 0 WHERE name = '{m_TabelleUnternehmen}'";
            connection.Execute(sql);

        }
    }
}
