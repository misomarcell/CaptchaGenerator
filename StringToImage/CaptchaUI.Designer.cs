namespace StringToImage
{
    partial class CaptchaUI
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
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.saveButton = new System.Windows.Forms.Button();
            this.generateButton = new System.Windows.Forms.Button();
            this.captchaInput = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.testButton = new System.Windows.Forms.Button();
            this.testInput = new System.Windows.Forms.TextBox();
            this.difficultySelector = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "png";
            this.saveFileDialog1.FileName = "captcha.png";
            this.saveFileDialog1.Filter = "PNG File|*.png";
            // 
            // pictureBox
            // 
            this.pictureBox.BackColor = System.Drawing.Color.DarkGray;
            this.pictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox.Location = new System.Drawing.Point(200, 0);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(363, 149);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox.TabIndex = 5;
            this.pictureBox.TabStop = false;
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(3, 65);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(92, 22);
            this.saveButton.TabIndex = 8;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // generateButton
            // 
            this.generateButton.Location = new System.Drawing.Point(102, 65);
            this.generateButton.Name = "generateButton";
            this.generateButton.Size = new System.Drawing.Size(92, 22);
            this.generateButton.TabIndex = 12;
            this.generateButton.Text = "Generate";
            this.generateButton.UseVisualStyleBackColor = true;
            this.generateButton.Click += new System.EventHandler(this.buttonShow_Click);
            // 
            // captchaInput
            // 
            this.captchaInput.Location = new System.Drawing.Point(3, 12);
            this.captchaInput.Name = "captchaInput";
            this.captchaInput.Size = new System.Drawing.Size(191, 20);
            this.captchaInput.TabIndex = 9;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.textBox3);
            this.panel2.Controls.Add(this.testButton);
            this.panel2.Controls.Add(this.testInput);
            this.panel2.Controls.Add(this.difficultySelector);
            this.panel2.Controls.Add(this.captchaInput);
            this.panel2.Controls.Add(this.generateButton);
            this.panel2.Controls.Add(this.saveButton);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(200, 149);
            this.panel2.TabIndex = 7;
            // 
            // textBox3
            // 
            this.textBox3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox3.Location = new System.Drawing.Point(12, 124);
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.Size = new System.Drawing.Size(84, 13);
            this.textBox3.TabIndex = 16;
            this.textBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // testButton
            // 
            this.testButton.Location = new System.Drawing.Point(102, 119);
            this.testButton.Name = "testButton";
            this.testButton.Size = new System.Drawing.Size(92, 22);
            this.testButton.TabIndex = 15;
            this.testButton.Text = "Test";
            this.testButton.UseVisualStyleBackColor = true;
            this.testButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // testInput
            // 
            this.testInput.Location = new System.Drawing.Point(3, 93);
            this.testInput.Name = "testInput";
            this.testInput.Size = new System.Drawing.Size(191, 20);
            this.testInput.TabIndex = 14;
            // 
            // difficultySelector
            // 
            this.difficultySelector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.difficultySelector.FormattingEnabled = true;
            this.difficultySelector.Items.AddRange(new object[] {
            "Easy",
            "Normal",
            "Hard",
            "Unreadable"});
            this.difficultySelector.Location = new System.Drawing.Point(3, 38);
            this.difficultySelector.Name = "difficultySelector";
            this.difficultySelector.Size = new System.Drawing.Size(191, 21);
            this.difficultySelector.TabIndex = 13;
            // 
            // CaptchaUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(563, 149);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.panel2);
            this.Name = "CaptchaUI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Captcha UI";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button generateButton;
        private System.Windows.Forms.TextBox captchaInput;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ComboBox difficultySelector;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Button testButton;
        private System.Windows.Forms.TextBox testInput;
    }
}

