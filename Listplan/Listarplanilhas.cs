using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace Listplan
{
    public class Listarplanilhas
    {
        private string LpRota;
        private string LpFunc;
        private string LpSaida;
        private string LpVolta;
        private string LpDep;
        private string LpGast;
        private string LpCheq;
        private string LpMoed;
        private string LpFalt;
        private string LpSob;
        private string LpObs;

        public string LpGridRota
        {
            get { return LpRota; }
            set { LpRota = value; }
        }
        public string LpGridFunc
        {
            get { return LpFunc; }
            set { LpFunc = value; }
        }
        public string LpGridSaiu
        {
            get { return LpSaida; }
            set { LpSaida = value; }
        }
        public string LpGridVolta
        {
            get { return LpVolta; }
            set { LpVolta = value; }
        }
        public string LpGridDep
        {
            get { return LpDep; }
            set { LpDep = value; }
        }
        public string LpGridGast
        {
            get { return LpGast; }
            set { LpGast = value; }
        }
        public string LpGridCheq
        {
            get { return LpCheq; }
            set { LpCheq = value; }
        }
        public string LpGridMoed
        {
            get { return LpMoed; }
            set { LpMoed = value; }
        }
        public string LpGridFalt
        {
            get { return LpFalt; }
            set { LpFalt = value; }
        }
        public string LpGridSob
        {
            get { return LpSob; }
            set { LpSob = value; }
        }
        public string LpGridObs
        {
            get { return LpObs; }
            set { LpObs = value; }
        }
        /*public static List<Listarplanilhas> ListaRelatorioPl(string nArchive)
        {
            List<Listarplanilhas> List = new List<Listarplanilhas>();
            XElement xml = XElement.Load(@"cache\" + nArchive + ".xml");
            foreach (XElement x in xml.Elements("Planilha"))
            {
                Listarplanilhas p = new Listarplanilhas()
                {
                    LpRota = x.Attribute("Rota").Value,
                    LpFunc = x.Attribute("Funcionario").Value,
                    LpSaida = x.Attribute("SaidaP").Value,
                    LpVolta = x.Attribute("VoltaP").Value,
                    LpDep = x.Attribute("Deposito").Value,
                    LpGast = x.Attribute("Gasto").Value,
                    LpCheq = x.Attribute("Cheque").Value,
                    LpMoed = x.Attribute("Moeda").Value,
                    LpFalt = x.Attribute("Falta").Value,
                    LpSob = x.Attribute("Sobra").Value,
                    LpObs = x.Attribute("Observacoes").Value,
                };
                List.Add(p);
            }
            return List;
        }//ExcluirItemPlanilhas*/
        public static void ExcluirItemPlanilhas(string Rota, string nArchive)
        {
            XElement xml = XElement.Load(@"cache\" + nArchive + ".xml");
            XElement x = xml.Elements("Planilha").Where(p => p.Attribute("Rota").Value.Equals(Rota.ToString())).First();
            if (x != null)
            {
                x.Remove();
            }
            xml.Save(@"cache\" + nArchive + ".xml");
        }//Editar Planilha
        public static void EditarPlanilhaLp(Listarplanilhas Rota, string nArchive)
        {
            XElement xml = XElement.Load(@"cache\" + nArchive + ".xml");
            XElement x = xml.Elements("Planilha").Where(p => p.Attribute("Rota").Value.Equals(Rota.LpRota.ToString())).First();
            if (x != null)
            {
                x.Attribute("Rota").SetValue(Rota.LpGridRota);
                x.Attribute("Funcionario").SetValue(Rota.LpGridFunc);
                x.Attribute("SaidaP").SetValue(Rota.LpGridSaiu);
                x.Attribute("VoltaP").SetValue(Rota.LpGridVolta);
                x.Attribute("Deposito").SetValue(Rota.LpGridDep);
                x.Attribute("Gasto").SetValue(Rota.LpGridGast);
                x.Attribute("Cheque").SetValue(Rota.LpGridCheq);
                x.Attribute("Moeda").SetValue(Rota.LpGridMoed);
                x.Attribute("Falta").SetValue(Rota.LpGridFalt);
                x.Attribute("Sobra").SetValue(Rota.LpGridSob);
                x.Attribute("Observacoes").SetValue(Rota.LpObs);
            }
            xml.Save(@"cache\" + nArchive + ".xml");
        }
    }
}