using System;
using System.Linq;
using System.Windows.Forms;

namespace format
{
    public class TexboxFormat
    {
        public static void Moeda(ref TextBox txt)
        {
            try
            {
                string n = string.Empty;
                double v = 0;

                n = new string(txt.Text.Where(char.IsDigit).ToArray());
                if (n.Equals("")) n = "";
                n = n.PadLeft(3, '0');
                if (n.Length > 3 & n.Substring(0, 1) == "0")
                    n = n.Substring(1, n.Length - 1);
                v = Convert.ToDouble(n) / 100;
                txt.Text = string.Format("{0:C}", v);
                txt.SelectionStart = txt.Text.Length;
            }
            catch (Exception) {
                throw new Exception();
            }
        }
    }
}