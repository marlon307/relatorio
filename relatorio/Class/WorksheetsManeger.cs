using System;
using System.Collections.Generic;
using System.Data.SQLite;
using static DB.SQLiteDB;


namespace start.Class
{
    internal class WorksheetsManeger
    {
        private string deposit;
        public string Deposito
        {
            get { return deposit; }
            set { deposit = value; }
        }
        private string spent;
        public string Gasto
        {
            get { return spent; }
            set { spent = value; }
        }
        private string cheque;
        public string Cheque
        {
            get { return cheque; }
            set { cheque = value; }
        }
        private string coins;
        public string Moedas
        {
            get { return coins; }
            set { coins = value; }
        }
        private string lack;
        public string Falta
        {
            get { return lack; }
            set { lack = value; }
        }
        private string lefover;
        public string Sobra
        {
            get { return lefover; }
            set { lefover = value; }
        }
        private string comments;
        public string Observações
        {
            get { return comments; }
            set { comments = value; }
        }
        public static List<WorksheetsManeger>ListAllWorkSheets(string resportDate)
        {
            string dateFormat = DateTime.Parse(resportDate).ToString("yyyy-MM-dd");
            List<ConditionWhere> dateCondition = new List<ConditionWhere>
            {
                new ConditionWhere("@date", dateFormat),
            };
            SQLiteDataReader listReport = QuerySelect("SELECT rp.date, rc.deposit, rc.spent, rc.cheque, rc.coins, rc.lack, rc.leftover, rc.comments FROM 'reports' AS 'rp' INNER JOIN 'records' AS 'rc' ON rc.report_id = rp.id WHERE date = DATE(@date);", dateCondition);

            List<WorksheetsManeger> List = new List<WorksheetsManeger>();
            while (listReport.Read())
            {
                WorksheetsManeger resports = new WorksheetsManeger()
                {
                    Deposito = listReport["deposit"].ToString(),
                    Gasto = listReport["spent"].ToString(),
                    Cheque = listReport["cheque"].ToString(),
                    Moedas = listReport["coins"].ToString(),
                    Falta = listReport["lack"].ToString(),
                    Sobra = listReport["leftover"].ToString(),
                    Observações = listReport["comments"].ToString(),
                };
                List.Add(resports);
            }
            return List;
        }
    }
}
