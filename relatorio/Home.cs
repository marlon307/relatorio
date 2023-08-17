using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Xml.Linq;
using System.IO;
using HomeClass;
using format;
using MetroFramework.Forms;
using MetroFramework;
using System.Data.SQLite;
using static DB.SQLiteDB;

namespace start
{
    public partial class Home : MetroForm
    {
        //Declaracao variaveis
        double n1, n2, n3, n4, n5, n6, total;
        public static int VlueIndexGrid { get; private set; }
        public static string DateProprie { get; private set; }
        public string AddRotaList { get; }
        public static int StyleFoms = 4; //Cor das bordas Azul
        public static int ThemeForm = 1;//Tema Claro
        private List<ClassGridLpHome> ListGrid;

        public Home()
        {
            InitializeComponent();

            this.StyleManager = MetroStyleManager;

            DateProprie = DateTime.Now.ToString("dd-MM-yyyy");

            //Carregar A lista de Rostas 
            if(File.Exists("database.db"))
            {
                SQLiteDataReader listRoute = QuerySelect("SELECT name FROM rotas");
                while (listRoute.Read())
                {
                    AddRotaList = listRoute["name"].ToString();
                    ComboBoxRoute.Items.Add(AddRotaList);
                }
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
                n5 = Convert.ToDouble(TbLeftOver.Text.Replace("R$ ", ""));
                n6 = Convert.ToDouble(TbLack.Text.Replace("R$ ", ""));

                total = n1 + n2 + n3 + n4 - n5 + n6;

                TbTotal.Text = string.Format("{0:C}", total);
            }
        }
        private void TbBCep(object sender, EventArgs e)
        {
            if (TbCep.Text.Length > 7)
            {
                try
                {
                    CEP cep = new CEP(TbCep.Text);
                    TbRua.Text = cep.logradouro.ToUpper();
                    TbBairro.Text = cep.bairro.ToUpper();
                    TbCidade.Text = cep.localidade.ToUpper();
                    TbEstado.Text = cep.uf.ToUpper();
                }
                catch (Exception) { }
            }
        }
        private void BtnLancar_Click(object sender, EventArgs e)
        {
            string nomeArquivo = @"cache\" + DateProprie + ".xml";

            if (!File.Exists(nomeArquivo))
            {
                XDocument xml = new XDocument(new XDeclaration("1.0", "utf-8", ""),new XElement("Xml",
                new XElement("Relatorio", new XElement("NotasAReceber"),new XElement("RotaValue"), new XElement("CtrlEstoque"),
                new XElement("Planilhas", new XElement("Planilha")))));//Cria um novo arquivo XML
                xml.Save(nomeArquivo);
                CarregarRelatorio();
            }
            else
            {
                CarregarRelatorio();
            }
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
            FormRl.StyleMagerRf.Theme = (MetroThemeStyle)ThemeForm;
            FormRl.StyleMagerRf.Style = (MetroColorStyle)StyleFoms;
            FormRl.ShowDialog();
        }
        private void MCfgs_Click(object sender, EventArgs e)
        {   
            Configuracoes FormCfg = new Configuracoes(this);
            FormCfg.MetroStyleCfg.Theme = (MetroThemeStyle)ThemeForm;
            FormCfg.MetroStyleCfg.Style = (MetroColorStyle)StyleFoms;
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
            TexboxFormat.Moeda(ref TbLack);
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