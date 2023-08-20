using start.Class;
using System.Collections.Generic;
using System.Windows.Forms;

namespace start
{
    public partial class ListRelatorios : Form
    {
        private readonly List<ReportsManeger> listGridReports;
        public string reporteDate = null;
        public ListRelatorios()
        {
            InitializeComponent();
            listGridReports = ReportsManeger.ListReports();
            GridReports.DataSource = listGridReports;
            GridReports.Columns[0].Width = 200;
            GridReports.Columns[1].Width = 200;
        }
        private void GridReports_DoubleClick(object sender, System.EventArgs e)
        {
            if (GridReports.CurrentCell != null)
            {
                int index = GridReports.CurrentCell.RowIndex;
                reporteDate = listGridReports[index].Data;
                ListaPlanilhas FormReportDate = new ListaPlanilhas(this);
                FormReportDate.ShowDialog();
            }
        }
    }
}
