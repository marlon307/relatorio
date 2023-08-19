using start.Class;
using System.Windows.Forms;

namespace start
{
    public partial class ListRelatorios : Form
    {
        public ListRelatorios()
        {
            InitializeComponent();
            GridReports.DataSource = ReportsManeger.ListReports();
            GridReports.Columns[0].Width = 200;
            GridReports.Columns[1].Width = 200;
        }
    }
}
