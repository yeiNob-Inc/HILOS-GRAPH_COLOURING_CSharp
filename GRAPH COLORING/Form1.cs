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
            graph = new Graph();
            //v = new Vertex(System.Drawing.Color.Beige, 3, 4);
        }

        private void panel_GraphGrid_Paint(object sender, PaintEventArgs e)
        {
            // Siempre que se minimiza la ventana o se hace algún movimiento, hay que redibujar la malla.
            Grid.MakeGridNoThreads(e);
            //g.MakeGridThreads(panel_GraphGrid, e, 1);
            //graph.DrawAllVertex(e);
            graph.DrawGraph(e);
            //v = new Vertex(System.Drawing.Color.Red, 1, 2);
            //v.DrawVertex(e);
        }

        private void btn_AddVertex_MouseUp(object sender, MouseEventArgs e)
        {
            try
            {
                graph.AddVertex(int.Parse(textBox_VertexX.Text), int.Parse(textBox_VertexY.Text));
                panel_GraphGrid.Invalidate(); // Dibujar el nuevo vértice.
            }
            catch
            {
                Form popUp = new PopUp_XYError();
                popUp.ShowDialog();
            }
        }

        private void btn_AddEdge_MouseUp(object sender, MouseEventArgs e)
        {
            try
            {

                graph.AddEdge(int.Parse(textBox_EdgeV1X.Text),
                              int.Parse(textBox_EdgeV1Y.Text),
                              int.Parse(textBox_EdgeV2X.Text),
                              int.Parse(textBox_EdgeV2Y.Text), label_EdgeList);
                panel_GraphGrid.Invalidate(); // Dibujar el nuevo vértice.
            }
            catch
            {
                Form popUp = new PopUp_XYError();
                popUp.ShowDialog();
            }
        }
    }
}
