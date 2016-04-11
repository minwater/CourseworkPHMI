using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PHMI_Coursework_Forms
{
    class BasicModel : FormalModel
    {
        private Dialog dialog;
        private int currentStep = 0;

        public override DialogStep CurrentStep
        {
            get
            {
                if (currentStep >= dialog.Steps.Length)
                    return null;
                return dialog.Steps[currentStep];
            }
        }

        public BasicModel(Dialog dialog)
        {
            this.dialog = dialog;
        }

        public override void MakeStep(string response, out string error, out Dialog inner)
        {
            OnStepMade(dialog.Steps[currentStep].Question, response);
            error = string.Empty;
            var allowed = dialog.Steps[currentStep].Responses;
            inner = null;
            if (allowed != null && allowed.Length != 0)
            {
                DialogResponse resp = null;
                foreach (var allowedResp in allowed)
                    if (allowedResp.Response.Equals(response))
                        resp = allowedResp;
                if (resp != null)
                {
                    inner = resp.InnerDialog;
                    if (resp.Next == 0)
                        currentStep++;
                    else
                        currentStep = resp.Next - 1;
                }
                else 
                    error = CurrentStep.Error;
            }
            else
                currentStep++;
        }
    }
}
