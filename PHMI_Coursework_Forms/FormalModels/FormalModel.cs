using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PHMI_Coursework_Forms
{
    public delegate void StepMadeEventHandler(object sender, StepMadeEventArgs e);
    public class StepMadeEventArgs : EventArgs 
    {
        private string question;
        public string Question { get { return question; } }

        private string response;
        public string Response { get { return response; } }

        public StepMadeEventArgs(string question, string response)
        {
            this.question = question;
            this.response = response;
        }
    }

    abstract class FormalModel
    {
        public abstract DialogStep CurrentStep { get; }
        public abstract void MakeStep(string response, out string error, out Dialog inner);
        public event StepMadeEventHandler StepMade;
        protected void OnStepMade(string question, string response)
        {
            if (StepMade != null)
                StepMade(this, new StepMadeEventArgs(question, response));
        }
    }
}
