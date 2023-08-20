namespace start
{
    partial class ListRelatorios
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
            this.StyleMagerRf = new MetroFramework.Components.MetroStyleManager(this.components);
            this.GridReports = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.StyleMagerRf)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridReports)).BeginInit();
            this.SuspendLayout();
            // 
            // StyleMagerRf
            // 
            this.StyleMagerRf.Owner = this;
            // 
            // GridReports
            // 
            this.GridReports.AllowUserToAddRows = false;
            this.GridReports.AllowUserToResizeColumns = false;
            this.GridReports.AllowUserToResizeRows = false;
            this.GridReports.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.GridReports.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.GridReports.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.GridReports.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.GridReports.Location = new System.Drawing.Point(12, 27);
            this.GridReports.Name = "GridReports";
            this.GridReports.ReadOnly = true;
            this.GridReports.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.GridReports.RowHeadersVisible = false;
            this.GridReports.RowHeadersWidth = 200;
            this.GridReports.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.GridReports.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.GridReports.Size = new System.Drawing.Size(410, 303);
            this.GridReports.TabIndex = 0;
            this.GridReports.DoubleClick += new System.EventHandler(this.GridReports_DoubleClick);
            // 
            // ListRelatorios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 361);
            this.Controls.Add(this.GridReports);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(450, 400);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(450, 400);
            this.Name = "ListRelatorios";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Tag = "";
            this.Text = "Relatorios";
            ((System.ComponentModel.ISupportInitialize)(this.StyleMagerRf)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridReports)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public MetroFramework.Components.MetroStyleManager StyleMagerRf;
        private System.Windows.Forms.DataGridView GridReports;
    }
}