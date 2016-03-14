using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PHMI_Coursework_Forms
{
    public partial class DialogCreator : Form
    {
        private DialogCreatorPresenter presenter;
        public DialogCreator(DialogCreatorPresenter presenter)
        {
            InitializeComponent();
            this.presenter =  presenter;
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            string question = textBoxQuestion.Text;
            string help = textBoxHelp.Text;
            string num = textBoxNum.Text;
            string error = textBoxError.Text == null || textBoxError.Text.Equals(string.Empty) ? @"Неверный формат ввода" : textBoxError.Text;
            Dictionary<string, string> responses = new Dictionary<string, string>();
            
            for (int i = 0; i < dataGridViewResponses.Rows.Count - 1; i++)
                responses.Add(dataGridViewResponses.Rows[i].Cells[0].Value.ToString(),
                                dataGridViewResponses.Rows[i].Cells[1].Value.ToString());

            presenter.AddStep(num, question, responses, help, error);
        }

        public void AddInfoToResponsesTable(string num, string question, string help, string error, List<string> responses)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var response in responses)
                sb.Append(response + ", ");
            dataGridViewQuestions.Rows.Add(num, question, sb.ToString(), help, error);
        }

        public void ClearAddingGroupBox()
        {
            textBoxError.Text = textBoxHelp.Text = textBoxQuestion.Text = textBoxNum.Text = string.Empty;
            for (int i = 0; i < dataGridViewResponses.Rows.Count - 1; i++)
                dataGridViewResponses.Rows.RemoveAt(0);
        }

        public void AddInfoToEditor(string num, string question, string help, string error, Dictionary<string, string> responses)
        {
            ClearAddingGroupBox();
            textBoxNum.Text = num;
            textBoxQuestion.Text = question;
            textBoxHelp.Text = help;
            textBoxError.Text = error;
            foreach(var response in responses)
                dataGridViewResponses.Rows.Add(response.Key, response.Value);
        }

        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            var save = new SaveFileDialog()
            {
                FileName = "dialog.xml",
                InitialDirectory = System.IO.Directory.GetCurrentDirectory(),
                Filter = "xml files (*.xml)|*.xml"
            };
            if (save.ShowDialog() == DialogResult.OK)
            {
                if (radioButtonNone.Checked)
                    presenter.SaveDialog(save.FileName);
                else
                    presenter.SaveDialog(save.FileName, "GameTheory");
            }
        }

        private void helpToolStripButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Работу выполнил студент 2 курса Программной инженерии\nАлександров Евгений" 
                                +"\nДанная работа является интеллектуальной собственностью и не может быть представлена на конференции",
                                "Справка", MessageBoxButtons.OK);
        }

        private void openToolStripButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog()
            {
                InitialDirectory = System.IO.Directory.CreateDirectory(System.IO.Directory.GetCurrentDirectory() + @"/dialogs", new System.Security.AccessControl.DirectorySecurity()).FullName,
                Filter = "xml files (*.xml)|*.xml",
                RestoreDirectory = true
            };
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    presenter.OpenDialog(openFileDialog.FileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка чтения файла", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            int rowNum = dataGridViewQuestions.SelectedCells[0].RowIndex;
            presenter.EditStep(dataGridViewQuestions.Rows[rowNum].Cells[0].Value.ToString());
            dataGridViewQuestions.Rows.RemoveAt(rowNum);
        }

        public void ClearControls()
        {
            for (int i = dataGridViewQuestions.Rows.Count - 1; i >= 0; i++)
                dataGridViewQuestions.Rows.RemoveAt(i);
            textBoxError.Text = textBoxHelp.Text = textBoxQuestion.Text = textBoxNum.Text = string.Empty;
            for (int i = 0; i < dataGridViewResponses.Rows.Count - 1; i++)
                dataGridViewResponses.Rows.RemoveAt(0);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            presenter.AddInnerDialog();
        }
    }
}
