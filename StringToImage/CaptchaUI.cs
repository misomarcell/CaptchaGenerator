using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace StringToImage
{
    public partial class CaptchaUI : Form
    {
        Difficulties diff = Difficulties.Hard;
        Captcha Captcha;

        public CaptchaUI()
        {
            InitializeComponent();
        }

        private void buttonShow_Click(object sender, EventArgs e)
        {
            try
            {
                Captcha = new Captcha(textBox1.Text, diff);
                pictureCaptcha.Image = Captcha.GenerateCaptcha();
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

        private void trackBarDifficulty_Scroll(object sender, EventArgs e)
        {
            if (trackBarDifficulty.Value == 0)
            {
                diff = Difficulties.Easy;
            }
            else if (trackBarDifficulty.Value == 1)
            {
                diff = Difficulties.Normal;
            }
            else if (trackBarDifficulty.Value == 2)
            {
                diff = Difficulties.Hard;
            }
            else if (trackBarDifficulty.Value == 3)
            {
                diff = Difficulties.Unsolvable;
            }

            labelDifficulty.Text = diff.ToString();
        }

    }
}