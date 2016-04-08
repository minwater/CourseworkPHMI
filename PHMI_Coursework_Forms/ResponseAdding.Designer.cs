namespace PHMI_Coursework_Forms
{
    partial class ResponseAdding
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonInner = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxResponse = new System.Windows.Forms.TextBox();
            this.buttonOk = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonInner
            // 
            this.buttonInner.Location = new System.Drawing.Point(12, 32);
            this.buttonInner.Name = "buttonInner";
            this.buttonInner.Size = new System.Drawing.Size(200, 23);
            this.buttonInner.TabIndex = 0;
            this.buttonInner.Text = "Добавить внутренний диалог";
            this.buttonInner.UseVisualStyleBackColor = true;
            this.buttonInner.Click += new System.EventHandler(this.buttonInner_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Ответ:";
            // 
            // textBoxResponse
            // 
            this.textBoxResponse.Location = new System.Drawing.Point(58, 6);
            this.textBoxResponse.Name = "textBoxResponse";
            this.textBoxResponse.Size = new System.Drawing.Size(214, 20);
            this.textBoxResponse.TabIndex = 2;
            // 
            // buttonOk
            // 
            this.buttonOk.Location = new System.Drawing.Point(218, 32);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(54, 53);
            this.buttonOk.TabIndex = 5;
            this.buttonOk.Text = "ОК";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 62);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(200, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "Открыть из файла";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ResponseAdding
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 97);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.textBoxResponse);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonInner);
            this.Name = "ResponseAdding";
            this.Text = "Добавление ответа";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonInner;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxResponse;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.Button button1;
    }
}