using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PHMI_Coursework_Forms
{
    public class DialogStep
    {
        [XmlAttribute]
        public int Num { get; set; }

        [XmlAttribute]
        public string Question { get; set; }

        [XmlAttribute]
        public string Help { get; set; }

        [XmlAttribute]
        public string Error { get; set; }
        
        [XmlArray(IsNullable = false)]
        public DialogResponse[] Responses { get; set; }
    }
}
