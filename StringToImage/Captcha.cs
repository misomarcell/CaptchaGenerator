using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringToImage
{
    class Captcha
    {

        public Image Image { get; set; }
        public string Text { get; set; }

        public Captcha(Image image, string text)
        {
            Image = image;
            Text = text;
        }

        public void Save(String filename)
        {
            if (Image == null)
                throw new NullReferenceException("No file to save.");

            Image.Save(filename, System.Drawing.Imaging.ImageFormat.Png);
        }
    }
}
