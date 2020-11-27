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

        public bool IsWithin( Point point )
        {
            return point.X >= X && point.X < ( X + Width ) && point.Y >= Y && point.Y < ( Y + Height );
        }

        public bool Selected
        {
            get;
            set;
        }

        public void Draw( Graphics graphics, int timeSlice, int timeSlices )
        {
            graphics.DrawImage( Bitmap, new PointF( X, Y ) );
            if ( Selected )
            {
                var rect = new Rectangle( X, Y, Width, Height );
                graphics.DrawRectangle( Pens.Black, rect );
                rect.Inflate( -1, -1 );
                graphics.DrawRectangle( Pens.Yellow, rect );
            }
        }
    }
}
