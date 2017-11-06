using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace StringToImage
{
    public partial class CaptchaUI : Form
    {
        Captcha Captcha;
        public CaptchaUI()
        {
            InitializeComponent();
            difficultySelector.SelectedIndex = 2;
        }

        private void buttonShow_Click(object sender, EventArgs e)
        {
            testInput.Text = String.Empty;
            textBox3.Text = String.Empty;

            try
            {
                var Generator = new CaptchaGenerator(captchaInput.Text);
                Captcha = Generator.Generate((Difficulties)difficultySelector.SelectedIndex);
                pictureBox.Image = Captcha.Image;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error.");
            }         
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (Captcha == null)
                return;

            saveFileDialog1.ShowDialog();
            if ( !String.IsNullOrEmpty(saveFileDialog1.FileName) )
            {
                try
                {
                    Captcha.Save(saveFileDialog1.FileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error.");
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Captcha == null)
                return;

            if (testInput.Text.ToUpper() == Captcha.Text.ToUpper())
                textBox3.Text = "Correct.";
            else
                textBox3.Text = "Wrong.";
        }
    }
}