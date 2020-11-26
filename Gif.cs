using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GifSceneMaker
{
    public class Gif
    {
        public Gif( Bitmap bitmap )
        {
            this.Bitmap = bitmap;
        }

        public Bitmap Bitmap
        {
            get;
            private set;
        }

        public int X
        {
            get;
            set;
        }

        public int Y
        {
            get;
            set;
        }

        public int Width
        {
            get
            {
                return Bitmap.Width;
            }
        }

        public int Height
        {
            get
            {
                return Bitmap.Height;
            }
        }

        public void Draw( Graphics graphics, int timeSlice, int timeSlices )
        {
            graphics.DrawImage( Bitmap, new PointF( X, Y ) );
        }
    }
}
