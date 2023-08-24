using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Globalization;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using static DB.SQLiteDB;


namespace start.Class
{
    internal class WorksheetsManeger
    {
        internal string RecordID { get; set; }
        internal string EmpID { get; set; }
        public string Rota { get; set; }
        public string Funcionário { get; set; }
        public string Saida { get; set; }
        public string Volta { get; set; }
        public string Deposito { get; set; }
        public string Gasto { get; set; }
        public string Cheque { get; set; }
        public string Moedas { get; set; }
        public string Falta { get; set; }
        public string Sobra { get; set; }
        public string Observações { get; set; }
        public static List<WorksheetsManeger> ListAllWorkSheets(string resportDate)
        {
            string dateFormat = DateTime.Parse(resportDate).ToString("yyyy-MM-dd");
            List<ConditionWhere> dateCondition = new List<ConditionWhere>
            {
                new ConditionWhere("@date", dateFormat),
            };
            SQLiteDataReader listReport = QuerySelect(@"
            SELECT rp.date, em.name, rt.route, em.id AS em_id, rc.id, rc.qtd_exit, rc.qtd_back, rc.deposit, rc.spent, rc.cheque, rc.coins, rc.lack, rc.leftover, rc.comments
            FROM 'reports' AS 'rp' 
            INNER JOIN 'records' AS 'rc' ON rc.report_id = rp.id 
            INNER JOIN employees AS 'em' ON em.id = rc.employee_id
            INNER JOIN routes AS 'rt' ON rt.id = rc.route_id
            WHERE date = DATE(@date);", dateCondition);

            List<WorksheetsManeger> List = new List<WorksheetsManeger>();
            while (listReport.Read())
            {
                WorksheetsManeger resports = new WorksheetsManeger()
                {
                    RecordID = listReport["id"].ToString(),
                    EmpID = listReport["em_id"].ToString(),
                    Rota = listReport["route"].ToString(),
                    Funcionário = listReport["name"].ToString(),
                    Saida = listReport["qtd_exit"].ToString(),
                    Volta = listReport["qtd_back"].ToString(),
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
            WorksheetsManeger total = new WorksheetsManeger()
            {
                RecordID = "0",
                EmpID = "0",
                Rota = "TOTAIS",
                Funcionário = "FLUXO TOTAL",
                Saida = List.Select((crr) => Convert.ToInt32(crr.Saida)).Sum().ToString(),
                Volta = List.Select((crr) => Convert.ToInt32(crr.Volta)).Sum().ToString(),
                Deposito = string.Format("{0:C}", List.Sum((crr) => double.Parse(crr.Deposito, NumberStyles.Currency))),
                Gasto = string.Format("{0:C}", List.Sum((crr) => double.Parse(crr.Gasto, NumberStyles.Currency))),
                Cheque = string.Format("{0:C}", List.Sum((crr) => double.Parse(crr.Cheque, NumberStyles.Currency))),
                Moedas = string.Format("{0:C}", List.Sum((crr) => double.Parse(crr.Moedas, NumberStyles.Currency))),
                Falta = string.Format("{0:C}", List.Sum((crr) => double.Parse(crr.Falta, NumberStyles.Currency))),
                Sobra = string.Format("{0:C}", List.Sum((crr) => double.Parse(crr.Sobra, NumberStyles.Currency))),
                Observações = "SOMA DE TODAS AS ROTAS FINALIZADAS",
            };
            List.Add(total);
            return List;
        }
        internal class IPropsUpdate {
            public string Deposit { get; set; }
            public string Spent { get; set; }
            public string Cheque { get; set; }
            public string Coins { get; set; }
            public string Lack { get; set; }
            public string Leftover { get; set; }
            public string QuantityExit { get; set; }
            public string QuantityBack { get; set; }
            public string Comments { get; set; }
        }
        public static void UpdateReport(string reportID, IPropsUpdate props) {
            List<ConditionWhere> condition = new List<ConditionWhere>
            {
                new ConditionWhere("@id", reportID),
                new ConditionWhere("@deposit", double.Parse(props.Deposit,  NumberStyles.Currency)),
                new ConditionWhere("@spent", double.Parse(props.Spent, NumberStyles.Currency)),
                new ConditionWhere("@cheque", double.Parse(props.Cheque, NumberStyles.Currency)),
                new ConditionWhere("@coins", double.Parse(props.Coins, NumberStyles.Currency)),
                new ConditionWhere("@lack", double.Parse(props.Lack, NumberStyles.Currency)),
                new ConditionWhere("@leftover", double.Parse(props.Leftover, NumberStyles.Currency)),
                new ConditionWhere("@qtd_exit", props.QuantityExit),
                new ConditionWhere("@qtd_back", props.QuantityBack),
                new ConditionWhere("@comments", props.Comments),
            };
            QueryWhere(@"UPDATE records
            SET deposit=@deposit, spent=@spent, cheque=@cheque, coins=@coins, lack=@lack, leftover=@leftover, qtd_exit=@qtd_exit, qtd_back=@qtd_back, comments=@comments
            WHERE id = @id;", condition);
        }
        public static void DeleteReport (string reportID)
        {
            List<ConditionWhere>condition = new List<ConditionWhere>
            {
                new ConditionWhere("@id", reportID)
            };
            QueryWhere("DELETE FROM records WHERE id=@id;", condition);
        }
        public static SQLiteDataReader ReadStock(string dateReport)
        {
            string dateFormat = DateTime.Parse(dateReport).ToString("yyyy-MM-dd");
            List<ConditionWhere> condition = new List<ConditionWhere>
            {
                new ConditionWhere("@date", dateFormat)
            };
            SQLiteDataReader result = QuerySelect("SELECT stock, production FROM reports WHERE date=@date;", condition);
            return result;
        }
        public static void UpdateStock(string dateReport, int stock, int production)
        {
            string dateFormat = DateTime.Parse(dateReport).ToString("yyyy-MM-dd");
            List<ConditionWhere> condition = new List<ConditionWhere>
            {
                new ConditionWhere("@date", dateFormat),
                new ConditionWhere("@stock", stock),
                new ConditionWhere("@production", production)

            };
            QueryWhere("UPDATE reports SET stock=@stock, production=@production WHERE date=@date;", condition);
        }
    }
}
