using System;
using System.Data;
using System.Data.SQLite;

namespace DB
{
    public class SQLiteDB
    {
        private static SQLiteConnection SQLiteConnection = null;

        private static SQLiteConnection DBConnection()
        {
            SQLiteConnection = new SQLiteConnection("Data Source=database.db; Version=3;");
            SQLiteConnection.Open();
            return SQLiteConnection;
        }

        public static void CreateDB()
        {
            try
            { 
                SQLiteConnection.CreateFile(@"database.db");
            }
            catch { throw; }
        }
        public static void CreateTable()
        {
            try
            {
                using (var cmd = DBConnection().CreateCommand())
                {
                    cmd.CommandText = "CREATE TABLE IF NOT EXISTS rotas (id INTEGER PRIMARY KEY AUTOINCREMENT, name VARCHAR(50) NOT NULL)";
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static DataTable QuerySelect(String query)
        {
            try
            {
                SQLiteDataAdapter da = null;
                DataTable dt = new DataTable();
                using (var cmd = DBConnection().CreateCommand())
                {
                    cmd.CommandText = query;
                    da = new SQLiteDataAdapter(cmd.CommandText, DBConnection());
                    da.Fill(dt);
                    return dt;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void QueryInsert(String query)
        {
            try
            {
                DataTable dt = new DataTable();
                using (var cmd = DBConnection().CreateCommand())
                {
                    cmd.CommandText = query;
                    cmd.Parameters.AddWithValue("@name", "Teste");
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
