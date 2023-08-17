using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;
using DB;

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
                DataTable listRoute = DB.SQLiteDB.QuerySelect("SELECT name FROM rotas;");
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
               
                if(consulta == false)
                {
                    DB.SQLiteDB.QueryInsert("INSERT INTO rotas(name) VALUES(@name)");
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