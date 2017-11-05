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
    enum Difficulties { Easy = 0, Normal = 1, Hard = 2, Unsolvable = 3 }

    class Captcha
    {
        private Image MyImage;
        private Graphics MyGraphics;
        private string MyText;
        private Font MyFontFamily;
        private Color MyColor;
        private Difficulties MyDifficulty;
        private Random MyRandom;

        /* Config */
        public float LINE_THICKNESS = 7f;
        public float OVAL_THICKNESS = 2f;
        public String FONT_FAMILY_NAME = "Georgia";
        public float FONT_SIZE = 38f;
        public FontStyle FONT_STYLE = FontStyle.Bold;
        public bool DEBUG_MODE = false;

        public Captcha(String Text, Difficulties Difficulty)
        {

            MyFontFamily =  new Font(FONT_FAMILY_NAME, FONT_SIZE, FONT_STYLE);
            MyRandom =      new Random(DateTime.Now.Millisecond);
            MyImage =       new Bitmap(1,1);
            MyGraphics =    Graphics.FromImage(MyImage);
            MyDifficulty =  Difficulty;
            MyColor =       GetRandomColor();

            if (Text.Length > 50)
                throw new ArgumentException("Max text length: 50");
            if (String.IsNullOrEmpty(Text))
                MyText = GetRandomText(5);
            else
                MyText = Text.ToUpper();
        }

        public Image GenerateCaptcha()
        {
            SizeF size = MyGraphics.MeasureString(MyText, MyFontFamily);
            MyImage = new Bitmap((int)(size.Width * 1.4), (int)size.Height);
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

            //PerlinNoise p1 = new PerlinNoise(MyRandom.Next(0, 1000));
            Bitmap bm = new Bitmap(MyImage.Width, myImage.Height);

            for (var w = 0; w < bm.Width; w++)
            {
                for (var h = 0; h < bm.Height; h++)
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

            Image Letter = new Bitmap(1, 1);
            Graphics LetterGraph = Graphics.FromImage(Letter);

            int lastLetterLeft = 5;
            for ( var i = 0; i < MyText.Length; i++)
            {


                //Create new letter graphics
                var LetterSize = LetterGraph.MeasureString(text[i].ToString(), MyFontFamily);
                Letter = new Bitmap((int)LetterSize.Width, (int)LetterSize.Height);
                LetterGraph = Graphics.FromImage(Letter);



                // Rotate letter i
                if (!DEBUG_MODE )
                {
                    LetterGraph.TranslateTransform((float)Letter.Width / 2, (float)Letter.Height / 2);
                    LetterGraph.RotateTransform(MyRandom.Next( -90, 90 ));
                    LetterGraph.TranslateTransform(-(float)Letter.Width / 2, -(float)Letter.Height / 2);
                }

                //Draw letter i
                LetterGraph.TextRenderingHint = TextRenderingHint.AntiAlias;
                LetterGraph.DrawString(MyText[i].ToString(), MyFontFamily, new SolidBrush(MyColor),  0, 0);

                if (DEBUG_MODE) {
                    LetterGraph.DrawRectangle( new Pen(Color.Red, 1), new Rectangle(0, 0, Letter.Width - 1, Letter.Height  - 1) );
                    LetterGraph.DrawRectangle(new Pen(Color.Red), Letter.Width / 2, Letter.Height / 2, 1, 1);
                }

                //Add new letter to the original image at random height
                MyGraphics.DrawImage( Letter, new Point(lastLetterLeft, MyRandom.Next(-10, 10)) );
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
                    new Pen(MyColor, 4f),
                    new Rectangle(GetRandomPoint().X, GetRandomPoint().Y - MyImage.Height,
                    MyRandom.Next(200, 600), MyRandom.Next(200, 600)));
            }
        }

        private void AddRandomLines()
        {
            for (var i = 0; i < MyImage.Width / 50; i++)
            {
                Point point1 = GetRandomPoint();
                Point point2 = new Point(MyRandom.Next(point1.X - 100, point1.X + 100), MyRandom.Next(point1.Y - 100, point1.Y + 100));
                MyGraphics.DrawLine( new Pen(MyColor, LINE_THICKNESS), point1, point2);
            }
        }

        private string GetRandomText(int v)
        {
            string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            StringBuilder result = new StringBuilder();
            for ( var i = 0; i < v; i++ )
            {
                result.Append(alphabet[MyRandom.Next(0, alphabet.Length - 1)]);
            }
            return result.ToString();
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