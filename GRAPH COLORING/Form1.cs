using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
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
            g = new Grid(panel_GraphGrid, 10);
            graph = new Graph();
            label_RandomGraph.Text += "\n" + graph.graphMatrix.Length;
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

        // MÉTODO PARA QUE AL PRESIONAR ENTER SE INGRESEN LOS DATOS DEL VÉRTICE.

        private void textBox_VertexXY_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                try
                {
                    graph.AddVertex(int.Parse(textBox_VertexX.Text), int.Parse(textBox_VertexY.Text));
                    panel_GraphGrid.Invalidate(); // Dibujar el nuevo vértice.
                }
                catch // Si hay una excepción por espacios en blanco, letras, etc., sale el Pop up.
                {
                    Form popUp = new PopUp_XYError();
                    popUp.ShowDialog();
                }
        }
        // MÉTODO PARA QUE AL DAR ENTER SE INGRESE LA INFORMACIÓN DE LOS ARISTAS.

        private void textBox_EdgeV1V2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
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
        // Al dar click (con el mouse, espacio o enter) en agregar Vertex, se crea.

        private void btn_AddVertex_Click(object sender, EventArgs e)
        {
            try
            {
                graph.AddVertex(int.Parse(textBox_VertexX.Text), int.Parse(textBox_VertexY.Text));
                panel_GraphGrid.Invalidate(); // Dibujar el nuevo vértice.
                label_VertexNumber.Text = "NÚMERO ACTUAL\nDE VÉRTICES:\n" + graph.NumberOfVertices;
                label_VertexNumber.Refresh();

            }
            catch // Si hay una excepción por espacios en blanco, letras, etc., sale el Pop up.
            {
                Form popUp = new PopUp_XYError();
                popUp.ShowDialog();
            }
        }
        // Al dar click (con el mouse, espacio o enter) en agregar Edge, se crea.

        private void btn_AddEdge_Click(object sender, EventArgs e)
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

        private void btn_GraphColoring_Click(object sender, EventArgs e)
        {
            Coloring c = new Coloring(graph);
            c.GraphColoring(this);
            //Coloring c = new Coloring(3, graph.VertexSet);
            //c.graphColoring(graph.graphMatrix, 2);
            panel_GraphGrid.Invalidate();
            //graph.SetVertexColored(false);
            //List<Color> colors = new List<Color>();
            //colors.Add(Color.Red);
            //colors.Add(Color.Blue);
            //Coloring graphColoring = new Coloring(colors, graph.NumberOfVertices);
            //Random r = new Random();
            //while (!graphColoring.SetColors(graph.VertexPrintable.ElementAt(0)))
            //{
            //    // Si no hay soluciòn, agregamos un nuevo color.
            //    graphColoring.Colors.Add(Color.FromArgb(r.Next(256), r.Next(256), r.Next(256)));
            //}
            //panel_GraphGrid.Invalidate(); // Dibujar los vértices.

        }

        private void btn_EraseGraph_Click(object sender, EventArgs e)
        {
            // Para borrar los objetos del grafo, hay que usar Dispose, pero
            // hay que implementarlo manualmente con la interfaz.
            // graph.Dispose();
            // Crear un nuevo grafo sustituyendo al anterior para borrar el anterior sin hacerlo manualmente.
            //Graph graph = new Graph();
            panel_GraphGrid.Invalidate();
        }

        // Podría crear un grafo aleatorio con hilos.
        private void btn_CreateRandomGraph_Click(object sender, EventArgs e)
        {
            try
            {
                //Graph graph = new Graph();
                Random r = new Random();
                //int numEdges = 0; // Número de aristas que se crearán
                // Crear vértices.
                for (int i = 0; i < int.Parse(textBox_RandomGraph.Text); i++)
                    graph.AddVertex(r.Next(Grid.NumCells), r.Next(Grid.NumCells));
                // Crear aristas.
                for(int i = 0; i < Grid.NumCells; i++)
                    for(int j = 0; j < Grid.NumCells; j++)
                    {
                        graph.AddEdge(i, j, r.Next(Grid.NumCells), r.Next(Grid.NumCells),
                                        label_EdgeList);
                    }
                panel_GraphGrid.Invalidate();
        }
            catch
            {
                Form popUp = new PopUp_XYError();
                popUp.ShowDialog();
            }
}
    }
}
