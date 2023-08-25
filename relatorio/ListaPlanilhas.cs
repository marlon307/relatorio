using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
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
        private int currentPageIndex = 0;
        private SQLiteDataReader dataStock;
        public ListaPlanilhas(ListRelatorios WorkSheetsForm)
        {
            InitializeComponent();

            this.Text = string.Format("Relatório - {0}", WorkSheetsForm.reporteDate);
            
            FormListWorkSeeths = WorkSheetsForm;
            ListGridLp = ListAllWorkSheets(WorkSheetsForm.reporteDate);
            dataStock = ReadStock(WorkSheetsForm.reporteDate);
            if(dataStock.Read())
            {
                int vStock = Convert.ToInt32(dataStock["stock"]);
                int vProduction = Convert.ToInt32(dataStock["production"]);
                TbStock.Text = vStock.ToString();
                TbProducion.Text = vProduction.ToString();
                int exit = ListGridLp.Sum((current) => current.RecordID != "0" ? Convert.ToInt32(current.Saída) : 0);
                int back = ListGridLp.Sum((current) => current.RecordID != "0" ? Convert.ToInt32(current.Volta) : 0);
                TbStockFinish.Text = string.Format("{0}", vStock + vProduction + back - exit);
            }

            LpGrid.DataSource = ListGridLp;
            TbLpRota.Text = ListGridLp[0].Rota;
            TbLpFunc.Text = ListGridLp[0].Funcionário;
            TbLpSaida.Text = ListGridLp[0].Saída;
            TbLpVolta.Text = ListGridLp[0].Volta;
            TbLpDep.Text = ListGridLp[0].Depósito;
            TbLpGast.Text = ListGridLp[0].Gasto;
            TbLpCheq.Text = ListGridLp[0].Cheque;
            TbLpMoed.Text = ListGridLp[0].Moedas;
            TbLpFalt.Text = ListGridLp[0].Falta;
            TbLpSob.Text = ListGridLp[0].Sobra;
            TbLpObs.Text = ListGridLp[0].Observações;
            LpGrid.CurrentCell = LpGrid[0, 0];//Vai mante a celula selecionada
            
            CbPrints.Items.Clear();
            foreach (var prinst in System.Drawing.Printing.PrinterSettings.InstalledPrinters)
            {
                CbPrints.Items.Add(prinst);
            }
        }
        private void BtnLpDel_Click(object sender, EventArgs e)
        {
            if (LpGrid.CurrentCell != null)
            {
                int index = LpGrid.CurrentCell.RowIndex;
                DeleteReport(ListGridLp[index].RecordID);
                ListGridLp = ListAllWorkSheets(FormListWorkSeeths.reporteDate);
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
        private void RecalcStock()
        {
            int vStock = Convert.ToInt32(dataStock["stock"]);
            int vProduction = Convert.ToInt32(dataStock["production"]);
            TbStock.Text = vStock.ToString();
            TbProducion.Text = vProduction.ToString();
            int exit = ListGridLp.Sum((current) => current.RecordID != "0" ? Convert.ToInt32(current.Saída) : 0);
            int back = ListGridLp.Sum((current) => current.RecordID != "0" ? Convert.ToInt32(current.Volta) : 0);
            TbStockFinish.Text = string.Format("{0}", vStock + vProduction + back - exit);
        }
        private void BtnLpSave_Click(object sender, EventArgs e)
        {
            if (TbLpRota.Text != "")
            {
                if (LpGrid.CurrentCell != null)
                {
                    IPropsUpdate valueUpdate = new IPropsUpdate()
                    {
                        Deposit = TbLpDep.Text,
                        Spent = TbLpGast.Text,
                        Cheque = TbLpCheq.Text,
                        Coins = TbLpMoed.Text,
                        Lack = TbLpSob.Text,
                        Leftover = TbLpFalt.Text,
                        QuantityExit = TbLpSaida.Text,
                        QuantityBack = TbLpVolta.Text,
                        Comments = TbLpObs.Text,
                    };
                    int index = LpGrid.CurrentCell.RowIndex;
                    UpdateReport(ListGridLp[index].RecordID, valueUpdate);
                    ListGridLp = ListAllWorkSheets(FormListWorkSeeths.reporteDate);
                    LpGrid.DataSource = ListGridLp;
                    RecalcStock();
                }
            }
        }
        // https://www.youtube.com/watch?v=9h7nFpFiOjE&ab_channel=Andr%C3%A9Lima
        // http://www.andrealveslima.com.br/blog/index.php/2017/10/11/imprimindo-informacoes-direto-na-impressora-com-c/
        private void PrintDocumentPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            using (var font = new Font("Arial", 12))
            using (var brush = new SolidBrush(Color.Black))
            using (var pen = new Pen(Color.Black, 1))
            {
                float xPos = e.MarginBounds.Left;
                float yPos = e.MarginBounds.Top;
                float lineHeight = font.GetHeight();

                int maxLinesPerPage = (int)Math.Floor(e.MarginBounds.Height / lineHeight);

                e.Graphics.DrawString($"Relatório - {FormListWorkSeeths.reporteDate}", font, brush, 16, 16);
                
                while (currentPageIndex < ListGridLp.Count)
                {
                    WorksheetsManeger field = ListGridLp[currentPageIndex];

                    // Imprime cada linha de texto
                    float textRoute = e.Graphics.MeasureString($"Rota: {field.Rota}", font).Width + 10;
                    e.Graphics.DrawString($"Rota: {field.Rota}", font, brush, xPos, yPos);
                    e.Graphics.DrawString($"Funcionário: {field.Funcionário}", font, brush, textRoute > 200 ? xPos + textRoute : xPos + 200, yPos);
                    yPos += lineHeight;

                    e.Graphics.DrawString($"Depósito: {field.Depósito}", font, brush, xPos, yPos);
                    float textDeposit = e.Graphics.MeasureString($"Depósito: {field.Depósito}", font).Width + 10;

                    e.Graphics.DrawString($"Gasto: {field.Gasto}", font, brush, textDeposit > 200 ? xPos + textDeposit : xPos + 200, yPos); // Posição ajustada
                    float textSpent = e.Graphics.MeasureString($"Gasto: {field.Gasto}", font).Width + textDeposit + 10;

                    e.Graphics.DrawString($"Cheque: {field.Cheque}", font, brush, textSpent > 400 ? xPos + textSpent : xPos + 400, yPos);
                    
                    yPos += lineHeight;
                    e.Graphics.DrawString($"Moeda: {field.Moedas}", font, brush, xPos, yPos);
                    float textCoin = e.Graphics.MeasureString($"Moeda: {field.Moedas}", font).Width + 10;

                    e.Graphics.DrawString($"Falta: {field.Falta}", font, brush, textCoin > 200 ? xPos + textCoin : xPos + 200, yPos);
                    float textLack = e.Graphics.MeasureString($"Falta: {field.Falta}", font).Width + textCoin + 10;

                    e.Graphics.DrawString($"Sobra: {field.Sobra}", font, brush, textLack > 400 ? xPos + textLack : xPos + 400, yPos);

                    yPos += lineHeight;

                    float textExit = e.Graphics.MeasureString($"Saida: {field.Saída}", font).Width + 10;
                    e.Graphics.DrawString($"Saída: {field.Saída}", font, brush, xPos, yPos); // Posição ajustada
                    e.Graphics.DrawString($"Volta: {field.Volta}", font, brush, textExit > 200 ? xPos + textExit : xPos + 200, yPos);
                    yPos += lineHeight;
                    // A incrementação estar aqui para poder adicionar informações sobre o estoque no último bloco
                    currentPageIndex += 1;
                    if (currentPageIndex == ListGridLp.Count)
                    {
                        e.Graphics.DrawString($"Estoque Inicial: {dataStock["stock"]}", font, brush, xPos, yPos);
                        e.Graphics.DrawString($"Produção: {dataStock["production"]}", font, brush, xPos + 200, yPos);
                        e.Graphics.DrawString($"Estoque Final: {Convert.ToInt32(dataStock["production"]) + Convert.ToInt32(dataStock["stock"]) + Convert.ToInt32(field.Volta) - Convert.ToInt32(field.Saída)}", font, brush, xPos + 400, yPos);

                        yPos += lineHeight;
                    }
                    string observations = $"Observações: {field.Observações}";
                    float observationsWidth = e.Graphics.MeasureString(observations, font).Width;
                    if (observationsWidth > e.MarginBounds.Width)
                    {
                        var words = observations.Split(' ');
                        var lines = new List<string>();
                        string currentLine = "";
                        foreach (var word in words)
                        {
                            string testLine = currentLine.Length > 0 ? currentLine + " " + word : word;
                            float testWidth = e.Graphics.MeasureString(testLine, font).Width;

                            if (testWidth <= e.MarginBounds.Width)
                            {
                                currentLine = testLine;
                            }
                            else
                            {
                                lines.Add(currentLine);
                                currentLine = word;
                            }
                        }
                        lines.Add(currentLine); // Adicionar a última linha
                        foreach (var line in lines)
                        {
                            e.Graphics.DrawString(line, font, brush, xPos, yPos);
                            yPos += lineHeight;
                        }
                    }
                    else
                    {
                        e.Graphics.DrawString(observations, font, brush, xPos, yPos);
                        yPos += lineHeight;
                    }
                    yPos += 10;
                    e.Graphics.DrawLine(pen, xPos, yPos, e.MarginBounds.Right, yPos);
                    yPos += 10;

                    if (yPos + lineHeight * 5 + 20 > e.MarginBounds.Bottom)
                    {
                        e.HasMorePages = true;
                        return;
                    }
                }

                e.HasMorePages = false;
                currentPageIndex = 0; 
            }
        }
        private void BtnPrint_Click(object sender, EventArgs e)
        {
            if (CbPrints.SelectedItem != null)
            {
                using (var printDocument = new System.Drawing.Printing.PrintDocument())
                {
                    printDocument.PrinterSettings.PrinterName = CbPrints.SelectedItem.ToString();
                    printDocument.PrintPage += PrintDocumentPage;
                    printDocument.DocumentName = Text;
                    printDocument.Print();
                }
            }
        }

        private void TbProducion_Leave(object sender, EventArgs e)
        {
            UpdateStock(FormListWorkSeeths.reporteDate, Convert.ToInt32(TbStock.Text), Convert.ToInt32(TbProducion.Text));
            ListGridLp = ListAllWorkSheets(FormListWorkSeeths.reporteDate);
            dataStock = ReadStock(FormListWorkSeeths.reporteDate);
            if (dataStock.Read())
            {
                RecalcStock();
            }
        }

        private void LpGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (LpGrid.CurrentCell != null)
            {
                int index = LpGrid.CurrentCell.RowIndex;
                TbLpRota.Text = ListGridLp[index].Rota;
                TbLpFunc.Text = ListGridLp[index].Funcionário;
                TbLpSaida.Text = ListGridLp[index].Saída;
                TbLpVolta.Text = ListGridLp[index].Volta;
                TbLpDep.Text = ListGridLp[index].Depósito;
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