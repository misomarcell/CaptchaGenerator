using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace StringToImage
{
    public partial class Form1 : Form
    {
        Difficulties diff = Difficulties.Hard;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //saveFileDialog1.ShowDialog();
            GenerateImage();
        }

        private void GenerateImage()
        {
            var Captcha = new Captcha(textBox1.Text);
            Captcha.GenerateCaptcha(diff);
            Captcha.Save();

            Process.Start(@"C:\Users\Misó Marcell\Desktop\teszt.png");
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            if ( trackBar1.Value == 0 )
            {
                diff = Difficulties.Easy;
            } else if (trackBar1.Value == 1)
            {
                diff = Difficulties.Normal;
            } else if (trackBar1.Value == 2)
            {
                diff = Difficulties.Hard;
            } else if (trackBar1.Value == 3)
            {
                diff = Difficulties.Unsolvable;
            }

            textBox2.Text = diff.ToString();
        }
    }
    }