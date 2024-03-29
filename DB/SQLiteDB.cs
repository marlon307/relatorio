﻿using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;

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
            try
            {
                if (SQLiteConnection == null)
                {
                    string documentsFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                    string filePath = Path.Combine(documentsFolder, "Relatório");
                    string sqlPath = string.Format(@"Data Source={0}\database.db; Version=3;", filePath);
                    
                    if (!Directory.Exists(filePath))
                    {
                        Directory.CreateDirectory(filePath);
                    }
                   
                    SQLiteConnection = new SQLiteConnection(sqlPath);
                    SQLiteConnection.Open();
                }
                return SQLiteConnection;
            }
            catch { throw;  }
        }
        public static void CreateTable()
        {
            try
            {
                using (var command = DBConnection().CreateCommand())
                {
                    command.CommandText = @"
                        CREATE TABLE IF NOT EXISTS employees (
                            id INTEGER PRIMARY KEY AUTOINCREMENT,
                            name TEXT NOT NULL,
                            deleted_at DATETIME
                        );
                        CREATE TABLE IF NOT EXISTS reports (
                            id INTEGER PRIMARY KEY AUTOINCREMENT,
                            date DATE NOT NULL,
                            stock INTEGER DEFAULT 0,
                            production INTEGER DEFAULT 0,
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
