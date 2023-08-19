using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Xml.Linq;
using System.IO;
using HomeClass;
using format;
using System.Data.SQLite;
using static DB.SQLiteDB;

namespace start
{
    public partial class Home : Form
    {
        //Declaracao variaveis
        double n1, n2, n3, n4, n5, n6, total;
        public static int VlueIndexGrid { get; private set; }
        public static string DateProprie { get; private set; }
        public string AddRotaList { get; }
        public string AddEmployeeList { get; }
        public static int StyleFoms = 4; //Cor das bordas Azul
        public static int ThemeForm = 1;//Tema Claro
        private List<ClassGridLpHome> ListGrid;

        public Home()
        {
            InitializeComponent();
            DateProprie = DateTime.Now.ToString("dd-MM-yyyy");
            //Carregar A lista de Rostas 
            if (File.Exists("database.db"))
            {
                SQLiteDataReader listRoute = QuerySelect("SELECT route FROM routes WHERE deleted_at IS NULL");
                while (listRoute.Read())
                {
                    AddRotaList = listRoute["route"].ToString();
                    ComboBoxRoute.Items.Add(AddRotaList);
                }
                SQLiteDataReader listEmployee = QuerySelect("SELECT name FROM employees WHERE deleted_at IS NULL");
                while (listEmployee.Read())
                {
                    AddEmployeeList = listEmployee["name"].ToString();
                    CbEmployees.Items.Add(AddEmployeeList);
                }
            }
            else { CreateTable(); }
            
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
        private void CarregarRelatorio ()
        {
           bool consulta = false;

            if (ComboBoxRoute.Text != "")
            {
                XElement xml = XElement.Load(@"cache\" + DateProprie + ".xml");

                foreach (XElement x in xml.Elements("Planilha"))
                {
                    if (ComboBoxRoute.Text == x.Attribute("Rota").Value)
                    {
                        consulta = true;
                        break;
                    }
                }
                if (consulta == false)
                {
                    
                    ListGrid = ClassGridLpHome.ListaRelatorio(DateProprie);
                    // ListGridHome.DataSource = ListGrid;
                }
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

        private void MCfgs_Click(object sender, EventArgs e)
        {   
            Configuracoes FormCfg = new Configuracoes(this);
            FormCfg.ShowDialog();
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