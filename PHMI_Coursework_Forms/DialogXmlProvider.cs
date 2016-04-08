using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;

namespace PHMI_Coursework_Forms
{
    public static class DialogXmlProvider
    {
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

        public static void SaveToFile(string path, Dialog dialog)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Dialog));

            using (var writer = new StreamWriter(path))
            {
                serializer.Serialize(writer, dialog);
            }
        }
    }
}
