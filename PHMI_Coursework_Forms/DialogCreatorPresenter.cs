using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PHMI_Coursework_Forms
{
    public class DialogCreatorPresenter
    {
        private DialogCreator creatorView;
        private Dialog dialog = new Dialog();
        private List<DialogStep> steps = new List<DialogStep>();
        private List<DialogResponse> additionalResponses = new List<DialogResponse>();

        public event DialogCreatedEventHandler DialogCreated;

        public DialogCreatorPresenter()
        {
            this.creatorView = new DialogCreator(this);
            this.creatorView.Show();
        }

        private DialogResponse[] GetResponses(Dictionary<string, string> responses)
        {
            List<DialogResponse> responsesList = new List<DialogResponse>();
            foreach (var response in responses)
                responsesList.Add(new DialogResponse() { Response = response.Key, Next = int.Parse(response.Value) });
            responsesList.AddRange(additionalResponses);
            return responsesList.ToArray();
        }

        public void AddStep(string num, string question, Dictionary<string, string> responses, string help, string error)
        {
            var step = new DialogStep() { Num = int.Parse(num), Question = question, Help = help, Error = error, Responses = GetResponses(responses) };
            steps.Add(step);
            creatorView.AddInfoToResponsesTable(step.Num.ToString(), step.Question, step.Help, step.Error, step.Responses.Select((r) => r.Response).ToList());
            creatorView.ClearAddingGroupBox();
            additionalResponses = new List<DialogResponse>();
        }

        public void EditStep(string num)
        {
            creatorView.ClearAddingGroupBox();
            int number = int.Parse(num);
            int index = 0;
            while (steps[index].Num != number)
                index++;
            DialogStep step = steps[index];

            steps.RemoveAt(index);
            Dictionary<string, string> responses = new Dictionary<string, string>();
            foreach (var resp in step.Responses)
                responses.Add(resp.Response, resp.Next.ToString());
            creatorView.AddInfoToEditor(step.Num.ToString(), step.Question, step.Help, step.Error, responses);
        }

        public void AddInnerDialog()
        {
            var response = new DialogResponse();
            new ResponseAdding(response).Show();
            additionalResponses.Add(response);
        }

        private void OnDialogCreated()
        {
            if (DialogCreated != null)
                DialogCreated(this, new DialogCreatedEventArgs(dialog));
            this.creatorView.Close();
        }

        public void SaveDialog(string path, string model)
        {
            dialog.FormalModel = model;
            SaveDialog(path);
        }

        public void SaveDialog(string path)
        {
            dialog.Steps = steps.ToArray();
            DialogXmlProvider.SaveToFile(path, dialog);
        }

        public void OpenDialog(string path)
        {
            creatorView.ClearControls();
            dialog = DialogXmlProvider.ReadFromFile(path);
            steps = dialog.Steps.ToList();
            additionalResponses = new List<DialogResponse>();

            foreach (var step in dialog.Steps)
            {
                Dictionary<string, string> responses = new Dictionary<string, string>();
                creatorView.AddInfoToResponsesTable(step.Num.ToString(), step.Question, step.Help, step.Error, step.Responses.Select((r) => r.Response).ToList());
                steps.Add(step);
            }
        }
    }
}