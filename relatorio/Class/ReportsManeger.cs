using System;
using System.Collections.Generic;
using System.Data.SQLite;
using static DB.SQLiteDB;

namespace start.Class
{
    internal class ReportsManeger
    {
        private string date;
        public string Data
        {
            get { return date; }
            set { date = value; }
        }
        private string total;
        public string Total
        {
            get { return total; }
            set { total = value; }
        }
        public static List<ReportsManeger> ListReports()
        {
            List<ReportsManeger> List = new List<ReportsManeger>();
            SQLiteDataReader listReport = QuerySelect("SELECT rp.date, SUM(rc.deposit + rc.spent + rc.cheque + rc.coins - rc.lack + rc.leftover) AS 'Total' FROM 'reports' AS 'rp' INNER JOIN 'records' AS 'rc' ON rc.report_id = rp.id GROUP BY rp.id ORDER BY rp.date DESC;");

            while(listReport.Read())
            {
                DateTime  resDate = DateTime.Parse(listReport["date"].ToString());
                ReportsManeger resports = new ReportsManeger()
                {
                    Data = resDate.ToString("dd/MM/yyyy"),
                    Total = string.Format("{0:C}", listReport["Total"]),
                };
                List.Add(resports);
            }
            return List;
        }
    }
}
