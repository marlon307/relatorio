using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace start
{
    public partial class CtrlEstoque : MetroForm
    {
        public CtrlEstoque()
        {
            InitializeComponent();

            this.StyleManager = StyleManegerCE;
        }
    }
}
