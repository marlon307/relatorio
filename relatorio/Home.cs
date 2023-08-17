using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Xml.Linq;
using System.IO;
using HomeClass;
using format;
using MetroFramework.Forms;
using MetroFramework;

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
            //if(File.Exists("config.xml"))
            //{
              //  XElement xml = XElement.Load("config.xml");
                //foreach (XElement x in xml.Elements())
                //{
                  //  AddRotaList = x.Attribute("Rota").Value;
                    //ComboBoxRota.Items.Add(AddRotaList);
               // }
            //}
        }
        private void Calculo()
        {
            if (TbGasto.Text != "" && TbDeposito.Text != "" && TbCheque.Text != "" &&
                TbMoeda.Text != "" && TbSobra.Text != "" && TbFalta.Text != "")
            {
                n1 = Convert.ToDouble(TbDeposito.Text.Replace("R$ ", ""));
                n2 = Convert.ToDouble(TbGasto.Text.Replace("R$ ", ""));
                n3 = Convert.ToDouble(TbCheque.Text.Replace("R$ ", ""));
                n4 = Convert.ToDouble(TbMoeda.Text.Replace("R$ ", ""));
                n5 = Convert.ToDouble(TbSobra.Text.Replace("R$ ", ""));
                n6 = Convert.ToDouble(TbFalta.Text.Replace("R$ ", ""));

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

            if (ComboBoxRota.Text != "")
            {
                XElement xml = XElement.Load(@"cache\" + DateProprie + ".xml");

                foreach (XElement x in xml.Elements("Planilha"))
                {
                    if (ComboBoxRota.Text == x.Attribute("Rota").Value)
                    {
                        consulta = true;
                        break;
                    }
                }
                if (consulta == false)
                {
                    XElement x = new XElement("Planilha");
                    x.Add(new XAttribute("Rota", ComboBoxRota.Text));
                    x.Add(new XAttribute("Funcionario", TbFuncionario.Text.ToUpper())); TbFuncionario.Clear();
                    x.Add(new XAttribute("SaidaP", TbSaida.Text)); TbSaida.Clear();
                    x.Add(new XAttribute("VoltaP", TbVolta.Text)); TbVolta.Clear();
                    x.Add(new XAttribute("Deposito", TbDeposito.Text)); TbDeposito.Clear();
                    x.Add(new XAttribute("Gasto", TbGasto.Text)); TbGasto.Clear();
                    x.Add(new XAttribute("Cheque", TbCheque.Text)); TbCheque.Clear();
                    x.Add(new XAttribute("Moeda", TbMoeda.Text)); TbMoeda.Clear();
                    x.Add(new XAttribute("Falta", TbFalta.Text)); TbFalta.Clear();
                    x.Add(new XAttribute("Sobra", TbSobra.Text)); TbSobra.Clear();
                    x.Add(new XAttribute("Observacoes", TbObservacao.Text.ToUpper())); TbObservacao.Clear();
                    xml.Add(x);
                    xml.Save(@"cache\" + DateProprie + ".xml");
                    ListGrid = ClassGridLpHome.ListaRelatorio(DateProprie);
                    ListGridHome.DataSource = ListGrid;
                //-------------http://www.linhadecodigo.com.br/artigo/3449/manipulando-arquivos-xml-em-csharp.aspx Estudo XML-------------------*/

                //https://social.msdn.microsoft.com/Forums/pt-BR/user/threads?user=tayler0009

                /*     XmlDocument xml = new XmlDocument();
                     
                     xml.Load(@"cache\" + DateProprie + ".xml");
                     //your customization here
                     XmlNode node = xml.GetElementsByTagName("Planilha")[0];

                     XmlElement x = node as XmlElement;
                     x.SetAttribute("Rota", ComboBoxRota.Text.ToUpper());
                     x.SetAttribute("Funcionario", TbFuncionario.Text.ToUpper());
                     x.SetAttribute("SaidaP", TbSaida.Text);
                     x.SetAttribute("VoltaP", TbVolta.Text);
                     x.SetAttribute("Deposito", TbDeposito.Text);
                     x.SetAttribute("Gasto", TbGasto.Text);
                     x.SetAttribute("Cheque", TbCheque.Text);
                     x.SetAttribute("Moeda", TbMoeda.Text);
                     x.SetAttribute("Falta", TbFalta.Text);
                     x.SetAttribute("Sobra", TbSobra.Text);
                     x.SetAttribute("Observacoes", TbObservacao.Text.ToUpper());
                     xml.Save(@"cache\" + DateProprie + ".xml");*/
                }
            }
        }
        private void DateTimeCx_ValueChanged(object sender, EventArgs e)//Selecionar Data para o nome do arquivo
        {   
            DateProprie = DateTimeCx.Text.Replace("/", "-");
        }
        private void LabelsHover(object sender, EventArgs e)
        {

        }
        private void MouseHoverCxEdit(object sender, EventArgs e)
        {
            if (LbLegenEditPlan.Visible == false)
            {
                if(ListGridHome.SelectedRows.Count > 0)
                {
                    LbLegenEditPlan.Visible = true;
                }
            }
        }
        private void MouseLeavCxEdit(object sender, EventArgs e)
        {
            if(LbLegenEditPlan.Visible == true)
            {
                LbLegenEditPlan.Visible = false;
            }
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
        private void ListGridHome_CellDoubleClick(object sender, DataGridViewCellEventArgs e) //Vai abrir outra aba para excluir ou editar as planilhas
        {
            if (ListGridHome.SelectedRows.Count > 0)
            {
                int indice = ListGridHome.SelectedRows[0].Index;
                VlueIndexGrid = indice;
                ListaPlanilhas FormLp = new ListaPlanilhas(this);
                FormLp.StyleManegerLplan.Theme = (MetroThemeStyle)ThemeForm;
                FormLp.StyleManegerLplan.Style = (MetroColorStyle)StyleFoms;
                FormLp.ShowDialog();
            }
        }
        private void LinkAddRota_Click(object sender, EventArgs e)//Vai abrir uma apara para adicionar mais Rotas
        {
            if (ListGridHome.SelectedRows.Count >= 0)
            { 
                AddRota FormRota = new AddRota(this);
                FormRota.StyleMangerAddRot.Theme = (MetroThemeStyle)ThemeForm;
                FormRota.StyleMangerAddRot.Style = (MetroColorStyle)StyleFoms;
                FormRota.ShowDialog();
            }
        }
        private void OnClickTbRel(object sender, EventArgs e)//------------------Formatacoes no conjunto de texbox Relatorio-----HOME------------
        {
            TbDeposito.Select(TbDeposito.Text.Length, 0);//Vai colocar o cursor sempre no final
            TbGasto.Select(TbGasto.Text.Length, 0);
            TbCheque.Select(TbCheque.Text.Length, 0);
            TbMoeda.Select(TbMoeda.Text.Length, 0);
            TbFalta.Select(TbFalta.Text.Length, 0);
            TbSobra.Select(TbSobra.Text.Length, 0);
        }
        private void KeyPressTbRel(object sender, KeyPressEventArgs e)//Sao as texbox TbSaida TbVolta TbDeposito TbGasto TbCheque TbMoeda TbFalta TbSobra
        {
            TbDeposito.Select(TbDeposito.Text.Length, 0);//Vai colocar o cursor sempre no final
            TbGasto.Select(TbGasto.Text.Length, 0);
            TbCheque.Select(TbCheque.Text.Length, 0);
            TbMoeda.Select(TbMoeda.Text.Length, 0);
            TbFalta.Select(TbFalta.Text.Length, 0);
            TbSobra.Select(TbSobra.Text.Length, 0);
            
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)8)//Proibe digitacao de letras
            {
                e.Handled = true;
            }
        }
        private void TbxMoedFormat(object sender, EventArgs e)
        {
            Calculo();
            TexboxFormat.Moeda(ref TbDeposito);
            TexboxFormat.Moeda(ref TbGasto);
            TexboxFormat.Moeda(ref TbCheque);
            TexboxFormat.Moeda(ref TbMoeda);
            TexboxFormat.Moeda(ref TbFalta);
            TexboxFormat.Moeda(ref TbSobra);
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
/* private void metroButton1_Click(object sender, EventArgs e)
{
   DLL_CLASS_CNPJ.CNPJ cnpj = new DLL_CLASS_CNPJ.CNPJ();
   cnpj.mForm(TbCPFCNPJ.Text, "");//33000167000101
   TbNameF.Text = DLL_CLASS_CNPJ.InfoCNPJ.NomeFantasia;
   TbRasaoS.Text = DLL_CLASS_CNPJ.InfoCNPJ.RazaoSocial;
   TbNumero.Text = DLL_CLASS_CNPJ.InfoCNPJ.EnderecoNumero;
   TbComplento.Text = DLL_CLASS_CNPJ.InfoCNPJ.EnderecoComplemento;
   TbCep.Text = DLL_CLASS_CNPJ.InfoCNPJ.EnderecoCEP;
   TbEmail.Text = DLL_CLASS_CNPJ.InfoCNPJ.Email;
}*/
/*Listar arquivos relatorio ex

DirectoryInfo diretorio = new DirectoryInfo(@"cache");

FileInfo[] Arquivos = diretorio.GetFiles();

foreach (FileInfo arquivo in Arquivos)
{

metroComboBox1.Items.Add(arquivo.Name.Replace(".xml", ""));

}*/