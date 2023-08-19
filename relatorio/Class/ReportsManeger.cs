using System.Collections.Generic;
using System.Data.SQLite;
using static DB.SQLiteDB;

namespace start.Class
{
    internal class ReportsManeger
    {
        private string date;
        private string total;
        public string Data
        {
            get { return date; }
            set { date = value; }
        }
        public string Total
        {
            get { return total; }
            set { total = value; }
        }
        public static List<ReportsManeger> ListReports()
        {
            List<ReportsManeger> List = new List<ReportsManeger>();
            SQLiteDataReader listReport = QuerySelect("SELECT rp.date, SUM(deposit + spent + cheque + coins - lack + leftover) AS 'Total' FROM 'reports' AS 'rp' INNER JOIN 'records' AS 'rc' ON rc.report_id = rp.id;");

            while (listReport.Read())
            {
                ReportsManeger resports = new ReportsManeger()
                {
                    Data = listReport["date"].ToString(),
                    Total = listReport["Total"].ToString(),
                };
                List.Add(resports);
            }
            return List;
        }
    }
}
