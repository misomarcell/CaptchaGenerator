using StringToImage.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace StringToImage
{
    class Captcha
    {
        public Image MyImage { get; set; }
        public Graphics MyGraphics { get; set; }
        public String MyText { get; set; }

        private PrivateFontCollection pfc;
        private Random random;   

        public Captcha(String text)
        {
            if (String.IsNullOrEmpty(text))
                throw new ArgumentNullException("text", "Captcha text can't be empty.");

            MyImage = new Bitmap(1,1);
            MyGraphics = Graphics.FromImage(MyImage);

            random = new Random(DateTime.Now.Millisecond);

            pfc = new PrivateFontCollection();
            AddCustomFont(pfc);

            MyText = text;
        }

        public Image GenerateCaptcha(Difficulties diff)
        {
            MyImage = new Bitmap(MyText.Length * 37, 100);
            MyGraphics = Graphics.FromImage(MyImage);  

            MyGraphics.Clear(Color.White);
            MyGraphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            switch (diff)
            {
                case Difficulties.Easy:
                    GenerateText(MyText);
                    break;
                case Difficulties.Normal:
                    AddRandomLines();
                    GenerateText(MyText);
                    break;
                case Difficulties.Hard:
                    AddRandomLines();
                    AddRandomOvals();
                    GenerateText(MyText);
                    break;
                case Difficulties.Unsolvable:
                    AddRandomBackground(MyGraphics, MyImage);
                    AddRandomLines();
                    AddRandomOvals();
                    GenerateText(MyText);
                    AddRandomBackground(MyGraphics, MyImage);
                    //AddRandomForeground();
                    break;
            }    
            
            return MyImage;
        }

        private void AddRandomBackground(Graphics myGraphics, Image myImage)
        {
           
            PerlinNoise p1 = new PerlinNoise(random.Next(0,1000));
            PerlinNoise p2 = new PerlinNoise(random.Next(0,1000));

            for ( var x = 0; x < MyImage.Width; x++)
            {
                for ( var y = 0; y < MyImage.Height; y++)
                {
                    double n1 = p1.Noise(x / 75.0 , y / 100.0, 1);
                    int e1 = ConvertRange(-1000, 1000, 0, 255, (int)(n1 * 1000));
                    double n2 = p2.Noise(x / 50.0, y / 200.0, 1);
                    int e2 = ConvertRange(-1000, 1000, 0, 255, (int)(n2 * 1000));

                    var color = Color.FromArgb(70, e1, e2, 123);
                    MyGraphics.DrawRectangle(new Pen(color), x, y, 1, 1);
                }
            }
        }

        public static int ConvertRange(
            int originalStart, int originalEnd, // original range
            int newStart, int newEnd, // desired range
            int value) // value to convert
            {
            double scale = (double)(newEnd - newStart) / (originalEnd - originalStart);
            return (int)(newStart + ((value - originalStart) * scale));
        }

        private void GenerateText(String text)
        {
            Font font = new Font(pfc.Families[0], 46f, FontStyle.Bold);

            Image Letter = new Bitmap(1,1);
            Graphics LetterGraph = Graphics.FromImage(Letter);

            int lastLetterLeft = -50;
            for ( var i = 0; i < text.Length; i++)
            {

                //Create new letter graphics
                var LetterSize = LetterGraph.MeasureString(text[i].ToString(), font);
                Letter = new Bitmap(200, 200);
                LetterGraph = Graphics.FromImage(Letter);

                // Rotate letter i
                LetterGraph.TranslateTransform(50,25);
                LetterGraph.RotateTransform(random.Next(-30, 30));

                //Draw letter i
                LetterGraph.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;
                LetterGraph.DrawString(text[i].ToString().ToUpper(), font, new SolidBrush(GetRandomColor()), 0,0);

                //Add new letter to the original image
                MyGraphics.DrawImage( Letter, new Point(lastLetterLeft, random.Next(-10,20)) );
                lastLetterLeft += 36;
            }
        }

        private void AddCustomFont(PrivateFontCollection pfc)
        {
            int fontLength = Resources.Katanf.Length;
            byte[] fontdata = Resources.Katanf;

            IntPtr data = Marshal.AllocCoTaskMem(fontLength);
            Marshal.Copy(fontdata, 0, data, fontLength);
            pfc.AddMemoryFont(data, fontLength);
        }

        public void Save(String filename)
        {
            if (MyImage == null)
               throw new NullReferenceException("No file to save.");

            MyGraphics.Save();
            MyImage.Save(filename, System.Drawing.Imaging.ImageFormat.Png);
        }

        private void AddRandomOvals()
        {
            for (var i = 0; i <MyImage.Width / 50; i++)
            {
                MyGraphics.DrawEllipse(
                    new Pen(GetRandomColor(), 4f),
                    new Rectangle(GetRandomPoint().X, GetRandomPoint().Y - MyImage.Height,
                    random.Next(200, 600), random.Next(200, 600)));
            }
        }

        private void AddRandomLines()
        {
            for (var i = 0; i < MyImage.Width / 50; i++)
            {
                Point point = GetRandomPoint();
                MyGraphics.DrawLine( new Pen(GetRandomColor(), 5f), point, new Point(point.X + (random.Next(-500,500)), point.Y + (random.Next(-500,500))) );
            }
        }

        private Point GetRandomPoint()
        {
            int randomX = random.Next(0, MyImage.Width);
            int randomY = random.Next(-50, MyImage.Height + 50);

            return new Point(randomX, randomY);
        }

        private Color GetRandomColor()
        {
            return Color.FromArgb(random.Next(150), random.Next(150), random.Next(150));
        }
    }
}
