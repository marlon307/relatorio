using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;
using format;
using System.Data.SQLite;
using static DB.SQLiteDB;
using System.Globalization;
using start.Class;

namespace start
{
    public partial class Home : Form
    {
        //Declaracao variaveis
        double n1, n2, n3, n4, n5, n6, total;
        public static string DateProprie { get; private set; }
        public string AddRotaList { get; }
        private readonly int idReport = 0;
        public string AddEmployeeList { get; }

        public Home()
        {
            InitializeComponent();
            DateProprie = DateTime.Now.ToString("dd-MM-yyyy");
            //Carregar A lista de Rostas 
            if (File.Exists("database.db"))
            {
                SQLiteDataReader isReport = QuerySelect("SELECT id, date FROM reports WHERE date = DATE()");
                if(!isReport.Read())
                {
                    idReport = QueryInsert("INSERT INTO reports(date) VALUES(DATE())");
                }
                if (idReport == 0)
                {
                    idReport = Convert.ToInt32(isReport["id"]);
                }
                SQLiteDataReader listRoute = QuerySelect("SELECT id, route FROM routes WHERE deleted_at IS NULL");
                while(listRoute.Read())
                {
                    ComboBoxRoute.Items.Add(new ComboBoxItem(listRoute["id"].ToString(), listRoute["route"].ToString()));
                }
                SQLiteDataReader listEmployee = QuerySelect("SELECT id, name FROM employees WHERE deleted_at IS NULL");
                while (listEmployee.Read())
                {
                    CbEmployees.Items.Add(new ComboBoxItem(listEmployee["id"].ToString(), listEmployee["name"].ToString()));
                }
            }
            else {
                CreateTable();
                QueryInsert("INSERT INTO reports(date) VALUES(DATE())");
            }
        }
        private void Calculo()
        {
            if (TbSpent.Text != "" && TbDeposit.Text != "" && TbCheque.Text != "" &&
                TbCoin.Text != "" && TbLeftOver.Text != "" && TbLack.Text != "")
            {
                n1 = Convert.ToDouble(TbDeposit.Text.Replace("R$ ", ""));
                n2 = Convert.ToDouble(TbSpent.Text.Replace("R$ ", ""));
                n3 = Convert.ToDouble(TbCheque.Text.Replace("R$ ", ""));
                n4 = Convert.ToDouble(TbCoin.Text.Replace("R$ ", ""));
                n5 = Convert.ToDouble(TbLack.Text.Replace("R$ ", ""));
                n6 = Convert.ToDouble(TbLeftOver.Text.Replace("R$ ", ""));
                total = n1 + n2 + n3 + n4 - n5 + n6;
                TbTotal.Text = string.Format("{0:C}", total);
            }
        }
        private void BtnLancar_Click(object sender, EventArgs e)
        {
            if (CbEmployees.SelectedItem != null)
            {
                ComboBoxItem routeSelected = (ComboBoxItem)ComboBoxRoute.SelectedItem;
                string idRouter = routeSelected.ID;
                ComboBoxItem selectedItem = (ComboBoxItem)CbEmployees.SelectedItem;
                string idEmployee = selectedItem.ID;
                List<ConditionWhere> values = new List<ConditionWhere>
                {
                    new ConditionWhere("@report_id", idReport.ToString()),
                    new ConditionWhere("@route_id", idRouter),
                    new ConditionWhere("@employee_id", idEmployee),
                    new ConditionWhere("@qtd_exit", TbExit.Text),
                    new ConditionWhere("@qtd_back", TbBack.Text),
                    new ConditionWhere("@deposit", double.Parse(TbDeposit.Text, NumberStyles.Currency).ToString()),
                    new ConditionWhere("@spent", double.Parse(TbSpent.Text, NumberStyles.Currency).ToString()),
                    new ConditionWhere("@cheque", double.Parse(TbCheque.Text, NumberStyles.Currency).ToString()),
                    new ConditionWhere("@coins", double.Parse(TbCoin.Text, NumberStyles.Currency).ToString()),
                    new ConditionWhere("@lack", double.Parse(TbLack.Text, NumberStyles.Currency).ToString()),
                    new ConditionWhere("@leftover",double.Parse(TbLeftOver.Text, NumberStyles.Currency).ToString()),
                    new ConditionWhere("@comments", TbComments.Text.ToUpper()),
                };
                QueryInsert(@"INSERT INTO records(report_id, route_id, employee_id, qtd_exit, qtd_back, deposit, spent, cheque, coins, lack, leftover, comments)
                VALUES(@report_id, @route_id, @employee_id, @qtd_exit, @qtd_back, @deposit, @spent, @cheque, @coins, @lack, @leftover, @comments)", values);
                ComboBoxRoute.Text = null;
                CbEmployees.Text = null;
                TbExit.Text = null;
                TbBack.Text = null;
                TbDeposit.Text = "R$ 0,00";
                TbSpent.Text = "R$ 0,00";
                TbCheque.Text = "R$ 0,00";
                TbCoin.Text = "R$ 0,00";
                TbLack.Text = "R$ 0,00";
                TbLeftOver.Text = "R$ 0,00";
                TbComments.Text = null;
                ComboBoxRoute.Focus();
            }
        }
        private void DateTimeCx_ValueChanged(object sender, EventArgs e)//Selecionar Data para o nome do arquivo
        {
            DateProprie = DateTimeCx.Text.Replace("/", "-");
        }
        private void ListarRel_Click(object sender, EventArgs e)
        {
            ListRelatorios FormRl = new ListRelatorios();
            FormRl.ShowDialog();
        }
        private void AddEmployeeLB_Click(object sender, EventArgs e)
        {
            AddEmployee FormEmployee = new AddEmployee(this);
            FormEmployee.ShowDialog();
        }
        private void LinkAddRota_Click(object sender, EventArgs e)//Vai abrir uma apara para adicionar mais Rotas
        {
            AddRota FormRout = new AddRota(this);
            FormRout.ShowDialog();
        }
        private void OnClickTbRel(object sender, EventArgs e)//------------------Formatacoes no conjunto de texbox Relatorio-----HOME------------
        {
            TbDeposit.Select(TbDeposit.Text.Length, 0);//Vai colocar o cursor sempre no final
            TbSpent.Select(TbSpent.Text.Length, 0);
            TbCheque.Select(TbCheque.Text.Length, 0);
            TbCoin.Select(TbCoin.Text.Length, 0);
            TbLack.Select(TbLack.Text.Length, 0);
            TbLeftOver.Select(TbLeftOver.Text.Length, 0);
        }
        private void KeyPressTbRel(object sender, KeyPressEventArgs e)//Sao as texbox TbSaida TbVolta TbDeposito TbGasto TbCheque TbMoeda TbFalta TbSobra
        {
            TbDeposit.Select(TbDeposit.Text.Length, 0);//Vai colocar o cursor sempre no final
            TbSpent.Select(TbSpent.Text.Length, 0);
            TbCheque.Select(TbCheque.Text.Length, 0);
            TbCoin.Select(TbCoin.Text.Length, 0);
            TbLack.Select(TbLack.Text.Length, 0);
            TbLeftOver.Select(TbLeftOver.Text.Length, 0);
            
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)8)//Proibe digitacao de letras
            {
                e.Handled = true;
            }
        }
        private void TbxMoedFormat(object sender, EventArgs e)
        {
            Calculo();
            TexboxFormat.Moeda(ref TbDeposit);
            TexboxFormat.Moeda(ref TbSpent);
            TexboxFormat.Moeda(ref TbCheque);
            TexboxFormat.Moeda(ref TbCoin);
            TexboxFormat.Moeda(ref TbLack);
            TexboxFormat.Moeda(ref TbLeftOver);
        }
        private void KeyDownRel(object sender, KeyEventArgs e)//Sao as texbox TbDeposito TbGasto TbCheque TbMoeda TbFalta TbSobra
        {
            if (e.KeyData == Keys.Delete)
            {
                e.Handled = true;
            }
        }
    }
}