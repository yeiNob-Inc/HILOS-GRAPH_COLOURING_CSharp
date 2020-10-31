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
        Graph graph;
        //Vertex v;
        public Form1()
        {
            InitializeComponent();
            g = new Grid(panel_GraphGrid, 5);
            graph = new Graph(5);
            //v = new Vertex(System.Drawing.Color.Beige, 3, 4);
        }

        private void panel_GraphGrid_Paint(object sender, PaintEventArgs e)
        {
            // Siempre que se minimiza la ventana o se hace algún movimiento, hay que redibujar la malla.
            Grid.MakeGridNoThreads(e);
            //g.MakeGridThreads(panel_GraphGrid, e, 1);
            graph.DrawAllVertex(e);

            //v = new Vertex(System.Drawing.Color.Red, 1, 2);
            //v.DrawVertex(e);
        }

        private void btn_AddVertex(object sender, MouseEventArgs e)
        {

        }
    }
}
