using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GifSceneMaker
{
    public partial class mainForm : Form
    {
        private List<Gif> gifs = new List<Gif>();

        public mainForm()
        {
            InitializeComponent();

            Gif selected = null;
            var currentMouseLocation = backdrop.Location;
            backdrop.MouseMove += delegate ( object sender, MouseEventArgs e )
            {
                if ( e.Button == MouseButtons.None )
                {
                    selected = null;
                    foreach ( var gif in gifs )
                    {
                        gif.Selected = false;
                        if ( gif.IsWithin( e.Location ) )
                        {
                            selected = gif;
                        }
                    }
                    if ( selected != null )
                    {
                        selected.Selected = true;
                    }
                }
                else if ( e.Button == MouseButtons.Left && selected != null )
                {
                    selected.X += ( e.X - currentMouseLocation.X );
                    selected.Y += ( e.Y - currentMouseLocation.Y );
                }
                currentMouseLocation = e.Location;
                updateBackdrop();
            };
        }

        private void mainForm_Load( object sender, EventArgs e )
        {
            // Something to start with
            newDocument();
        }

        private void newToolStripButton_Click( object sender, EventArgs e )
        {
            newDocument();
        }

        private void newToolStripMenuItem_Click( object sender, EventArgs e )
        {
            newDocument();
        }

        private void exitToolStripMenuItem_Click( object sender, EventArgs e )
        {
            exitApplication();
        }

        private void insertToolStripMenuItem_Click( object sender, EventArgs e )
        {
            insertImage();
        }

        private void insertToolStripButton_Click( object sender, EventArgs e )
        {
            insertImage();
        }

        private void newDocument()
        {
            gifs.Clear();
            backdrop.SetBounds( backdrop.Location.X, backdrop.Location.Y, 500, 500 );
            backdrop.Image = new Bitmap( backdrop.Width, backdrop.Height );

            // Debug stuff
            nextImage = 0;
            xy = 0;
        }

        private void exitApplication()
        {
            // if( dirty ) prompt and save
            Application.Exit();
        }

        int nextImage = 0;
        int xy = 0;
        private void insertImage()
        {
            var files = new String[]
                {
                    @"C:\Users\ian\Downloads\Gifs\Photo 25-11-2020, 20 19 09.gif",
                    @"C:\Users\ian\Downloads\Gifs\Photo 25-11-2020, 20 17 26.gif",
                    @"C:\Users\ian\Downloads\Gifs\Photo 25-11-2020, 20 17 49.gif",
                    @"C:\Users\ian\Downloads\Gifs\Photo 25-11-2020, 20 18 53.gif"
                };
            var image = Image.FromFile( files[ nextImage ] );
            nextImage++;
            nextImage %= files.Length;

            if ( image is Bitmap )
            {
                gifs.Add( new Gif( image as Bitmap )
                {
                    X = xy,
                    Y = xy,
                } );
                xy += 50;
            }

            updateBackdrop();
        }

        private void updateBackdrop()
        {
            // Work out the required paper size
            int width = backdrop.Image.Width;
            int height = backdrop.Image.Height;
            foreach ( var gif in gifs )
            {
                width = Math.Max( width, gif.X + gif.Width );
                height = Math.Max( height, gif.Y + gif.Height );
            }

            // Draw the images in z-order
            var newPaper = new Bitmap( width, height );
            using ( Graphics grD = Graphics.FromImage( newPaper ) )
            {
                foreach ( var gif in gifs )
                {
                    gif.Draw( grD, 1, 1 );
                }
            }

            // Make it current
            backdrop.Width = newPaper.Width;
            backdrop.Height = newPaper.Height;
            backdrop.Image = newPaper;

            /*
            foreach ( var frameDimension in image.FrameDimensionsList )
            {
                var frameCount = image.GetFrameCount( new System.Drawing.Imaging.FrameDimension( frameDimension ) );
                Console.WriteLine( $"Image: {frameDimension}: {frameCount}" );
            }

            // Add the newly introduced image to the backdrop
            var paper = backdrop.Image;
            var newPaper = new Bitmap( Math.Max( paper.Width, image.Width ), Math.Max( paper.Height, image.Height) );

            // We're making a new image, so copy the prior contents
            using ( Graphics grD = Graphics.FromImage( newPaper ) )
            {
                //grD.DrawImage( paper, new PointF( 0.0f, 0.0f ) );
            }

            foreach ( var frameDimension in image.FrameDimensionsList )
            {
                var frameCount = image.GetFrameCount( new System.Drawing.Imaging.FrameDimension( frameDimension ) );

                for ( int loop = 0; loop < frameCount; loop++ )
                {
                    image.SelectActiveFrame( new System.Drawing.Imaging.FrameDimension( frameDimension ), loop );
                    newPaper.SelectActiveFrame( new System.Drawing.Imaging.FrameDimension( frameDimension ), loop );

                    for ( int x = 0; x < image.Width; x++ )
                    {
                        for ( int y = 0; y < image.Height; y++ )
                        {
                            //newPaper.SetPixel( x, y, ( (Bitmap) image ).GetPixel( x, y ) );
                        }
                    }
                    // Now add the new image
                    using ( Graphics grD = Graphics.FromImage( newPaper ) )
                    {
                        grD.DrawImage( image, new PointF( 0, 0 ) );
                    }
                    //newPaper.SaveAdd( new System.Drawing.Imaging.EncoderParameters( 0 ) );
                }
            }

            foreach ( var frameDimension in newPaper.FrameDimensionsList )
            {
                var frameCount = newPaper.GetFrameCount( new System.Drawing.Imaging.FrameDimension( frameDimension ) );
                Console.WriteLine( $"Paper: {frameDimension}: {frameCount}" );
            }

            // Now add the new image
            using ( Graphics grD = Graphics.FromImage( newPaper ) )
            {
//                grD.DrawImage( image, new PointF( 0, 0 ) );
            }


            // Make it current
            backdrop.Width = newPaper.Width;
            backdrop.Height = newPaper.Height;
            backdrop.Image = newPaper;
            */
        }
    }
}
