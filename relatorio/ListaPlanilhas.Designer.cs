﻿namespace start
{
    partial class ListaPlanilhas
    {
        /// <summary> 
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Designer de Componentes

        /// <summary> 
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ListaPlanilhas));
            this.LpGrid = new System.Windows.Forms.DataGridView();
            this.TbLpSaida = new System.Windows.Forms.TextBox();
            this.TbLpVolta = new System.Windows.Forms.TextBox();
            this.TbLpDep = new System.Windows.Forms.TextBox();
            this.TbLpGast = new System.Windows.Forms.TextBox();
            this.TbLpCheq = new System.Windows.Forms.TextBox();
            this.TbLpMoed = new System.Windows.Forms.TextBox();
            this.TbLpFalt = new System.Windows.Forms.TextBox();
            this.TbLpSob = new System.Windows.Forms.TextBox();
            this.TbLpFunc = new System.Windows.Forms.TextBox();
            this.TbLpRota = new System.Windows.Forms.TextBox();
            this.TbLpObs = new System.Windows.Forms.TextBox();
            this.TbLpTot = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.BtnPrint = new System.Windows.Forms.Button();
            this.CbPrints = new System.Windows.Forms.ComboBox();
            this.TbStock = new System.Windows.Forms.TextBox();
            this.TbProducion = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.TbStockFinish = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.LpGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // LpGrid
            // 
            this.LpGrid.AllowUserToAddRows = false;
            this.LpGrid.AllowUserToDeleteRows = false;
            this.LpGrid.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.LpGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.LpGrid.CausesValidation = false;
            this.LpGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.LpGrid.Location = new System.Drawing.Point(16, 415);
            this.LpGrid.MultiSelect = false;
            this.LpGrid.Name = "LpGrid";
            this.LpGrid.ReadOnly = true;
            this.LpGrid.RowHeadersVisible = false;
            this.LpGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.LpGrid.Size = new System.Drawing.Size(544, 183);
            this.LpGrid.TabIndex = 28;
            this.LpGrid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.LpGrid_CellClick);
            // 
            // TbLpSaida
            // 
            this.TbLpSaida.Location = new System.Drawing.Point(82, 97);
            this.TbLpSaida.Name = "TbLpSaida";
            this.TbLpSaida.Size = new System.Drawing.Size(116, 20);
            this.TbLpSaida.TabIndex = 29;
            this.TbLpSaida.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TbxLpKeyPress);
            // 
            // TbLpVolta
            // 
            this.TbLpVolta.Location = new System.Drawing.Point(368, 93);
            this.TbLpVolta.Name = "TbLpVolta";
            this.TbLpVolta.Size = new System.Drawing.Size(116, 20);
            this.TbLpVolta.TabIndex = 30;
            this.TbLpVolta.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TbxLpKeyPress);
            // 
            // TbLpDep
            // 
            this.TbLpDep.Location = new System.Drawing.Point(82, 136);
            this.TbLpDep.Name = "TbLpDep";
            this.TbLpDep.Size = new System.Drawing.Size(116, 20);
            this.TbLpDep.TabIndex = 31;
            this.TbLpDep.Text = "R$ 0,00";
            this.TbLpDep.Click += new System.EventHandler(this.TbxLpClick);
            this.TbLpDep.TextChanged += new System.EventHandler(this.TbxsEditPlan);
            this.TbLpDep.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TbxLpDow);
            this.TbLpDep.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TbxLpKeyPress);
            // 
            // TbLpGast
            // 
            this.TbLpGast.Location = new System.Drawing.Point(368, 135);
            this.TbLpGast.Name = "TbLpGast";
            this.TbLpGast.Size = new System.Drawing.Size(116, 20);
            this.TbLpGast.TabIndex = 32;
            this.TbLpGast.Text = "R$ 0,00";
            this.TbLpGast.Click += new System.EventHandler(this.TbxLpClick);
            this.TbLpGast.TextChanged += new System.EventHandler(this.TbxsEditPlan);
            this.TbLpGast.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TbxLpDow);
            this.TbLpGast.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TbxLpKeyPress);
            // 
            // TbLpCheq
            // 
            this.TbLpCheq.Location = new System.Drawing.Point(82, 180);
            this.TbLpCheq.Name = "TbLpCheq";
            this.TbLpCheq.Size = new System.Drawing.Size(116, 20);
            this.TbLpCheq.TabIndex = 33;
            this.TbLpCheq.Text = "R$ 0,00";
            this.TbLpCheq.Click += new System.EventHandler(this.TbxLpClick);
            this.TbLpCheq.TextChanged += new System.EventHandler(this.TbxsEditPlan);
            this.TbLpCheq.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TbxLpDow);
            this.TbLpCheq.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TbxLpKeyPress);
            // 
            // TbLpMoed
            // 
            this.TbLpMoed.Location = new System.Drawing.Point(368, 180);
            this.TbLpMoed.Name = "TbLpMoed";
            this.TbLpMoed.Size = new System.Drawing.Size(116, 20);
            this.TbLpMoed.TabIndex = 34;
            this.TbLpMoed.Text = "R$ 0,00";
            this.TbLpMoed.Click += new System.EventHandler(this.TbxLpClick);
            this.TbLpMoed.TextChanged += new System.EventHandler(this.TbxsEditPlan);
            this.TbLpMoed.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TbxLpDow);
            this.TbLpMoed.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TbxLpKeyPress);
            // 
            // TbLpFalt
            // 
            this.TbLpFalt.Location = new System.Drawing.Point(82, 222);
            this.TbLpFalt.Name = "TbLpFalt";
            this.TbLpFalt.Size = new System.Drawing.Size(116, 20);
            this.TbLpFalt.TabIndex = 35;
            this.TbLpFalt.Text = "R$ 0,00";
            this.TbLpFalt.Click += new System.EventHandler(this.TbxLpClick);
            this.TbLpFalt.TextChanged += new System.EventHandler(this.TbxsEditPlan);
            this.TbLpFalt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TbxLpDow);
            this.TbLpFalt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TbxLpKeyPress);
            // 
            // TbLpSob
            // 
            this.TbLpSob.Location = new System.Drawing.Point(368, 219);
            this.TbLpSob.Name = "TbLpSob";
            this.TbLpSob.Size = new System.Drawing.Size(116, 20);
            this.TbLpSob.TabIndex = 36;
            this.TbLpSob.Text = "R$ 0,00";
            this.TbLpSob.Click += new System.EventHandler(this.TbxLpClick);
            this.TbLpSob.TextChanged += new System.EventHandler(this.TbxsEditPlan);
            this.TbLpSob.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TbxLpDow);
            this.TbLpSob.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TbxLpKeyPress);
            // 
            // TbLpFunc
            // 
            this.TbLpFunc.Enabled = false;
            this.TbLpFunc.Location = new System.Drawing.Point(175, 58);
            this.TbLpFunc.Name = "TbLpFunc";
            this.TbLpFunc.Size = new System.Drawing.Size(223, 20);
            this.TbLpFunc.TabIndex = 37;
            // 
            // TbLpRota
            // 
            this.TbLpRota.Enabled = false;
            this.TbLpRota.Location = new System.Drawing.Point(175, 16);
            this.TbLpRota.Name = "TbLpRota";
            this.TbLpRota.Size = new System.Drawing.Size(223, 20);
            this.TbLpRota.TabIndex = 38;
            // 
            // TbLpObs
            // 
            this.TbLpObs.Location = new System.Drawing.Point(16, 270);
            this.TbLpObs.Name = "TbLpObs";
            this.TbLpObs.Size = new System.Drawing.Size(544, 20);
            this.TbLpObs.TabIndex = 39;
            // 
            // TbLpTot
            // 
            this.TbLpTot.Enabled = false;
            this.TbLpTot.Location = new System.Drawing.Point(274, 308);
            this.TbLpTot.Name = "TbLpTot";
            this.TbLpTot.Size = new System.Drawing.Size(116, 20);
            this.TbLpTot.TabIndex = 40;
            this.TbLpTot.Text = "R$ 0,00";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(485, 623);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 41;
            this.button1.Text = "Sair";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.BtnLpOk_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(485, 339);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 42;
            this.button2.Text = "Salvar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.BtnLpSave_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(404, 340);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 43;
            this.button3.Text = "Excluir";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.BtnLpDel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(134, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 44;
            this.label1.Text = "Rota";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(312, 183);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 45;
            this.label2.Text = "Moeda";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 187);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 46;
            this.label3.Text = "Cheque";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(317, 139);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 47;
            this.label4.Text = "Gasto";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(5, 143);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 13);
            this.label5.TabIndex = 48;
            this.label5.Text = "Depósito";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(321, 97);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(31, 13);
            this.label6.TabIndex = 49;
            this.label6.Text = "Volta";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(20, 100);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(36, 13);
            this.label7.TabIndex = 50;
            this.label7.Text = "Saída";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(102, 61);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(62, 13);
            this.label8.TabIndex = 51;
            this.label8.Text = "Funcionário";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(230, 251);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(70, 13);
            this.label9.TabIndex = 52;
            this.label9.Text = "Observações";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(317, 225);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(35, 13);
            this.label10.TabIndex = 53;
            this.label10.Text = "Sobra";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(24, 226);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(30, 13);
            this.label11.TabIndex = 54;
            this.label11.Text = "Falta";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(237, 311);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(31, 13);
            this.label12.TabIndex = 55;
            this.label12.Text = "Total";
            // 
            // BtnPrint
            // 
            this.BtnPrint.Location = new System.Drawing.Point(16, 623);
            this.BtnPrint.Name = "BtnPrint";
            this.BtnPrint.Size = new System.Drawing.Size(75, 23);
            this.BtnPrint.TabIndex = 56;
            this.BtnPrint.Text = "Imprimir";
            this.BtnPrint.UseVisualStyleBackColor = true;
            this.BtnPrint.Click += new System.EventHandler(this.BtnPrint_Click);
            // 
            // CbPrints
            // 
            this.CbPrints.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CbPrints.FormattingEnabled = true;
            this.CbPrints.Location = new System.Drawing.Point(97, 625);
            this.CbPrints.Name = "CbPrints";
            this.CbPrints.Size = new System.Drawing.Size(171, 21);
            this.CbPrints.TabIndex = 57;
            // 
            // TbStock
            // 
            this.TbStock.Location = new System.Drawing.Point(82, 308);
            this.TbStock.Name = "TbStock";
            this.TbStock.Size = new System.Drawing.Size(116, 20);
            this.TbStock.TabIndex = 58;
            this.TbStock.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TbxLpKeyPress);
            this.TbStock.Leave += new System.EventHandler(this.TbProducion_Leave);
            // 
            // TbProducion
            // 
            this.TbProducion.Location = new System.Drawing.Point(80, 339);
            this.TbProducion.Name = "TbProducion";
            this.TbProducion.Size = new System.Drawing.Size(116, 20);
            this.TbProducion.TabIndex = 59;
            this.TbProducion.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TbxLpKeyPress);
            this.TbProducion.Leave += new System.EventHandler(this.TbProducion_Leave);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(13, 344);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(53, 13);
            this.label13.TabIndex = 60;
            this.label13.Text = "Produção";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(14, 311);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(46, 13);
            this.label14.TabIndex = 61;
            this.label14.Text = "Estoque";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(15, 381);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(71, 13);
            this.label15.TabIndex = 63;
            this.label15.Text = "Estoque Final";
            // 
            // TbStockFinish
            // 
            this.TbStockFinish.Enabled = false;
            this.TbStockFinish.Location = new System.Drawing.Point(92, 378);
            this.TbStockFinish.Name = "TbStockFinish";
            this.TbStockFinish.Size = new System.Drawing.Size(114, 20);
            this.TbStockFinish.TabIndex = 62;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(95, 609);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(131, 13);
            this.label16.TabIndex = 64;
            this.label16.Text = "Selecione uma Impressora";
            // 
            // ListaPlanilhas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(574, 661);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.TbStockFinish);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.TbProducion);
            this.Controls.Add(this.TbStock);
            this.Controls.Add(this.CbPrints);
            this.Controls.Add(this.BtnPrint);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.TbLpTot);
            this.Controls.Add(this.TbLpObs);
            this.Controls.Add(this.TbLpRota);
            this.Controls.Add(this.TbLpFunc);
            this.Controls.Add(this.TbLpSob);
            this.Controls.Add(this.TbLpFalt);
            this.Controls.Add(this.TbLpMoed);
            this.Controls.Add(this.TbLpCheq);
            this.Controls.Add(this.TbLpGast);
            this.Controls.Add(this.TbLpDep);
            this.Controls.Add(this.TbLpVolta);
            this.Controls.Add(this.TbLpSaida);
            this.Controls.Add(this.LpGrid);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(590, 700);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(590, 700);
            this.Name = "ListaPlanilhas";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Planilhas";
            this.TextChanged += new System.EventHandler(this.TbxsEditPlan);
            ((System.ComponentModel.ISupportInitialize)(this.LpGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox TbLpSaida;
        private System.Windows.Forms.TextBox TbLpSob;
        private System.Windows.Forms.TextBox TbLpFalt;
        private System.Windows.Forms.TextBox TbLpMoed;
        private System.Windows.Forms.TextBox TbLpCheq;
        private System.Windows.Forms.TextBox TbLpGast;
        private System.Windows.Forms.TextBox TbLpDep;
        private System.Windows.Forms.TextBox TbLpVolta;
        private System.Windows.Forms.TextBox TbLpRota;
        private System.Windows.Forms.TextBox TbLpFunc;
        private System.Windows.Forms.TextBox TbLpTot;
        private System.Windows.Forms.TextBox TbLpObs;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.DataGridView LpGrid;
        private System.Windows.Forms.Button BtnPrint;
        private System.Windows.Forms.ComboBox CbPrints;
        private System.Windows.Forms.TextBox TbStock;
        private System.Windows.Forms.TextBox TbProducion;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox TbStockFinish;
        private System.Windows.Forms.Label label16;
    }
}
