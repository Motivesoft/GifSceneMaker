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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void toolStripButton1_Click( object sender, EventArgs e )
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

        private void newDocument()
        {
            MessageBox.Show( "New document" );
        }

        private void exitApplication()
        {
            // if( dirty ) prompt and save
            Application.Exit();
        }
    }
}
