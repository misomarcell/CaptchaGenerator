﻿namespace StringToImage
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureCaptcha = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.trackBarDifficulty = new System.Windows.Forms.TrackBar();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonShow = new System.Windows.Forms.Button();
            this.labelDifficulty = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureCaptcha)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarDifficulty)).BeginInit();
            this.SuspendLayout();
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "png";
            this.saveFileDialog1.FileName = "captcha.png";
            this.saveFileDialog1.Filter = "PNG File|*.png";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pictureCaptcha);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(389, 100);
            this.panel1.TabIndex = 6;
            // 
            // pictureCaptcha
            // 
            this.pictureCaptcha.BackColor = System.Drawing.Color.DarkGray;
            this.pictureCaptcha.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureCaptcha.Location = new System.Drawing.Point(0, 0);
            this.pictureCaptcha.Name = "pictureCaptcha";
            this.pictureCaptcha.Size = new System.Drawing.Size(389, 100);
            this.pictureCaptcha.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureCaptcha.TabIndex = 5;
            this.pictureCaptcha.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.labelDifficulty);
            this.panel2.Controls.Add(this.trackBarDifficulty);
            this.panel2.Controls.Add(this.textBox1);
            this.panel2.Controls.Add(this.buttonShow);
            this.panel2.Controls.Add(this.buttonSave);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 100);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(389, 87);
            this.panel2.TabIndex = 7;
            // 
            // textBox1
            // 
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.textBox1.Location = new System.Drawing.Point(0, 0);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(239, 20);
            this.textBox1.TabIndex = 9;
            // 
            // trackBarDifficulty
            // 
            this.trackBarDifficulty.Dock = System.Windows.Forms.DockStyle.Top;
            this.trackBarDifficulty.Location = new System.Drawing.Point(0, 20);
            this.trackBarDifficulty.Maximum = 3;
            this.trackBarDifficulty.Name = "trackBarDifficulty";
            this.trackBarDifficulty.Size = new System.Drawing.Size(239, 45);
            this.trackBarDifficulty.TabIndex = 10;
            this.trackBarDifficulty.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.trackBarDifficulty.Value = 2;
            this.trackBarDifficulty.Scroll += new System.EventHandler(this.trackBarDifficulty_Scroll);
            // 
            // buttonSave
            // 
            this.buttonSave.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonSave.Location = new System.Drawing.Point(314, 0);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 87);
            this.buttonSave.TabIndex = 8;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonShow
            // 
            this.buttonShow.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonShow.Location = new System.Drawing.Point(239, 0);
            this.buttonShow.Name = "buttonShow";
            this.buttonShow.Size = new System.Drawing.Size(75, 87);
            this.buttonShow.TabIndex = 12;
            this.buttonShow.Text = "Show";
            this.buttonShow.UseVisualStyleBackColor = true;
            this.buttonShow.Click += new System.EventHandler(this.buttonShow_Click);
            // 
            // labelDifficulty
            // 
            this.labelDifficulty.BackColor = System.Drawing.SystemColors.Control;
            this.labelDifficulty.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.labelDifficulty.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelDifficulty.Location = new System.Drawing.Point(0, 65);
            this.labelDifficulty.Margin = new System.Windows.Forms.Padding(10, 3, 10, 3);
            this.labelDifficulty.Name = "labelDifficulty";
            this.labelDifficulty.ReadOnly = true;
            this.labelDifficulty.Size = new System.Drawing.Size(239, 13);
            this.labelDifficulty.TabIndex = 11;
            this.labelDifficulty.Text = "Hard";
            this.labelDifficulty.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(389, 189);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Captcha UI";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureCaptcha)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarDifficulty)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureCaptcha;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox labelDifficulty;
        private System.Windows.Forms.TrackBar trackBarDifficulty;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button buttonShow;
        private System.Windows.Forms.Button buttonSave;
    }
}
