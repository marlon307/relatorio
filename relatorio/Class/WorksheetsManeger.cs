using System;
using System.Collections.Generic;
using System.Data.SQLite;
using static DB.SQLiteDB;


namespace start.Class
{
    internal class WorksheetsManeger
    {
        private string EmployeeID { get; set; }
        public string Funcionário { get; set; }
        public string Deposito { get; set; }
        public string Gasto { get; set; }
        public string Cheque { get; set; }
        public string Moedas { get; set; }
        public string Falta { get; set; }
        public string Sobra { get; set; }
        public string Observações { get; set; }
        public static List<WorksheetsManeger>ListAllWorkSheets(string resportDate)
        {
            string dateFormat = DateTime.Parse(resportDate).ToString("yyyy-MM-dd");
            List<ConditionWhere> dateCondition = new List<ConditionWhere>
            {
                new ConditionWhere("@date", dateFormat),
            };
            SQLiteDataReader listReport = QuerySelect("SELECT rp.date, em.name, em.id AS em_id, rc.id, rc.deposit, rc.spent, rc.cheque, rc.coins, rc.lack, rc.leftover, rc.comments FROM 'reports' AS 'rp' INNER JOIN 'records' AS 'rc' ON rc.report_id = rp.id INNER JOIN employees AS 'em' ON em.id = rc.employee_id WHERE date = DATE(@date);", dateCondition);
            
            List<WorksheetsManeger> List = new List<WorksheetsManeger>();
            while (listReport.Read())
            {
                WorksheetsManeger resports = new WorksheetsManeger()
                {
                   // EmployeeID = listReport["em_id"].ToString(),
                    Funcionário = listReport["name"].ToString(),
                    Deposito = string.Format("{0:C}", listReport["deposit"]),
                    Gasto = string.Format("{0:C}", listReport["spent"]),
                    Cheque = string.Format("{0:C}", listReport["cheque"]),
                    Moedas = string.Format("{0:C}", listReport["coins"]),
                    Falta = string.Format("{0:C}", listReport["lack"]),
                    Sobra = string.Format("{0:C}", listReport["leftover"]),
                    Observações = listReport["comments"].ToString(),
                };
                List.Add(resports);
            }
            return List;
        }
    }
}
