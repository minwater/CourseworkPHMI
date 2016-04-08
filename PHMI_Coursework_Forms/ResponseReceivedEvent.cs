using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PHMI_Coursework_Forms
{
    public delegate void ResponseReceivedEventHandler(object sender, ResponseReceivedEventArgs e);

    public class ResponseReceivedEventArgs : EventArgs
    {
        private string response;
        public string Response { get { return response; } }

        public ResponseReceivedEventArgs(string response)
        {
            this.response = response;
        }
    }
}
