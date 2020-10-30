using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GRAPH_COLORING
{
    public partial class Form1 : Form
    {
        Grid g;
        public Form1()
        {
            InitializeComponent();
            g = new Grid(25);
        }

        private void panel_GraphGrid_Paint(object sender, PaintEventArgs e)
        {
            // Siempre que se minimiza la ventana o se hace algún movimiento, hay que redibujar la malla.
            //Grid.MakeGridNoThreads(e, panel_GraphGrid, 5);
            g.MakeGridThreads(panel_GraphGrid, e, 5);
        }
    }
}
