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
            DifficultySelector.SelectedIndex = 2;
        }

        private void buttonShow_Click(object sender, EventArgs e)
        {
                Captcha = new Captcha(textBox1.Text, (Difficulties)DifficultySelector.SelectedIndex);
                pictureCaptcha.Image = Captcha.GenerateCaptcha();
            try
            {
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


    }
}