using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;

namespace DB
{
    public class SQLiteDB
    {
        private static SQLiteConnection SQLiteConnection = null;
        public class ConditionWhere
        {
            public string Name { get; set; }
            public dynamic Value { get; set; }
            public ConditionWhere(string name, dynamic value)
            {
                Name = name;
                Value = value;
            }
        }
        private static SQLiteConnection DBConnection()
        {
            if (SQLiteConnection == null)
            {
                SQLiteConnection = new SQLiteConnection("Data Source=database.db; Version=3;");
                SQLiteConnection.Open();
            }
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
                    command.CommandText = @"
                        CREATE TABLE IF NOT EXISTS report_has_products (
                            id_report INTEGER PRIMARY KEY AUTOINCREMENT,
                            id_product INTEGER NOT NULL,
                            FOREIGN KEY (id_product) REFERENCES products(id),
                            FOREIGN KEY (id_report) REFERENCES reports(id)
                        );

                        CREATE TABLE IF NOT EXISTS employees (
                            id INTEGER PRIMARY KEY AUTOINCREMENT,
                            name TEXT NOT NULL,
                            deleted_at DATETIME
                        );

                        CREATE TABLE IF NOT EXISTS products (
                            id INTEGER PRIMARY KEY AUTOINCREMENT,
                            name TEXT NOT NULL,
                            production INTEGER NOT NULL,
                            stock INTEGER NOT NULL
                        );

                        CREATE TABLE IF NOT EXISTS reports (
                            id INTEGER PRIMARY KEY AUTOINCREMENT,
                            date DATE NOT NULL,
                            created_at DATETIME DEFAULT CURRENT_TIMESTAMP
                        );

                        CREATE TABLE IF NOT EXISTS routes (
                            id INTEGER PRIMARY KEY AUTOINCREMENT,
                            route TEXT NOT NULL,
                            deleted_at DATETIME
                        );

                        CREATE TABLE IF NOT EXISTS records (
                            id INTEGER PRIMARY KEY AUTOINCREMENT,
                            deposit DOUBLE NOT NULL,
                            spent DOUBLE NOT NULL,
                            cheque DOUBLE NOT NULL,
                            coins DOUBLE NOT NULL,
                            lack DOUBLE NOT NULL,
                            leftover DOUBLE NOT NULL,
                            qtd_exit INTEGER NOT NULL,
                            qtd_back INTEGER NOT NULL,
                            comments TEXT NOT NULL,
                            report_id INTEGER NOT NULL,
                            employee_id INTEGER NOT NULL,
                            route_id INTEGER NOT NULL,
                            created_at DATETIME DEFAULT CURRENT_TIMESTAMP,
                            FOREIGN KEY (route_id) REFERENCES routes(id),
                            FOREIGN KEY (report_id) REFERENCES reports(id),
                            FOREIGN KEY (employee_id) REFERENCES employees(id)
                        );";
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static SQLiteDataReader QuerySelect(string query, List<ConditionWhere> where = null)
        {
            try
            {
                using (var command = DBConnection().CreateCommand())
                {
                    command.CommandText = query;
                    if (where != null)
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
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int QueryInsert(string query, List<ConditionWhere> values = null)
        {
            try
            {
                using (var command = DBConnection().CreateCommand())
                {
                    command.CommandText = query;
                    if (values != null)
                    {
                        foreach (ConditionWhere item in values)
                        {
                            command.Parameters.AddWithValue(item.Name, item.Value);
                        }
                    }
                    command.ExecuteNonQuery();
                    command.CommandText = "SELECT last_insert_rowid()";
                    int lastInsertedId = Convert.ToInt32(command.ExecuteScalar());
                    return lastInsertedId;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void QueryWhere(string query, List<ConditionWhere> where)
        {
            try
            {
                using (var command = DBConnection().CreateCommand())
                {
                    command.CommandText = query;
                    foreach (ConditionWhere item in where)
                    {
                        command.Parameters.AddWithValue(item.Name.ToString(), item.Value);
                    }
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
