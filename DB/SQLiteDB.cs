using System;
using System.Collections.Generic;
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
                using (var command = DBConnection().CreateCommand())
                {
                    command.CommandText = "CREATE TABLE IF NOT EXISTS rotas (id INTEGER PRIMARY KEY AUTOINCREMENT, name VARCHAR(50) NOT NULL)";
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public class ConditionWhere
        {
            public string Name { get; set; }
            public string Value { get; set; }

            public ConditionWhere(string name, string value)
            {
                Name = name;
                Value = value;
            }
        }

        public static SQLiteDataReader QuerySelect(string query, List<ConditionWhere> where = null)
        {
            try
            {
                SQLiteCommand command = new SQLiteCommand(query, DBConnection());
                if(where != null)
                {
                    foreach (ConditionWhere item in where)
                    {
                        command.Parameters.AddWithValue(item.Name, item.Value);
                    }
                }
                command.ExecuteNonQuery();
                SQLiteDataReader reader = command.ExecuteReader();
                return reader;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void QueryInsert(string query, List<ConditionWhere> values)
        {
            try
            {
                using (var command = DBConnection().CreateCommand())
                {
                    command.CommandText = query;
                    foreach (ConditionWhere item in values)
                    {
                        command.Parameters.AddWithValue(item.Name, item.Value);
                    }
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static void QueryDelete(string query, List<ConditionWhere> where)
        {
            using (SQLiteCommand command = new SQLiteCommand(query, DBConnection()))
            {
                foreach (ConditionWhere item in where)
                {
                    command.Parameters.AddWithValue(item.Name.ToString(), item.Value.ToString());
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
