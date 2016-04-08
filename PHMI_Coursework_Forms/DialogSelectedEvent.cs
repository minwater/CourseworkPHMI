using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PHMI_Coursework_Forms
{
    public class DialogSelectedEventArgs : EventArgs
    {
        private string path;
        public string Path { get { return path; } }
        public DialogSelectedEventArgs(string path)
        {
            this.path = path;
        }
    }

    public delegate void DialogSelectedEventHandler(object sender, DialogSelectedEventArgs e);
}
