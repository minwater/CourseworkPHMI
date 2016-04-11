using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace PHMI_Coursework_Forms
{
    partial class DialogForm : Form
    {
        public event DialogSelectedEventHandler DialogSelected;
        public event ResponseReceivedEventHandler ResponseReceived;
        DialogPresenter presenter;

        public DialogForm()
        {
            InitializeComponent();
            presenter = new DialogPresenter(this);
        }

        private void openToolStripButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog()
            {
                InitialDirectory = System.IO.Directory.CreateDirectory(System.IO.Directory.GetCurrentDirectory() + @"/dialogs", new System.Security.AccessControl.DirectorySecurity()).FullName,
                Filter = "xml files (*.xml)|*.xml",
                RestoreDirectory = true
            };
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                    OnDialogSelected(openFileDialog.FileName);
            }
        }

        private void OnDialogSelected(string path)
        {
            DialogSelected(this, new DialogSelectedEventArgs(path));
        }


        private void buttonOK_Click(object sender, EventArgs e)
        {
            listBoxProtocol.Items.Add("Пользователь: " + textBoxResponse.Text);
            OnResponseReceived();
        }

        private void OnResponseReceived()
        {
            ResponseReceived(this, new ResponseReceivedEventArgs(textBoxResponse.Text));
        }

        public void EnableControls()
        {
            buttonOK.Enabled = textBoxResponse.Enabled = true;
        }

        public void DisableControls()
        {
            buttonOK.Enabled = textBoxResponse.Enabled = false;
        }

        public void ShowErrorMessage(string error)
        {
            labelError.Text = error;
        }

        public void ShowMessageBox()
        {
            MessageBox.Show("Ошибка чтения файла", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public void UpdateInfo(string nextQuestion, string help, DialogResponse[] responses)
        {
            textBoxResponse.Text = string.Empty;
            labelQuestion.Text = nextQuestion;
            labelHelp.Text = help;

            listBoxProtocol.Items.Add("Система: " + labelQuestion.Text);

            for (int i = listBoxAllowedResponses.Items.Count - 1; i >= 0; i--)
                listBoxAllowedResponses.Items.RemoveAt(i);
            foreach (var resp in responses)
                listBoxAllowedResponses.Items.Add(resp.Response);
        }

        private void newToolStripButton_Click(object sender, EventArgs e)
        {
            DialogCreatorPresenter presenter = new DialogCreatorPresenter();
        }

        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            SaveDialogProtocol();
        }

        public void SaveDialogProtocol()
        {
            var save = new SaveFileDialog()
            {
                FileName = "protocol.txt",
                InitialDirectory = System.IO.Directory.GetCurrentDirectory(),
                Filter = "text files (*.txt)|*.txt"
            };

            if (save.ShowDialog() == DialogResult.OK)
            {
                using (var writer = System.IO.File.CreateText(save.FileName))
                {
                    presenter.SaveHistory(save.FileName);
                }
            }

            for (int i = 0; i < listBoxProtocol.Items.Count; i++)
                listBoxProtocol.Items.RemoveAt(0);
        }

        private void listBoxAllowedResponses_DoubleClick(object sender, EventArgs e)
        {
            if (listBoxAllowedResponses.SelectedItem != null)
            {
                textBoxResponse.Text = listBoxAllowedResponses.SelectedItem.ToString();
            }
        }

        private void helpToolStripButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Работу выполнил студент 2 курса Программной инженерии Александров Евгений."
                                + "\nДанная работа является интеллектуальной собственностью и не может быть представлена на конференциях без письменного разрешения автора.",
                                "Справка", MessageBoxButtons.OK);
        }
    }
}
