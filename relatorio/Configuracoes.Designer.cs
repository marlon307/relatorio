namespace start
{
    partial class Configuracoes
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
            this.RadBtnLigth = new MetroFramework.Controls.MetroRadioButton();
            this.RadBtnDark = new MetroFramework.Controls.MetroRadioButton();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.FlpColors = new System.Windows.Forms.FlowLayoutPanel();
            this.MetroStyleCfg = new MetroFramework.Components.MetroStyleManager(this.components);
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.BtnOkClose = new MetroFramework.Controls.MetroButton();
            ((System.ComponentModel.ISupportInitialize)(this.MetroStyleCfg)).BeginInit();
            this.SuspendLayout();
            // 
            // RadBtnLigth
            // 
            this.RadBtnLigth.AutoSize = true;
            this.RadBtnLigth.Location = new System.Drawing.Point(23, 129);
            this.RadBtnLigth.Name = "RadBtnLigth";
            this.RadBtnLigth.Size = new System.Drawing.Size(51, 15);
            this.RadBtnLigth.TabIndex = 0;
            this.RadBtnLigth.Text = "Claro";
            this.RadBtnLigth.UseSelectable = true;
            this.RadBtnLigth.CheckedChanged += new System.EventHandler(this.RadioBtnChecked);
            // 
            // RadBtnDark
            // 
            this.RadBtnDark.AutoSize = true;
            this.RadBtnDark.Location = new System.Drawing.Point(80, 129);
            this.RadBtnDark.Name = "RadBtnDark";
            this.RadBtnDark.Size = new System.Drawing.Size(58, 15);
            this.RadBtnDark.TabIndex = 1;
            this.RadBtnDark.Text = "Escuro";
            this.RadBtnDark.UseSelectable = true;
            this.RadBtnDark.CheckedChanged += new System.EventHandler(this.RadioBtnChecked);
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(21, 107);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(40, 19);
            this.metroLabel1.TabIndex = 2;
            this.metroLabel1.Text = "Tema";
            // 
            // FlpColors
            // 
            this.FlpColors.BackColor = System.Drawing.Color.Transparent;
            this.FlpColors.Location = new System.Drawing.Point(23, 170);
            this.FlpColors.Name = "FlpColors";
            this.FlpColors.Size = new System.Drawing.Size(151, 113);
            this.FlpColors.TabIndex = 3;
            // 
            // MetroStyleCfg
            // 
            this.MetroStyleCfg.Owner = this;
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(22, 148);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(39, 19);
            this.metroLabel2.TabIndex = 4;
            this.metroLabel2.Text = "Estilo";
            // 
            // BtnOkClose
            // 
            this.BtnOkClose.Location = new System.Drawing.Point(23, 419);
            this.BtnOkClose.Name = "BtnOkClose";
            this.BtnOkClose.Size = new System.Drawing.Size(75, 23);
            this.BtnOkClose.TabIndex = 5;
            this.BtnOkClose.Text = "OK";
            this.BtnOkClose.UseSelectable = true;
            this.BtnOkClose.Click += new System.EventHandler(this.BtnOkClose_Click);
            // 
            // Configuracoes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(442, 465);
            this.Controls.Add(this.BtnOkClose);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.FlpColors);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.RadBtnDark);
            this.Controls.Add(this.RadBtnLigth);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Configuracoes";
            this.Resizable = false;
            this.ShadowType = MetroFramework.Forms.MetroFormShadowType.AeroShadow;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Style = MetroFramework.MetroColorStyle.Default;
            this.Text = "Configuracoes";
            this.Theme = MetroFramework.MetroThemeStyle.Default;
            ((System.ComponentModel.ISupportInitialize)(this.MetroStyleCfg)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroRadioButton RadBtnLigth;
        private MetroFramework.Controls.MetroRadioButton RadBtnDark;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        public MetroFramework.Components.MetroStyleManager MetroStyleCfg;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        public System.Windows.Forms.FlowLayoutPanel FlpColors;
        private MetroFramework.Controls.MetroButton BtnOkClose;
    }
}