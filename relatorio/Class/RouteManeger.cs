using System;
using System.Collections.Generic;
using System.Data.SQLite;
using static DB.SQLiteDB;

namespace start.Class
{
    internal class RouteManeger
    {
        private string rota;

        public string Nome
        {
            get { return rota; }
            set { rota = value; }
        }
        public static List<RouteManeger> ListarRotas()
        {
            List<RouteManeger> List = new List<RouteManeger>();
            SQLiteDataReader listRoute = QuerySelect("SELECT route FROM routes WHERE deleted_at IS NULL");

            while (listRoute.Read())
            {
                RouteManeger p = new RouteManeger()
                {
                    Nome = listRoute["route"].ToString(),
                };
                List.Add(p);
            }
            return List;
        }
        public static void ExcluirItemRota(string Rota)
        {
            List<ConditionWhere> whereCondition = new List<ConditionWhere>
            {
                new ConditionWhere("@route", Rota.ToString()),
            };
            QueryWhere("UPDATE routes SET deleted_at=DATETIME('NOW') WHERE route=@route", whereCondition);
        }
    }
}

