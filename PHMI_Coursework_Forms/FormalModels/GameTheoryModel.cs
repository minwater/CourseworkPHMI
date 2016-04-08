using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PHMI_Coursework_Forms
{
    class GameTheoryModel : FormalModel
    {
        private Dialog dialog;
        private List<DialogStep> history = new List<DialogStep>();
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

        public GameTheoryModel(Dialog dialog)
        {
            this.dialog = dialog;
        }

        public override void MakeStep(string response, out string error, out Dialog inner)
        {
            error = string.Empty;
            var allowed = Fdc(history);
            inner = null;
            if (allowed != null)
            {
                if (allowed.ContainsKey(response))
                {
                    inner = allowed[response].InnerDialog;
                    if (allowed[response].Next == 0)
                        currentStep++;
                    else
                        currentStep = allowed[response].Next - 1;
                }
                else
                    error = @"Данный ответ не разрешен правилами";
            }
            else
                currentStep++;
            history.Add(CurrentStep);
        }

        private static Dictionary<string, DialogResponse> Fdc(List<DialogStep> history)
        {
            if (history.Count > 0)
            {
                DialogStep step = history.Last();
                if (step.Responses != null && step.Responses.Length != 0)
                {
                    var responses = new Dictionary<string, DialogResponse>();
                    for (int i = 0; i < step.Responses.Length; i++)
                        responses.Add(step.Responses[i].Response, step.Responses[i]);
                    return responses;
                }
            }
            return null;
        }

        public override void MoveNext()
        {
            currentStep++;
        }
    }
}
