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
        public mainForm()
        {
            InitializeComponent();
        }

        private void mainForm_Load( object sender, EventArgs e )
        {
            // Something to start with
            backdrop.Image = new Bitmap( backdrop.Width, backdrop.Height );
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
            MessageBox.Show( "New document" );
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

            //if ( paper.Width < image.Width || paper.Height < image.Height )
            {
                var paper = backdrop.Image;
                var newPaper = new Bitmap( Math.Max( paper.Width, image.Width ), Math.Max( paper.Height, image.Height) );

                using ( Graphics grD = Graphics.FromImage( newPaper ) )
                {
                    grD.DrawImage( paper, new PointF( 0.0f, 0.0f ) );
                }

                using ( Graphics grD = Graphics.FromImage( newPaper ) )
                {
                    grD.DrawImage( image, new PointF( xy, xy ) );
                    xy += 25;
                }
                backdrop.Image = newPaper;
            }
        }
    }
}
