using System.Collections.Generic;
using System.Xml.Linq;

namespace HomeClass
{
    public class ClassGridLpHome
    {
        private string HmRrota;
        private string HmRfunc;

        public static string DateProprie { get; private set; }

        public string HmGridRota
        {
            get { return HmRrota; }
            set { HmRrota = value; }
        }
        public string HmGridFunc
        {
            get { return HmRfunc; }
            set { HmRfunc = value; }
        }
        public static List<ClassGridLpHome> ListaRelatorio(string Local)
        {
            List<ClassGridLpHome> List = new List<ClassGridLpHome>();
            XElement xml = XElement.Load(@"cache\" + Local + ".xml");
            foreach (XElement x in xml.Elements("Planilha"))
            {
                ClassGridLpHome p = new ClassGridLpHome()
                {
                    HmRrota = x.Attribute("Rota").Value,
                    HmRfunc = x.Attribute("Funcionario").Value,
                };
                List.Add(p);
            }
            return List;
        }
    }
}