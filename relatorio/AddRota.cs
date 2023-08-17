using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Windows.Forms;
using static DB.SQLiteDB;

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
                SQLiteDataReader listRoute = QuerySelect("SELECT name FROM rotas");

                while (listRoute.Read())
                {
                    ClassGridRota p = new ClassGridRota()
                    {
                        Rota = listRoute["name"].ToString(),
                    };
                    List.Add(p);
                }
                return List;
            }
            public static void ExcluirItemRota(string Rota)
            {
                List<ConditionWhere> whereCondition = new List<ConditionWhere>
                {
                    new ConditionWhere("@name", Rota.ToString()),
                };
                QueryDelete("DELETE FROM rotas WHERE name=@name", whereCondition);
            }
        }
        private void BttAddRota_Click(object sender, EventArgs e)
        {
            if (TbAddRota.Text != "" && TbAddRota.Text.Length > 3)
            {
                List<ConditionWhere> values = new List<ConditionWhere>
                {
                    new ConditionWhere("@name", TbAddRota.Text.ToUpper()),
                };
                SQLiteDataReader listRoute = QuerySelect("SELECT name FROM rotas WHERE name=@name", values);
                if (!listRoute.Read())
                {
                    QueryInsert("INSERT INTO rotas(name) VALUES(@name)", values);
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