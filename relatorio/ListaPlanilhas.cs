using System;
using System.Collections.Generic;
using System.Windows.Forms;
using HomeClass;
using Listplan;
using format;

namespace start
{
    public partial class ListaPlanilhas : MetroFramework.Forms.MetroForm
    {
        private List<Listarplanilhas> ListGridLp;
        private List<ClassGridLpHome> ListGridHm;
        double n1, n2, n3, n4, n5, n6, total;

        Home ObjectsHome;
        string nArchive = Home.DateProprie;


        public ListaPlanilhas(Home frm1)
        {
            InitializeComponent();

            this.StyleManager = StyleManegerLplan;

            ObjectsHome = frm1;

            ListGridLp = Listarplanilhas.ListaRelatorioPl(nArchive);
            LpGrid.DataSource = ListGridLp;

            TbLpRota.Text = ListGridLp[Home.VlueIndexGrid].LpGridRota;
            TbLpFunc.Text = ListGridLp[Home.VlueIndexGrid].LpGridFunc;
            TbLpSaida.Text = ListGridLp[Home.VlueIndexGrid].LpGridSaiu;
            TbLpVolta.Text = ListGridLp[Home.VlueIndexGrid].LpGridVolta;
            TbLpDep.Text = ListGridLp[Home.VlueIndexGrid].LpGridDep;
            TbLpGast.Text = ListGridLp[Home.VlueIndexGrid].LpGridGast;
            TbLpCheq.Text = ListGridLp[Home.VlueIndexGrid].LpGridCheq;
            TbLpMoed.Text = ListGridLp[Home.VlueIndexGrid].LpGridMoed;
            TbLpFalt.Text = ListGridLp[Home.VlueIndexGrid].LpGridFalt;
            TbLpSob.Text = ListGridLp[Home.VlueIndexGrid].LpGridSob;
            TbLpObs.Text = ListGridLp[Home.VlueIndexGrid].LpGridObs;
            LpGrid.CurrentCell = LpGrid[0, Home.VlueIndexGrid];//Vai mante a celula selecionada
        }
        private void BtnLpDel_Click(object sender, EventArgs e)
        {
            if (LpGrid.SelectedRows.Count > 0)
            {
                int indice = LpGrid.SelectedRows[0].Index;
                Listarplanilhas.ExcluirItemPlanilhas(ListGridLp[indice].LpGridRota, nArchive);
                ListGridLp = Listarplanilhas.ListaRelatorioPl(nArchive);
                LpGrid.DataSource = ListGridLp;
                TbLpRota.Clear();
                TbLpFunc.Clear();
                TbLpSaida.Clear();
                TbLpVolta.Clear();
                TbLpDep.Clear();
                TbLpGast.Clear();
                TbLpCheq.Clear();
                TbLpMoed.Clear();
                TbLpFalt.Clear();
                TbLpSob.Clear();
                TbLpObs.Clear();
                ListGridHm = ClassGridLpHome.ListaRelatorio(nArchive);
               // ObjectsHome.ListGridHome.DataSource = ListGridHm;
            }
        }
        private void BtnLpOk_Click(object sender, EventArgs e)
        {
            if (TbLpRota.Text != "")
            {
                if (LpGrid.SelectedRows.Count > 0)
                {
                    Listarplanilhas p = new Listarplanilhas()
                    {
                        LpGridRota = TbLpRota.Text,
                        LpGridFunc = TbLpFunc.Text.ToUpper(),
                        LpGridSaiu = TbLpSaida.Text,
                        LpGridVolta = TbLpVolta.Text,
                        LpGridDep = TbLpDep.Text,
                        LpGridGast = TbLpGast.Text,
                        LpGridCheq = TbLpCheq.Text,
                        LpGridMoed = TbLpMoed.Text,
                        LpGridFalt = TbLpFalt.Text,
                        LpGridSob = TbLpSob.Text,
                        LpGridObs = TbLpObs.Text.ToUpper()
                    };
                    Listarplanilhas.EditarPlanilhaLp(p, nArchive);
                    ListGridLp = Listarplanilhas.ListaRelatorioPl(nArchive);
                    LpGrid.DataSource = ListGridLp;
                    ListGridHm = ClassGridLpHome.ListaRelatorio(nArchive);
                  //  ObjectsHome.ListGridHome.DataSource = ListGridHm;
                }
            }
            this.Close();
        }
        private void BtnLpSave_Click(object sender, EventArgs e)
        {
            if (TbLpRota.Text != "")
            {
                if (LpGrid.SelectedRows.Count > 0)
                {
                    Listarplanilhas p = new Listarplanilhas()
                    {
                        LpGridRota = TbLpRota.Text,
                        LpGridFunc = TbLpFunc.Text.ToUpper(),
                        LpGridSaiu = TbLpSaida.Text,
                        LpGridVolta = TbLpVolta.Text,
                        LpGridDep = TbLpDep.Text,
                        LpGridGast = TbLpGast.Text,
                        LpGridCheq = TbLpCheq.Text,
                        LpGridMoed = TbLpMoed.Text,
                        LpGridFalt = TbLpFalt.Text,
                        LpGridSob = TbLpSob.Text,
                        LpGridObs = TbLpObs.Text.ToUpper()
                    };
                    Listarplanilhas.EditarPlanilhaLp(p, nArchive);
                    ListGridLp = Listarplanilhas.ListaRelatorioPl(nArchive);
                    LpGrid.DataSource = ListGridLp;
                    ListGridHm = ClassGridLpHome.ListaRelatorio(nArchive);
                   // ObjectsHome.ListGridHome.DataSource = ListGridHm;
                }
            }
        }
        private void LpGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (LpGrid.SelectedRows.Count > 0)
            {
                int indice = LpGrid.SelectedRows[0].Index;
                if (indice >= 0)
                {
                    TbLpRota.Text = ListGridLp[indice].LpGridRota;
                    TbLpFunc.Text = ListGridLp[indice].LpGridFunc;
                    TbLpSaida.Text = ListGridLp[indice].LpGridSaiu;
                    TbLpVolta.Text = ListGridLp[indice].LpGridVolta;
                    TbLpDep.Text = ListGridLp[indice].LpGridDep;
                    TbLpGast.Text = ListGridLp[indice].LpGridGast;
                    TbLpCheq.Text = ListGridLp[indice].LpGridCheq;
                    TbLpMoed.Text = ListGridLp[indice].LpGridMoed;
                    TbLpFalt.Text = ListGridLp[indice].LpGridFalt;
                    TbLpSob.Text = ListGridLp[indice].LpGridSob;
                    TbLpObs.Text = ListGridLp[indice].LpGridObs;
                }
            }
        }
        private void TbxsEditPlan(object sender, EventArgs e)
        {
           // TexboxFormat.Moeda(ref TbLpDep);
           // TexboxFormat.Moeda(ref TbLpGast);
           // TexboxFormat.Moeda(ref TbLpCheq);
           // TexboxFormat.Moeda(ref TbLpMoed);
           // TexboxFormat.Moeda(ref TbLpFalt);
           // TexboxFormat.Moeda(ref TbLpSob);
            Calculo();
        }
        private void Calculo()
        {
            if (TbLpDep.Text != "" && TbLpGast.Text != "" && TbLpCheq.Text != "" &&
                TbLpMoed.Text != "" && TbLpFalt.Text != "" && TbLpSob.Text != "")
            {
                n1 = Convert.ToDouble(TbLpDep.Text.Replace("R$ ", ""));
                n2 = Convert.ToDouble(TbLpGast.Text.Replace("R$ ", ""));
                n3 = Convert.ToDouble(TbLpCheq.Text.Replace("R$ ", ""));
                n4 = Convert.ToDouble(TbLpMoed.Text.Replace("R$ ", ""));
                n5 = Convert.ToDouble(TbLpSob.Text.Replace("R$ ", ""));
                n6 = Convert.ToDouble(TbLpFalt.Text.Replace("R$ ", ""));

                total = n1 + n2 + n3 + n4 - n5 + n6;

                TbLpTot.Text = string.Format("{0:C}", total);
            }
        }
        private void TbxLpDow(object sender, KeyEventArgs e)
        {// proibe o uso do DEL
            if (e.KeyData == Keys.Delete)
            {
                e.Handled = true;
                //  TbDeposito.Text = "R$ 0,00";
            }
        }
        private void TbxLpKeyPress(object sender, KeyPressEventArgs e)
        {
            //Sao as texbox TbSaida TbVolta TbDeposito TbGasto TbCheque TbMoeda TbFalta TbSobra
            TbLpDep.Select(TbLpDep.Text.Length, 0);//Vai colocar o cursor sempre no final
            TbLpGast.Select(TbLpGast.Text.Length, 0);
            TbLpCheq.Select(TbLpCheq.Text.Length, 0);
            TbLpMoed.Select(TbLpMoed.Text.Length, 0);
            TbLpFalt.Select(TbLpFalt.Text.Length, 0);
            TbLpSob.Select(TbLpSob.Text.Length, 0);
            //Proibe digitacao de letras
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)8)
                e.Handled = true;
        }
        private void TbxLpClick(object sender, EventArgs e)
        {
            TbLpDep.Select(TbLpDep.Text.Length, 0);//Vai colocar o cursor sempre no final
            TbLpGast.Select(TbLpGast.Text.Length, 0);
            TbLpCheq.Select(TbLpCheq.Text.Length, 0);
            TbLpMoed.Select(TbLpMoed.Text.Length, 0);
            TbLpFalt.Select(TbLpFalt.Text.Length, 0);
            TbLpSob.Select(TbLpSob.Text.Length, 0);
        }
    }
}