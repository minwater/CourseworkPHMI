using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace PHMI_Coursework_Forms
{
    class DialogObserver
    {
        private List<string> history = new List<string>();
        public string[] History { get { return history.ToArray(); } }

        public void AddModel(FormalModel model)
        {
            model.StepMade += Model_StepMade;
        }

        private void Model_StepMade(object sender, StepMadeEventArgs e)
        {
            history.Add("Система: " + e.Question);
            if (e.Response != null && !e.Equals(string.Empty))
                history.Add("Пользователь: " + e.Response);
        }

        public void SaveToFile(string path)
        {
            using (var writer = File.CreateText(path))
            {
                foreach (var hist in history)
                    writer.WriteLine(hist);
            }
        }
    }
}
