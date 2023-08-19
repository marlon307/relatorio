using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace start.Class
{
    internal class ComboBoxItem
    {
        public string ID { get; set; }
        public string Value { get; set; }
        public ComboBoxItem(string id, string value)
        {
            ID = id;
            Value = value;
        }
        public override string ToString()
        {
            return Value; // Display the Value property in the ComboBox
        }
    }
}
