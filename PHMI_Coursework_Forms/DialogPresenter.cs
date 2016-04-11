using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace PHMI_Coursework_Forms
{
    class DialogPresenter
    {
        Stack<FormalModel> models = new Stack<FormalModel>();
        DialogObserver observer = new DialogObserver();
        DialogForm dialogView;
        List<string> files = new List<string>();
        string finalPath;

        public DialogPresenter(DialogForm dialogForm)
        {
            this.dialogView = dialogForm;
            this.dialogView.DialogSelected += DialogView_DialogSelected;
            this.dialogView.ResponseReceived += DialogView_ResponseReceived;
        }

        private void DialogView_ResponseReceived(object sender, ResponseReceivedEventArgs e)
        {
            ReadResponse(e.Response);
        }

        private void DialogView_DialogSelected(object sender, DialogSelectedEventArgs e)
        {
            try
            {
                files = new List<string>();
                Dialog dialog = DialogXmlProvider.ReadFromFile(e.Path);
                FormalModel currentModel = new BasicModel(dialog);
                observer.AddModel(currentModel);
                models.Push(currentModel);
                dialogView.EnableControls();
                UpdateInfo();
            }
            catch (IOException ex)
            {
                dialogView.ShowMessageBox();
            }
        }

        public void ReadResponse(string response)
        {
            string question = models.Peek().CurrentStep.Question;
            if (question.Equals("Введите путь к первому файлу системы") ||
                    question.Equals("Введите путь к добавляемому файлу"))
                files.Add(response);
            else if (question.Equals("Где расположить готовую систему?"))
            {
                finalPath = response;
                FileBinder.Binder.BindFiles(files.ToArray(), finalPath);
            }

            string error;
            Dialog inner;
            models.Peek().MakeStep(response, out error, out inner);
            if (!error.Equals(string.Empty))
                dialogView.ShowErrorMessage(error);

            if (models.Peek().CurrentStep != null)
            {
                if (inner != null)
                {
                    FormalModel model = inner.FormalModel != null ? (FormalModel)new GameTheoryModel(inner) : new BasicModel(inner);
                    observer.AddModel(model);
                    models.Push(model);
                }
                UpdateInfo();
            }
            else if (models.Count == 1)
            {
                dialogView.DisableControls();
                dialogView.UpdateInfo(string.Empty, string.Empty, new DialogResponse[0]);
                dialogView.SaveDialogProtocol();
                files = new List<string>();
            }
            else
            {
                models.Pop();
                ReadResponse(string.Empty);
            }
        }

        private void UpdateInfo()
        {
            DialogResponse[] responses = models.Peek().CurrentStep.Responses;
            string question = models.Peek().CurrentStep.Question;
            string help = models.Peek().CurrentStep.Help;
            if (question.Equals("Стоимость проекта составит"))
                question += " " + new Random().Next(100000, 500000);

            dialogView.UpdateInfo(question, help, responses);
        }

        public void SaveHistory(string path)
        {
            observer.SaveToFile(path);
        }
    }
}
