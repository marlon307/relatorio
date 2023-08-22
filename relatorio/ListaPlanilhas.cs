using System;
using System.Collections.Generic;
using System.Windows.Forms;
using format;
using start.Class;
using static start.Class.WorksheetsManeger;

namespace start
{
    public partial class ListaPlanilhas : Form
    {
        private List<WorksheetsManeger> ListGridLp;
        private readonly ListRelatorios FormListWorkSeeths;
        double n1, n2, n3, n4, n5, n6, total;

        public ListaPlanilhas(ListRelatorios WorkSheetsForm)
        {
            InitializeComponent();

            FormListWorkSeeths = WorkSheetsForm;
            ListGridLp = WorksheetsManeger.ListAllWorkSheets(WorkSheetsForm.reporteDate);
            LpGrid.DataSource = ListGridLp;

            TbLpRota.Text = ListGridLp[0].Rota;
            TbLpFunc.Text = ListGridLp[0].Funcionário;
          //  TbLpSaida.Text = ListGridLp[0].LpGridSaiu;
           // TbLpVolta.Text = ListGridLp[0].LpGridVolta;
            TbLpDep.Text = ListGridLp[0].Deposito;
            TbLpGast.Text = ListGridLp[0].Gasto;
            TbLpCheq.Text = ListGridLp[0].Cheque;
            TbLpMoed.Text = ListGridLp[0].Moedas;
            TbLpFalt.Text = ListGridLp[0].Falta;
            TbLpSob.Text = ListGridLp[0].Sobra;
            TbLpObs.Text = ListGridLp[0].Observações;
            LpGrid.CurrentCell = LpGrid[0, 0];//Vai mante a celula selecionada
        }
        private void BtnLpDel_Click(object sender, EventArgs e)
        {
            if (LpGrid.SelectedRows.Count > 0)
            {
                ListGridLp = WorksheetsManeger.ListAllWorkSheets(FormListWorkSeeths.reporteDate);
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
                FormListWorkSeeths.GridReports.DataSource = ReportsManeger.ListReports();
            }
        }
        private void BtnLpOk_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void BtnLpSave_Click(object sender, EventArgs e)
        {
            if (TbLpRota.Text != "")
            {
                if (LpGrid.CurrentCell != null)
                {
                    int index = LpGrid.CurrentCell.RowIndex;
                    IPropsUpdate valueUpdate = new IPropsUpdate()
                    {
                        Deposit = Convert.ToDouble(TbLpDep.Text.Replace("R$ ", "")).ToString(),
                        Spent = Convert.ToDouble(TbLpGast.Text.Replace("R$ ", "")).ToString(),
                        Cheque = Convert.ToDouble(TbLpCheq.Text.Replace("R$ ", "")).ToString(),
                        Coins = Convert.ToDouble(TbLpMoed.Text.Replace("R$ ", "")).ToString(),
                        Lack = Convert.ToDouble(TbLpSob.Text.Replace("R$ ", "")).ToString(),
                        Leftover = Convert.ToDouble(TbLpFalt.Text.Replace("R$ ", "")).ToString(),
                        QuantityExit = TbLpSaida.Text,
                        QuantityBack = TbLpVolta.Text,
                        Comments = TbLpObs.Text,
                    };
                    WorksheetsManeger.UpdateReport(ListGridLp[index].RecordID, valueUpdate);
                    ListGridLp = WorksheetsManeger.ListAllWorkSheets(FormListWorkSeeths.reporteDate);
                    LpGrid.DataSource = ListGridLp;
                }
            }
        }
        private void LpGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (LpGrid.CurrentCell != null)
            {
                int index = LpGrid.CurrentCell.RowIndex;
                TbLpRota.Text = ListGridLp[index].Rota;
                TbLpFunc.Text = ListGridLp[index].Funcionário;
                // TbLpSaida.Text = ListGridLp[indice].LpGridSaiu;
                // TbLpVolta.Text = ListGridLp[indice].LpGridVolta;
                TbLpDep.Text = ListGridLp[index].Deposito;
                TbLpGast.Text = ListGridLp[index].Gasto;
                TbLpCheq.Text = ListGridLp[index].Cheque;
                TbLpMoed.Text = ListGridLp[index].Moedas;
                TbLpFalt.Text = ListGridLp[index].Falta;
                TbLpSob.Text = ListGridLp[index].Sobra;
                TbLpObs.Text = ListGridLp[index].Observações;
            }
        }
        private void TbxsEditPlan(object sender, EventArgs e)
        {
            TexboxFormat.Moeda(ref TbLpDep);
            TexboxFormat.Moeda(ref TbLpGast);
            TexboxFormat.Moeda(ref TbLpCheq);
            TexboxFormat.Moeda(ref TbLpMoed);
            TexboxFormat.Moeda(ref TbLpFalt);
            TexboxFormat.Moeda(ref TbLpSob);
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
        {
            if (e.KeyData == Keys.Delete)
            {
                e.Handled = true;
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
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)8) e.Handled = true;
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