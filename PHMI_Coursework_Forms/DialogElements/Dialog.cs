using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;

namespace PHMI_Coursework_Forms
{
    public class Dialog
    {
        public DialogStep[] Steps { get; set; }

        [XmlAttribute]
        public string FormalModel { get; set; }

        public static Dialog ReadFromFile(string path)
        {
            Dialog dialog = new Dialog();

            XmlSerializer serializer = new XmlSerializer(typeof(Dialog));

            using (var reader = new FileStream(path, FileMode.Open))
            {
                dialog = serializer.Deserialize(reader) as Dialog;
            }
            return dialog;
        }

        public void SaveToFile(string path)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Dialog));

            using (var writer = new StreamWriter(path))
            {
                serializer.Serialize(writer, this);
            }
        }
    }
}
