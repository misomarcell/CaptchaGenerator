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

    class CaptchaGenerator
    {
        private Image _myImage;
        private Graphics _myGraphics;
        private string _myText;
        private Font _myFontFamily;
        private Color _myColor;
        private Random _myRandom;

        /* Config */
        public float LINE_THICKNESS = 7f;
        public float OVAL_THICKNESS = 2f;
        public String FONT_FAMILY_NAME = "Times New Roman";
        public float FONT_SIZE = 38f;
        public FontStyle FONT_STYLE = FontStyle.Bold;
        public bool DEBUG_MODE = false;

        public CaptchaGenerator()
        {
            _myFontFamily =  new Font(FONT_FAMILY_NAME, FONT_SIZE, FONT_STYLE);
            _myRandom =      new Random(DateTime.Now.Millisecond);
            _myImage =       new Bitmap(1,1);
            _myGraphics =    Graphics.FromImage(_myImage);
            _myColor =       GetRandomColor();
        }

        public CaptchaGenerator(string text) : this()
        {
            if ( text.Length > 50 )
                throw new ArgumentException("Max text length: 50");

            if (String.IsNullOrEmpty(text))
                _myText = ToRandomCase(GetRandomText(5));
            else
                _myText = ToRandomCase(text);
        }

        public CaptchaGenerator(int length) : this()
        {
            _myText = ToRandomCase(GetRandomText(length));
        }

        public Captcha Generate(Difficulties Difficulty )
        {
            SizeF size = _myGraphics.MeasureString(_myText, _myFontFamily);
            _myImage = new Bitmap((int)(size.Width * 1.5), (int)size.Height);
            _myGraphics = Graphics.FromImage(_myImage);  

            _myGraphics.Clear(Color.White);
            _myGraphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            switch (Difficulty)
            {
                case Difficulties.Easy:
                    GenerateText();
                    break;
                case Difficulties.Normal:
                    AddRandomLines(_myGraphics);
                    GenerateText();
                    break;
                case Difficulties.Hard:
                    AddRandomLines(_myGraphics);
                    AddRandomOvals(_myGraphics);
                    GenerateText();
                    break;
                case Difficulties.Unsolvable:
                    AddBackground(_myGraphics, _myImage);
                    AddRandomLines(_myGraphics);
                    AddRandomOvals(_myGraphics);
                    GenerateText();
                    break;
            }

            _myGraphics.Save();
            return new Captcha(_myImage, _myText);
        }

        private void AddBackground(Graphics myGraphics, Image myImage)
        {
            for ( var w = 0; w <= myImage.Width / 20; w++ )
            {
                for (var h = 0; h <= myImage.Width / 20; h++)
                {
                    myGraphics.FillEllipse(new SolidBrush(_myColor), w * 20, h * 20, 5, 5);
                }
            }
        }


        private void GenerateText(bool debug = false)
        {

            Image Letter = new Bitmap(1, 1);
            Graphics LetterGraph = Graphics.FromImage(Letter);

            int lastLetterLeft = 5;
            for ( var i = 0; i < _myText.Length; i++)
            {
                //Create new letter graphics
                var LetterSize = LetterGraph.MeasureString(_myText[i].ToString(), _myFontFamily);
                Letter = new Bitmap((int)LetterSize.Width, (int)LetterSize.Height);
                LetterGraph = Graphics.FromImage(Letter);

                // Rotate letter i
                if (!DEBUG_MODE )
                {
                    LetterGraph.TranslateTransform((float)Letter.Width / 2, (float)Letter.Height / 2);
                    LetterGraph.RotateTransform(_myRandom.Next( -90, 90 ));
                    LetterGraph.TranslateTransform(-(float)Letter.Width / 2, -(float)Letter.Height / 2);
                }

                //Draw letter i
                LetterGraph.TextRenderingHint = TextRenderingHint.AntiAlias;
                LetterGraph.DrawString(_myText[i].ToString(), _myFontFamily, new SolidBrush(_myColor),  0, 0);

                if (DEBUG_MODE) {
                    LetterGraph.DrawRectangle( new Pen(Color.Red, 1), new Rectangle(0, 0, Letter.Width - 1, Letter.Height  - 1) );
                    LetterGraph.DrawRectangle(new Pen(Color.Red), Letter.Width / 2, Letter.Height / 2, 1, 1);
                }

                //Add new letter to the original image at random height
                _myGraphics.DrawImage( Letter, new Point(lastLetterLeft, _myRandom.Next(-10, 10)) );
                lastLetterLeft += Letter.Width;
            }
        }

        private void AddRandomOvals(Graphics graphics)
        {
            for (var i = 0; i <_myImage.Width / 50; i++)
            {
                graphics.DrawEllipse(
                    new Pen(_myColor, 4f),
                    new Rectangle(GetRandomPoint().X, GetRandomPoint().Y - _myImage.Height,
                    _myRandom.Next(200, 600), _myRandom.Next(200, 600)));
            }
        }

        private void AddRandomLines(Graphics graphics)
        {
            for (var i = 0; i < _myImage.Width / 50; i++)
            {
                Point point1 = GetRandomPoint();
                Point point2 = new Point(_myRandom.Next(point1.X - 100, point1.X + 100), _myRandom.Next(point1.Y - 100, point1.Y + 100));
                graphics.DrawLine( new Pen(_myColor, LINE_THICKNESS), point1, point2);
            }
        }

        private string GetRandomText(int v)
        {
            string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ123456789";
            StringBuilder result = new StringBuilder();
            for ( var i = 0; i < v; i++ )
            {
                result.Append(alphabet[_myRandom.Next(0, alphabet.Length - 1)]);
            }
            return result.ToString();
        }

        private Point GetRandomPoint()
        {
            int randomX = _myRandom.Next(0, _myImage.Width);
            int randomY = _myRandom.Next(-50, _myImage.Height + 50);

            return new Point(randomX, randomY);
        }

        private Color GetRandomColor()
        {
            return Color.FromArgb(_myRandom.Next(150), _myRandom.Next(150), _myRandom.Next(150));
        }

        private string ToRandomCase(string text)
        {
            var result = new StringBuilder();
            for ( var i = 0; i < text.Length; i++ )
            {
                int random = _myRandom.Next(0, 2);
                if (random > 0)
                    result.Append(text[i].ToString().ToLower());
                else
                    result.Append(text[i].ToString().ToUpper());
            }
            return result.ToString();
        }
    }
}