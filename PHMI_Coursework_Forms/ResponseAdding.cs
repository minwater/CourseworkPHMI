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
    public partial class ResponseAdding : Form
    {
        private Dialog inner;
        private DialogResponse response;
        public ResponseAdding(DialogResponse response)
        {
            InitializeComponent();
            this.response = response;
        }

        private void buttonInner_Click(object sender, EventArgs e)
        {
            DialogCreatorPresenter presenter = new DialogCreatorPresenter();
            presenter.DialogCreated += Presenter_DialogCreated;
        }

        private void Presenter_DialogCreated(object sender, DialogCreatedEventArgs e)
        {
            inner = e.Dialog;
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            response.InnerDialog = inner;
            response.Response = textBoxResponse.Text;
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
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
                    inner = Dialog.ReadFromFile(openFileDialog.FileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка чтения файла", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
