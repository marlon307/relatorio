using start.Class;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Windows.Forms;
using static DB.SQLiteDB;

namespace start
{
    public partial class AddEmployee : Form
    {
        private readonly Home HomeObjects;
        private List<EmployeeManeger> ListEmpoyees;
        public AddEmployee(Home FormHome)
        {
            InitializeComponent();
            HomeObjects = FormHome;
            ListEmpoyees = EmployeeManeger.ListEmployess();
            GridEmployee.DataSource = ListEmpoyees;
            GridEmployee.Columns[0].Width = 400;
            GridEmployee.Columns[0].Resizable = DataGridViewTriState.False;
        }
        private void BtnAdd_Click(object sender, EventArgs e)
        {
            if (TbNameEmployee.Text.Length > 3)
            {
                List<ConditionWhere> values = new List<ConditionWhere>
                {
                    new ConditionWhere("@name", TbNameEmployee.Text.ToUpper()),
                };
                SQLiteDataReader listRoute = QuerySelect("SELECT name FROM employees WHERE name=@name AND deleted_at IS NULL", values);
                if (!listRoute.Read())
                {
                    int idRoute = QueryInsert("INSERT INTO employees(name) VALUES(@name)", values);
                    HomeObjects.CbEmployees.Items.Add(new ComboBoxItem(idRoute.ToString(), TbNameEmployee.Text));
                    HomeObjects.CbEmployees.Refresh();
                    ListEmpoyees.Clear();
                    ListEmpoyees = EmployeeManeger.ListEmployess();
                    GridEmployee.DataSource = ListEmpoyees;
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
            }
        }
        private void BtnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void GridEmployee_DoubleClick(object sender, EventArgs e)
        {
            if (GridEmployee.CurrentCell != null)
            {
                int index = GridEmployee.CurrentCell.RowIndex;
                EmployeeManeger.DeleteEmployee(ListEmpoyees[index].Funcionário);
                ListEmpoyees = EmployeeManeger.ListEmployess();
                GridEmployee.DataSource = ListEmpoyees;
                HomeObjects.CbEmployees.Items.RemoveAt(index);
                HomeObjects.CbEmployees.Refresh();
            }
        }
    }
}
