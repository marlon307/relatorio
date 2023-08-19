using start.Class;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Windows.Forms;
using static DB.SQLiteDB;

namespace start
{
    public partial class AddRota : Form
    {
        private readonly Home HomeObjects;
        private List<RouteManeger> ListGrid;
        public AddRota(Home FormHome)
        { 
            InitializeComponent();
            HomeObjects = FormHome;
            ListGrid = RouteManeger.ListarRotas();
            ListGridRota.DataSource = ListGrid;
            ListGridRota.Columns[0].Width = 400;
            ListGridRota.Columns[0].Resizable = DataGridViewTriState.False;
        }
        private void BttAddRota_Click(object sender, EventArgs e)
        {
            if (TbAddRota.Text.Length > 3)
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
                    message.Text = "Ja existe uma rota com este nome.";
                    message.Visible = true;
                }
            }
            else
            {
                message.Text = "Adicione um nome para a ROTA!\nA quantidade de caracteres minimo e (4)\nE clique em ADICIONAR.";
                message.Visible = true;
            }
        }
        private void BttOKAddR_Click(object sender, EventArgs e)
        {
           Close();
        }
        //Remover item da combBox e da griviwe com duplo clique
        private void ListGridRota_DoubleClick(object sender, EventArgs e)
        {
            if (ListGridRota.CurrentCell != null)
            {
                int index = ListGridRota.CurrentCell.RowIndex;
                RouteManeger.ExcluirItemRota(ListGrid[index].Rotas);
                ListGrid = RouteManeger.ListarRotas();
                ListGridRota.DataSource = ListGrid;
                HomeObjects.ComboBoxRoute.Items.RemoveAt(index);
                HomeObjects.ComboBoxRoute.Refresh();
            }
        }
    }
}