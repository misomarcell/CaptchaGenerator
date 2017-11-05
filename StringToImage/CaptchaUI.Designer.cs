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
            this.pictureCaptcha = new System.Windows.Forms.PictureBox();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonShow = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.DifficultySelector = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureCaptcha)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "png";
            this.saveFileDialog1.FileName = "captcha.png";
            this.saveFileDialog1.Filter = "PNG File|*.png";
            // 
            // pictureCaptcha
            // 
            this.pictureCaptcha.BackColor = System.Drawing.Color.DarkGray;
            this.pictureCaptcha.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureCaptcha.Location = new System.Drawing.Point(200, 0);
            this.pictureCaptcha.Name = "pictureCaptcha";
            this.pictureCaptcha.Size = new System.Drawing.Size(363, 93);
            this.pictureCaptcha.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureCaptcha.TabIndex = 5;
            this.pictureCaptcha.TabStop = false;
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(3, 65);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(92, 22);
            this.buttonSave.TabIndex = 8;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonShow
            // 
            this.buttonShow.Location = new System.Drawing.Point(102, 65);
            this.buttonShow.Name = "buttonShow";
            this.buttonShow.Size = new System.Drawing.Size(92, 22);
            this.buttonShow.TabIndex = 12;
            this.buttonShow.Text = "Generate";
            this.buttonShow.UseVisualStyleBackColor = true;
            this.buttonShow.Click += new System.EventHandler(this.buttonShow_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(3, 12);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(191, 20);
            this.textBox1.TabIndex = 9;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.DifficultySelector);
            this.panel2.Controls.Add(this.textBox1);
            this.panel2.Controls.Add(this.buttonShow);
            this.panel2.Controls.Add(this.buttonSave);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(200, 93);
            this.panel2.TabIndex = 7;
            // 
            // DifficultySelector
            // 
            this.DifficultySelector.FormattingEnabled = true;
            this.DifficultySelector.Items.AddRange(new object[] {
            "Easy",
            "Normal",
            "Hard",
            "Unreadable"});
            this.DifficultySelector.Location = new System.Drawing.Point(3, 38);
            this.DifficultySelector.Name = "DifficultySelector";
            this.DifficultySelector.Size = new System.Drawing.Size(191, 21);
            this.DifficultySelector.TabIndex = 13;
            // 
            // CaptchaUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(563, 93);
            this.Controls.Add(this.pictureCaptcha);
            this.Controls.Add(this.panel2);
            this.Name = "CaptchaUI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Captcha UI";
            ((System.ComponentModel.ISupportInitialize)(this.pictureCaptcha)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.PictureBox pictureCaptcha;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonShow;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ComboBox DifficultySelector;
    }
}

