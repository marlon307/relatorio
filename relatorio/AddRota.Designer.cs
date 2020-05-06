namespace start
{
    partial class AddRota
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.TbAddRota = new MetroFramework.Controls.MetroTextBox();
            this.BttAddRota = new MetroFramework.Controls.MetroButton();
            this.BttOKAddR = new MetroFramework.Controls.MetroButton();
            this.ListGridRota = new MetroFramework.Controls.MetroGrid();
            this.Rota = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StyleMangerAddRot = new MetroFramework.Components.MetroStyleManager(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.ListGridRota)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StyleMangerAddRot)).BeginInit();
            this.SuspendLayout();
            // 
            // TbAddRota
            // 
            // 
            // 
            // 
            this.TbAddRota.CustomButton.Image = null;
            this.TbAddRota.CustomButton.Location = new System.Drawing.Point(301, 1);
            this.TbAddRota.CustomButton.Name = "";
            this.TbAddRota.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.TbAddRota.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.TbAddRota.CustomButton.TabIndex = 1;
            this.TbAddRota.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.TbAddRota.CustomButton.UseSelectable = true;
            this.TbAddRota.CustomButton.Visible = false;
            this.TbAddRota.Lines = new string[0];
            this.TbAddRota.Location = new System.Drawing.Point(23, 63);
            this.TbAddRota.MaxLength = 32767;
            this.TbAddRota.Name = "TbAddRota";
            this.TbAddRota.PasswordChar = '\0';
            this.TbAddRota.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.TbAddRota.SelectedText = "";
            this.TbAddRota.SelectionLength = 0;
            this.TbAddRota.SelectionStart = 0;
            this.TbAddRota.ShortcutsEnabled = true;
            this.TbAddRota.Size = new System.Drawing.Size(323, 23);
            this.TbAddRota.TabIndex = 0;
            this.TbAddRota.UseSelectable = true;
            this.TbAddRota.WaterMark = "DIGITE AQUI UM NOME PARA ROTA";
            this.TbAddRota.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.TbAddRota.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // BttAddRota
            // 
            this.BttAddRota.Location = new System.Drawing.Point(352, 63);
            this.BttAddRota.Name = "BttAddRota";
            this.BttAddRota.Size = new System.Drawing.Size(75, 23);
            this.BttAddRota.TabIndex = 1;
            this.BttAddRota.Text = "ADICIONAR";
            this.BttAddRota.UseSelectable = true;
            this.BttAddRota.Click += new System.EventHandler(this.BttAddRota_Click);
            // 
            // BttOKAddR
            // 
            this.BttOKAddR.Location = new System.Drawing.Point(23, 266);
            this.BttOKAddR.Name = "BttOKAddR";
            this.BttOKAddR.Size = new System.Drawing.Size(75, 23);
            this.BttOKAddR.TabIndex = 2;
            this.BttOKAddR.Text = "OK";
            this.BttOKAddR.UseSelectable = true;
            this.BttOKAddR.Click += new System.EventHandler(this.BttOKAddR_Click);
            // 
            // ListGridRota
            // 
            this.ListGridRota.AllowUserToAddRows = false;
            this.ListGridRota.AllowUserToResizeRows = false;
            this.ListGridRota.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.ListGridRota.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ListGridRota.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.ListGridRota.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle4.Padding = new System.Windows.Forms.Padding(3);
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ListGridRota.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.ListGridRota.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Rota});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.ListGridRota.DefaultCellStyle = dataGridViewCellStyle5;
            this.ListGridRota.EnableHeadersVisualStyles = false;
            this.ListGridRota.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.ListGridRota.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.ListGridRota.Location = new System.Drawing.Point(23, 92);
            this.ListGridRota.Name = "ListGridRota";
            this.ListGridRota.ReadOnly = true;
            this.ListGridRota.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ListGridRota.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.ListGridRota.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.ListGridRota.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ListGridRota.Size = new System.Drawing.Size(400, 168);
            this.ListGridRota.TabIndex = 3;
            this.ListGridRota.DoubleClick += new System.EventHandler(this.ListGridRota_DoubleClick);
            // 
            // Rota
            // 
            this.Rota.DataPropertyName = "Rota";
            this.Rota.HeaderText = "ROSTAS EXISTENTES";
            this.Rota.MaxInputLength = 50;
            this.Rota.MinimumWidth = 342;
            this.Rota.Name = "Rota";
            this.Rota.ReadOnly = true;
            this.Rota.Width = 342;
            // 
            // StyleMangerAddRot
            // 
            this.StyleMangerAddRot.Owner = this;
            // 
            // AddRota
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(450, 300);
            this.Controls.Add(this.ListGridRota);
            this.Controls.Add(this.BttOKAddR);
            this.Controls.Add(this.BttAddRota);
            this.Controls.Add(this.TbAddRota);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(450, 300);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(450, 300);
            this.Name = "AddRota";
            this.Resizable = false;
            this.ShadowType = MetroFramework.Forms.MetroFormShadowType.AeroShadow;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Style = MetroFramework.MetroColorStyle.Default;
            this.Text = "Adicionar/Remover uma Rota";
            this.Theme = MetroFramework.MetroThemeStyle.Default;
            ((System.ComponentModel.ISupportInitialize)(this.ListGridRota)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StyleMangerAddRot)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private MetroFramework.Controls.MetroButton BttAddRota;
        private MetroFramework.Controls.MetroButton BttOKAddR;
        public MetroFramework.Controls.MetroTextBox TbAddRota;
        private MetroFramework.Controls.MetroGrid ListGridRota;
        private System.Windows.Forms.DataGridViewTextBoxColumn Rota;
        public MetroFramework.Components.MetroStyleManager StyleMangerAddRot;
    }
}