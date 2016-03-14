using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PHMI_Coursework_Forms
{
    public class DialogCreatedEventArgs : EventArgs
    {
        private Dialog dialog;
        public Dialog Dialog { get { return dialog; } }

        public DialogCreatedEventArgs(Dialog dialog)
        {
            this.dialog = dialog;
        }
    }

    public delegate void DialogCreatedEventHandler(object sender, DialogCreatedEventArgs e);
}
