using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Text;
using System.Threading.Tasks;

namespace start
{
    class ClassGridLpEtq
    {
         private string HmGEstoque;

         public string HmGridItEstoq
         {
             get { return HmGEstoque; }
             set { HmGEstoque = value; }
         }
         public static List<ClassGridLpEtq> ListaControleEstoq()
           {
              List<ClassGridLpEtq> List = new List<ClassGridLpEtq>();
              XElement xml = XElement.Load(@"config.xml");
              foreach (XElement x in xml.Elements())
              {
                   ClassGridLpEtq p = new ClassGridLpEtq()
                   {
                       HmGridItEstoq = x.Attribute("Estoque").Value,
                   };
                   List.Add(p);
              }
              return List;
         }
    }
}