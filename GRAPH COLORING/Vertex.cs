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
        List<Edge> adjacentEdges;
        public bool IsColored { get; set; }
        // El color del vértice se podrá obtener y asignar.
        public System.Drawing.Color color { set; get; }
        private int xVertex, yVertex; // Para saber el centro de x y y.
        private float radio, xCenter, yCenter;
        // Recibimos las coordenadas del vértice.
        public Vertex(System.Drawing.Color vertexColor, int xVertex, int yVertex)
        {
            adjacentEdges = new List<Edge>();
            IsColored = false;
            color = vertexColor;
            //this.xCenter = xCenter;
            //this.yCenter = yCenter;
            radio = Grid.CellSize / 2;

            xCenter = xVertex * Grid.CellSize + radio;
            yCenter = xVertex * Grid.CellSize + radio;
        }

        public void addNeighbor(Edge edge)
        {
            adjacentEdges.Add(edge);
        }
        // Método para dibujar el vértice en la malla.
        public void DrawVertex(PaintEventArgs e)
        {
            e.Graphics.DrawEllipse(new System.Drawing.Pen(System.Drawing.Color.Aquamarine), xCenter - radio, yCenter - radio, radio * 2, radio * 2);
            e.Graphics.FillEllipse(new SolidBrush(color), xCenter - radio, yCenter - radio, radio * 2, radio * 2);
            //e.Graphics.DrawPie(new System.Drawing.Pen(System.Drawing.Color.Aquamarine), xCenter, yCenter, radio, radio, 0, 360);
            //e.Graphics.FillPie(new SolidBrush(color), xCenter, yCenter, radio, radio, 0, 360);
        }
    }
}
