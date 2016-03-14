using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace PHMI_Coursework_Forms
{
    public class DialogResponse
    {
        [XmlAttribute]
        public int Next { get; set; }

        [XmlAttribute]
        public string Response { get; set; }

        [XmlElement(IsNullable = false)]
        public string MethodName { get; set; }

        [XmlElement(IsNullable = false)]
        public Dialog InnerDialog { get; set; }
    }
}
