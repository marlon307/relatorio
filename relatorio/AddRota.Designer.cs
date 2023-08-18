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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.BttOKAddR = new MetroFramework.Controls.MetroButton();
            this.StyleMangerAddRot = new MetroFramework.Components.MetroStyleManager(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.TbAddRota = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ListGridRota = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.StyleMangerAddRot)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ListGridRota)).BeginInit();
            this.SuspendLayout();
            // 
            // BttOKAddR
            // 
            this.BttOKAddR.Location = new System.Drawing.Point(23, 352);
            this.BttOKAddR.Name = "BttOKAddR";
            this.BttOKAddR.Size = new System.Drawing.Size(75, 23);
            this.BttOKAddR.TabIndex = 2;
            this.BttOKAddR.Text = "OK";
            this.BttOKAddR.UseSelectable = true;
            this.BttOKAddR.Click += new System.EventHandler(this.BttOKAddR_Click);
            // 
            // StyleMangerAddRot
            // 
            this.StyleMangerAddRot.Owner = this;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(352, 84);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "ADICIONAR";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.BttAddRota_Click);
            // 
            // TbAddRota
            // 
            this.TbAddRota.Location = new System.Drawing.Point(23, 86);
            this.TbAddRota.Name = "TbAddRota";
            this.TbAddRota.Size = new System.Drawing.Size(323, 20);
            this.TbAddRota.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Nome da Rota";
            // 
            // ListGridRota
            // 
            this.ListGridRota.AllowUserToAddRows = false;
            this.ListGridRota.BackgroundColor = System.Drawing.Color.White;
            this.ListGridRota.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ListGridRota.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.ListGridRota.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.ListGridRota.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.ListGridRota.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.ListGridRota.GridColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ListGridRota.Location = new System.Drawing.Point(23, 145);
            this.ListGridRota.MultiSelect = false;
            this.ListGridRota.Name = "ListGridRota";
            this.ListGridRota.ReadOnly = true;
            this.ListGridRota.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.ListGridRota.RowHeadersVisible = false;
            this.ListGridRota.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToFirstHeader;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.ListGridRota.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.ListGridRota.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.ListGridRota.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ListGridRota.ShowCellToolTips = false;
            this.ListGridRota.ShowEditingIcon = false;
            this.ListGridRota.Size = new System.Drawing.Size(400, 200);
            this.ListGridRota.TabIndex = 7;
            this.ListGridRota.DoubleClick += new System.EventHandler(this.ListGridRota_DoubleClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(195, 129);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Rotas";
            // 
            // AddRota
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(450, 400);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ListGridRota);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TbAddRota);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.BttOKAddR);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(450, 400);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(450, 400);
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
            ((System.ComponentModel.ISupportInitialize)(this.StyleMangerAddRot)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ListGridRota)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private MetroFramework.Controls.MetroButton BttOKAddR;
        public MetroFramework.Components.MetroStyleManager StyleMangerAddRot;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox TbAddRota;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView ListGridRota;
        private System.Windows.Forms.Label label2;
    }
}