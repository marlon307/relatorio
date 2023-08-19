using System.Collections.Generic;
using System.Data.SQLite;
using static DB.SQLiteDB;

namespace start.Class
{
    internal class EmployeeManeger
    {
        private string employee;
        public string Funcionário
        {
            get { return employee; }
            set { employee = value; }
        }
        public static List<EmployeeManeger> ListEmployess()
        {
            List<EmployeeManeger> List = new List<EmployeeManeger>();
            SQLiteDataReader listRoute = QuerySelect("SELECT name FROM employees WHERE deleted_at IS NULL");

            while (listRoute.Read())
            {
                EmployeeManeger employee = new EmployeeManeger()
                {
                    Funcionário = listRoute["name"].ToString(),
                };
                List.Add(employee);
            }
            return List;
        }
        public static void DeleteEmployee(string Rota)
        {
            List<ConditionWhere> whereCondition = new List<ConditionWhere>
            {
                new ConditionWhere("@name", Rota.ToString()),
            };
            QueryWhere("UPDATE employees SET deleted_at=DATETIME('NOW') WHERE name=@name", whereCondition);
        }
    }
}
