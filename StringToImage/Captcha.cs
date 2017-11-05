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
    enum Difficulties{ Easy, Normal, Hard, Unsolvable }

    class Captcha
    {
        public Image MyImage { get; set; }
        public Graphics MyGraphics { get; set; }
        public String MyText { get; set; }
        public Font MyFontFamily {get; set; }
        public Difficulties MyDifficulty { get; set; }

        private Random MyRandom;   

        public Captcha(String text, Difficulties difficulty)
        {
            if (String.IsNullOrEmpty(text))
                throw new ArgumentNullException("text", "Captcha text can't be empty.");

            MyFontFamily =  new Font(AddCustomFont(new PrivateFontCollection()).Families[0], 46f, FontStyle.Bold);
            MyRandom =      new Random(DateTime.Now.Millisecond);
            MyImage =       new Bitmap(1,1);
            MyGraphics =    Graphics.FromImage(MyImage);
            MyDifficulty =  difficulty;
            MyText =        text;
        }

        public Image GenerateCaptcha()
        {
            int width = (int)MyGraphics.MeasureString(MyText, MyFontFamily).Width;
            int height = (int)MyGraphics.MeasureString(MyText, MyFontFamily).Height;
            MyImage = new Bitmap(width, height);
            MyGraphics = Graphics.FromImage(MyImage);  

            MyGraphics.Clear(Color.White);
            MyGraphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            switch (MyDifficulty)
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
                    break;
            }    
            
            return MyImage;
        }

        private void AddRandomBackground(Graphics myGraphics, Image myImage)
        {
           
            PerlinNoise p1 = new PerlinNoise(MyRandom.Next(0,1000));
            Bitmap bm = new Bitmap(MyImage.Width, myImage.Height);

            for ( var w = 0; w < bm.Width; w++ )
            {
                for ( var h = 0; h < bm.Height; h++ )
                {
                    //myNoise.GradientPerturb(bm.GetPixel., ref y);
                    //bm.SetPixel( w, h, GetPixelPerlinColor(bm, new Point(w, h)) );
                }
            }

            MyGraphics.DrawImage(bm, 0, 0); 
        }

        private void GetPixelPerlinColor(Bitmap bitmap, float x, float y)
        {
            /*
             * FastNoise myNoise = new FastNoise();
            myNoise.SetFractalOctaves(5);
            myNoise.SetFractalLacunarity(1.7f);
            myNoise.SetFractalGain(.6f);
            myNoise.SetNoiseType(FastNoise.NoiseType.CubicFractal);

            myNoise.GradientPerturb(ref x, ref y);
            */
        }

        private static int ConvertRange(int originalStart, int originalEnd, int newStart, int newEnd, float value)
        {
            double scale = (double)(newEnd - newStart) / (originalEnd - originalStart);
            return (int)(newStart + ((value - originalStart) * scale));
        }

        private void GenerateText(String text, bool debug = false)
        {

            Image Letter = new Bitmap(1,1);
            Graphics LetterGraph = Graphics.FromImage(Letter);

            int lastLetterLeft = 10;
            for ( var i = 0; i < text.Length; i++)
            {


                //Create new letter graphics
                var LetterSize = LetterGraph.MeasureString(text[i].ToString(), MyFontFamily);
                //  Set graphics bounds to the letter
                Letter = new Bitmap((int)LetterSize.Width - 20, (int)LetterSize.Height - 30);
                LetterGraph = Graphics.FromImage(Letter);



                // Rotate letter i
                //LetterGraph.TranslateTransform(10, 10);
                //LetterGraph.RotateTransform(20, System.Drawing.Drawing2D.MatrixOrder.Append);




                //Draw letter i
                LetterGraph.TextRenderingHint = TextRenderingHint.AntiAlias;
                LetterGraph.DrawString(text[i].ToString().ToUpper(), MyFontFamily, new SolidBrush(GetRandomColor()), -10 , -10);

                if (debug) {
                    LetterGraph.DrawRectangle( new Pen(Color.Red, 1), new Rectangle(0, 0, Letter.Width - 1, Letter.Height  - 1) );
                    LetterGraph.DrawRectangle(new Pen(Color.Red), Letter.Width / 2, Letter.Height / 2, 1, 1);
                }

                //Add new letter to the original image at random height
                MyGraphics.DrawImage( Letter, new Point(lastLetterLeft, MyRandom.Next(-10,20)) );
                lastLetterLeft += Letter.Width;
            }
        }

        private PrivateFontCollection AddCustomFont(PrivateFontCollection pfc)
        {
            int fontLength = Resources.Katanf.Length;
            byte[] fontdata = Resources.Katanf;

            IntPtr data = Marshal.AllocCoTaskMem(fontLength);
            Marshal.Copy(fontdata, 0, data, fontLength);
            pfc.AddMemoryFont(data, fontLength);

            return pfc;
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
                    MyRandom.Next(200, 600), MyRandom.Next(200, 600)));
            }
        }

        private void AddRandomLines()
        {
            for (var i = 0; i < MyImage.Width / 50; i++)
            {
                Point point = GetRandomPoint();
                MyGraphics.DrawLine( new Pen(GetRandomColor(), 5f), point, new Point(point.X + (MyRandom.Next(-500,500)), point.Y + (MyRandom.Next(-500,500))) );
            }
        }

        private Point GetRandomPoint()
        {
            int randomX = MyRandom.Next(0, MyImage.Width);
            int randomY = MyRandom.Next(-50, MyImage.Height + 50);

            return new Point(randomX, randomY);
        }

        private Color GetRandomColor()
        {
            return Color.FromArgb(MyRandom.Next(150), MyRandom.Next(150), MyRandom.Next(150));
        }
    }
}
