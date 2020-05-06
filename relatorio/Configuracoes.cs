using System;
using System.Drawing;
using MetroFramework.Controls;
using MetroFramework;
using MetroFramework.Forms;

namespace start
{
    public partial class Configuracoes : MetroForm
    {
        Home ObjectsHome;

        public Configuracoes(Home frm1) 
        {
            InitializeComponent();

            this.StyleManager = MetroStyleCfg;

            ObjectsHome = frm1;

            for (int i = 3; i < 15; i++)//Cria Botoes de cores do Estilo
            {
                MetroTile _tile = new MetroTile
                {
                    Size = new Size(30, 30),
                    Tag = i,
                    Style = (MetroColorStyle)i
                };
                _tile.Click += M_tile_Click;
                FlpColors.Controls.Add(_tile);
            }
        }
        void M_tile_Click(object sender, EventArgs e)
        {
            ObjectsHome.MetroStyleManager.Style = (MetroColorStyle)((MetroTile)sender).Tag;
            MetroStyleCfg.Style = (MetroColorStyle)((MetroTile)sender).Tag;
            Home.StyleFoms = Convert.ToInt16((MetroColorStyle)((MetroTile)sender).Tag);//Armazenar valor do Estilo para aplicar nas outras Fomrs
        }
        private void RadioBtnChecked(object sender, EventArgs e)
        {
            if (RadBtnLigth.Checked)
            {
                ObjectsHome.MetroStyleManager.Theme = MetroThemeStyle.Light;
                MetroStyleCfg.Theme = MetroThemeStyle.Light;
                Home.ThemeForm = 1;//Armazenar valor do Tema para aplicar as outras Fomrs
            }
            if (RadBtnDark.Checked)
            {
                ObjectsHome.MetroStyleManager.Theme = MetroThemeStyle.Dark;
                MetroStyleCfg.Theme = MetroThemeStyle.Dark;
                Home.ThemeForm = 2;
            }
        }
        private void BtnOkClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}