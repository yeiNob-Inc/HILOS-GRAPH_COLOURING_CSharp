using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GRAPH_COLORING
{
    class Vertex
    { 
        // Lista con los aristas adyacentes.
        public List<Edge> adjacentEdges { set; get; }
        public bool IsColored { get; set; }
        // El color del vértice se podrá obtener y asignar.
        public System.Drawing.Color color { set; get; }
        private int xVertex, yVertex; // Para saber el centro de x y y.
        public float XCenter { set; get; }
        public float YCenter { set; get; }
        public float radio;
        // Recibimos las coordenadas del vértice.
        public Vertex(System.Drawing.Color vertexColor, int xVertex, int yVertex)
        {
            adjacentEdges = new List<Edge>();
            IsColored = false;
            color = vertexColor;
            //this.xCenter = xCenter;
            //this.yCenter = yCenter;
            // Que el radio sea la mitad del radio real para que el nodo sea pequeño.
            radio = Grid.CellSize / 4;

            XCenter = xVertex * Grid.CellSize + radio * 2;
            YCenter = yVertex * Grid.CellSize + radio * 2;
        }

        public void addNeighbor(Edge edge)
        {
            adjacentEdges.Add(edge);
        }
        // Método para dibujar el vértice en la malla.
        public void DrawVertex(PaintEventArgs e)
        {
            e.Graphics.DrawEllipse(new System.Drawing.Pen(System.Drawing.Color.Aquamarine), XCenter - radio, YCenter - radio, radio * 2, radio * 2);
            e.Graphics.FillEllipse(new SolidBrush(color), XCenter - radio, YCenter - radio, radio * 2, radio * 2);
            //e.Graphics.DrawPie(new System.Drawing.Pen(System.Drawing.Color.Aquamarine), xCenter, yCenter, radio, radio, 0, 360);
            //e.Graphics.FillPie(new SolidBrush(color), xCenter, yCenter, radio, radio, 0, 360);
        }
    }
}
