using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace PHMI_Coursework_Forms
{
    public class Dialog
    {
        public DialogStep[] Steps { get; set; }

        [XmlAttribute]
        public string FormalModel { get; set; }  
    }
}
