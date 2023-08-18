using start.Class;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Windows.Forms;
using static DB.SQLiteDB;

namespace start
{
    public partial class AddRota : MetroFramework.Forms.MetroForm
    {
        private readonly Home HomeObjects;
        private List<RouteManeger> ListGrid;

        public AddRota(Home FormHome)
        { 
            InitializeComponent();
            this.StyleManager = StyleMangerAddRot;
            HomeObjects = FormHome;
            ListGrid = RouteManeger.ListarRotas();
            ListGridRota.DataSource = ListGrid;
            ListGridRota.Columns[0].Width = 400;
            ListGridRota.Columns[0].Resizable = DataGridViewTriState.False;
        }
        private void BttAddRota_Click(object sender, EventArgs e)
        {
            if (TbAddRota.Text != "" && TbAddRota.Text.Length > 3)
            {
                List<ConditionWhere> values = new List<ConditionWhere>
                {
                    new ConditionWhere("@route", TbAddRota.Text.ToUpper()),
                };
                SQLiteDataReader listRoute = QuerySelect("SELECT route FROM routes WHERE route=@route AND deleted_at IS NULL", values);
                if (!listRoute.Read())
                {
                    QueryInsert("INSERT INTO routes(route) VALUES(@route)", values);
                    HomeObjects.ComboBoxRoute.Items.Add(TbAddRota.Text.ToUpper());
                    HomeObjects.ComboBoxRoute.Refresh();
                    TbAddRota.Clear();
                    ListGrid = RouteManeger.ListarRotas();
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
                RouteManeger.ExcluirItemRota(ListGrid[indice].Nome);
                ListGrid = RouteManeger.ListarRotas();
                ListGridRota.DataSource = ListGrid;
                HomeObjects.ComboBoxRoute.Items.RemoveAt(indice);
                HomeObjects.ComboBoxRoute.Refresh();
            }
        }
    }
}