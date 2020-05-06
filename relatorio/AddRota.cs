using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;

namespace start
{
    public partial class AddRota : MetroFramework.Forms.MetroForm
    {
        Home HomeObjects;
        private List<ClassGridRota> ListGrid;

        public AddRota(Home frm1)
        { 
            InitializeComponent();
            this.StyleManager = StyleMangerAddRot;
            HomeObjects = frm1;
            ListGrid = ClassGridRota.ListarRotas();
            ListGridRota.DataSource = ListGrid;
        }
        class ClassGridRota
        {
            private string rota;

            public string Rota
            {
                get { return rota; }
                set { rota = value; }
            }
            public static List<ClassGridRota> ListarRotas()
            {
                List<ClassGridRota> List = new List<ClassGridRota>();
                XElement xml = XElement.Load("config.xml");
                foreach (XElement x in xml.Elements())
                {
                    ClassGridRota p = new ClassGridRota()
                    {
                        Rota = x.Attribute("Rota").Value,
                    };
                    List.Add(p);
                }
                return List;
            }
            public static void ExcluirItemRota(string Rota)
            {
                XElement xml = XElement.Load("config.xml");
                XElement x = xml.Elements().Where(p => p.Attribute("Rota").Value.Equals(Rota.ToString())).First();
                if (x != null)
                {
                    x.Remove();
                }
                xml.Save("config.xml"); 
            }
        }
        private void BttAddRota_Click(object sender, EventArgs e)
        {
            bool consulta = false;
            if (TbAddRota.Text != "" && TbAddRota.Text.Length > 3)
            {
                XElement xml = XElement.Load("config.xml");

                foreach (XElement d in xml.Elements("cfgRotas"))
                {
                    if (TbAddRota.Text.ToUpper() == d.Attribute("Rota").Value)
                    {
                        consulta = true;
                        break;
                    }
                }
                if(consulta == false)
                {
                    XElement x = new XElement("cfgRotas");
                    x.Add(new XAttribute("Rota", TbAddRota.Text.ToUpper()));
                    xml.Add(x);
                    xml.Save(@"config.xml");
                    HomeObjects.ComboBoxRota.Items.Add(TbAddRota.Text.ToUpper());
                    HomeObjects.ComboBoxRota.Refresh();
                    TbAddRota.Clear();
                    ListGrid = ClassGridRota.ListarRotas();
                    ListGridRota.DataSource = ListGrid;
                }
                else
                {
                    MetroFramework.MetroMessageBox.Show(this, "\n\n\nJa existe uma rota com este nome.", "Aviso!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                MetroFramework.MetroMessageBox.Show(this, "\n\nAdicione um nome para a ROTA!\nA quantidade de caracteres minimo e (4)\nE clique em ADICIONAR.", "Aviso!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                //-------------------http://denricdenise.info/2015/09/how-to-use-metromessagebox/-------------
            }
        }
        private void BttOKAddR_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //Remover item da combBox e da griviwe com duplo clique
        private void ListGridRota_DoubleClick(object sender, EventArgs e)
        {
            if (ListGridRota.SelectedRows.Count > 0)
            {
                int indice = ListGridRota.SelectedRows[0].Index;
                ClassGridRota.ExcluirItemRota(ListGrid[indice].Rota);
                ListGrid = ClassGridRota.ListarRotas();
                ListGridRota.DataSource = ListGrid;
                HomeObjects.ComboBoxRota.Items.RemoveAt(indice);
                HomeObjects.ComboBoxRota.Refresh();
            }
        }
    }
}