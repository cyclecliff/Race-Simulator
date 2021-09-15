using Controller;
using Model;
using System.Collections.Generic;
using System.Drawing;

namespace WPF
{
    public static class PictureLogic
    {
        static int WidthPixels { get; set; }
        static int HeightPixels { get; set; }
        private static Dictionary<string, Bitmap> StringBitmapKV { get; set; }
        public static void Initialize()
        {
           
            //Set_Width_Height_Pixels();
        }

        public static void Set_Width_Height_Pixels()
        {
            int WidthInSections  = 0;
            int HeightInSections = 0;

            int currentX = 0;
            int currentY = 0;
           
            foreach(Section section in Data.CurrentRace.track.Sections)
            {

                 int X = 0;
                 int Y = 0;

                switch (section.Direction)
                {
                    case Direction.Up:

                        Y -= 1;
                        currentY -= 1;

                    break;
                    case Direction.Right:

                        X += 1;
                        currentX += 1;

                        if (!(currentX <= 0))
                        {
                            WidthInSections += 1;
                        }
                        
                    break;
                    case Direction.Down:

                        Y += 1;
                        currentY += 1;

                        if (!(currentY <= 0)) 
                        {
                            HeightInSections += 1;
                        }

                    break;
                    case Direction.Left:

                        X -= 1;
                        currentX -= 1;

                    break;
                }

                if(X < 0)
                {
                    WidthInSections += -X;
                }
                if (Y < 0)
                {
                    HeightInSections += -Y;
                }
            }

            WidthPixels = WidthInSections * 200;
            HeightPixels = HeightInSections * 200;
        }

        public static Bitmap GetBitmapFromCache(string imageURL) // all the links for all the variations?
        {
            if(StringBitmapKV.ContainsKey(imageURL)) 
            {
                return StringBitmapKV[imageURL];
            }

            Bitmap image = new Bitmap(imageURL);

            StringBitmapKV.Add(imageURL, image);

            return image;
        }
        
        public static Bitmap CreateEmptyBitmap(int width, int height)
        {
           
            if (StringBitmapKV.ContainsKey("empty")) 
                return (Bitmap)GetBitmapFromCache("empty").Clone();

            Bitmap  returnValue = new Bitmap(width, height);

            Graphics graphics = Graphics.FromImage(returnValue);

            SolidBrush solidBrush = new SolidBrush(System.Drawing.Color.Green);

            graphics.FillRectangle(solidBrush, 0, 0, width, height);

            StringBitmapKV.Add("empty", returnValue);

            return (Bitmap)returnValue.Clone();
        }

        public static void ClearStringBitmapKV()
        {
            StringBitmapKV.Clear();
        }

        #region png addresses

        public static string empty    =

        public static string finish_0 = @"C:\Users\lubbe\Desktop\GitHub\Race Simulator\WPF\Pictures\Track\Finish\finish_0.png";
        public static string finish_1 = @"C:\Users\lubbe\Desktop\GitHub\Race Simulator\WPF\Pictures\Track\Finish\finish_1.png";
        public static string finish_2 = @"C:\Users\lubbe\Desktop\GitHub\Race Simulator\WPF\Pictures\Track\Finish\finish_2.png";
        public static string finish_3 = @"C:\Users\lubbe\Desktop\GitHub\Race Simulator\WPF\Pictures\Track\Finish\finish_3.png";

        public static string leftcorner_0 = @"C:\Users\lubbe\Desktop\GitHub\Race Simulator\WPF\Pictures\Track\LeftCorner\leftcorner_0.png";
        public static string leftcorner_1 = @"C:\Users\lubbe\Desktop\GitHub\Race Simulator\WPF\Pictures\Track\LeftCorner\leftcorner_1.png";
        public static string leftcorner_2 = @"C:\Users\lubbe\Desktop\GitHub\Race Simulator\WPF\Pictures\Track\LeftCorner\leftcorner_2.png";
        public static string leftcorner_3 = @"C:\Users\lubbe\Desktop\GitHub\Race Simulator\WPF\Pictures\Track\LeftCorner\leftcorner_3.png";

        public static string rightcorner_0 = @"C:\Users\lubbe\Desktop\GitHub\Race Simulator\WPF\Pictures\Track\RightCorner\rightcorner_0.png";
        public static string rightcorner_1 = @"C:\Users\lubbe\Desktop\GitHub\Race Simulator\WPF\Pictures\Track\RightCorner\rightcorner_1.png";
        public static string rightcorner_2 = @"C:\Users\lubbe\Desktop\GitHub\Race Simulator\WPF\Pictures\Track\RightCorner\rightcorner_2.png";
        public static string rightcorner_3 = @"C:\Users\lubbe\Desktop\GitHub\Race Simulator\WPF\Pictures\Track\RightCorner\rightcorner_3.png";

        public static string startgrid_0 = @"C:\Users\lubbe\Desktop\GitHub\Race Simulator\WPF\Pictures\Track\StartGrid\startgrid_0.png";
        public static string startgrid_1 = @"C:\Users\lubbe\Desktop\GitHub\Race Simulator\WPF\Pictures\Track\StartGrid\startgrid_1.png";
        public static string startgrid_2 = @"C:\Users\lubbe\Desktop\GitHub\Race Simulator\WPF\Pictures\Track\StartGrid\startgrid_2.png";
        public static string startgrid_3 = @"C:\Users\lubbe\Desktop\GitHub\Race Simulator\WPF\Pictures\Track\StartGrid\startgrid_3.png";

        public static string straight_0 = @"C:\Users\lubbe\Desktop\GitHub\Race Simulator\WPF\Pictures\Track\Straight\straight_0.png";
        public static string straight_1 = @"C:\Users\lubbe\Desktop\GitHub\Race Simulator\WPF\Pictures\Track\Straight\straight_1.png";
        public static string straight_2 = @"C:\Users\lubbe\Desktop\GitHub\Race Simulator\WPF\Pictures\Track\Straight\straight_2.png";
        public static string straight_3 = @"C:\Users\lubbe\Desktop\GitHub\Race Simulator\WPF\Pictures\Track\Straight\straight_3.png";

        #endregion


    }
}
