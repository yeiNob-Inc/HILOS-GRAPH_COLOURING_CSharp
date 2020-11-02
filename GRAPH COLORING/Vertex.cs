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
        public List<Edge> AdjacentEdges { set; get; }
        public bool IsColored { get; set; }
        // El color del vértice se podrá obtener y asignar.
        public System.Drawing.Color Color { set; get; }
        public float XCenter { set; get; }
        public float YCenter { set; get; }
        public float radio;
        // Número de vértice en x y y.

        public int XVertex { set; get; }
        public int YVertex { set; get; }
        public List<Vertex> ConnectedVertex { get; set; } // Lista de vértices conectados.
        // Lista de colores que no se pueden utilizar para este vértice.
        public List<int> NotColoreable { get; set; }
        // Recibimos las coordenadas del vértice.
        public Vertex(System.Drawing.Color vertexColor, int xVertex, int yVertex)
        {
            AdjacentEdges = new List<Edge>();
            ConnectedVertex = new List<Vertex>();
            NotColoreable = new List<int>();
            IsColored = false;
            Color = vertexColor;
            //this.xCenter = xCenter;
            //this.yCenter = yCenter;
            // Que el radio sea la mitad del radio real para que el nodo sea pequeño.
            radio = Grid.CellSize / 4;
            this.XVertex = xVertex;
            this.YVertex = yVertex;
            XCenter = xVertex * Grid.CellSize + radio * 2;
            YCenter = yVertex * Grid.CellSize + radio * 2;
        }

        public void AddNeighbor(Edge edge)
        {
            AdjacentEdges.Add(edge);
        }
        // Método para dibujar el vértice en la malla.
        public void DrawVertex(PaintEventArgs e)
        {
            e.Graphics.DrawEllipse(new System.Drawing.Pen(System.Drawing.Color.Chocolate), XCenter - radio, YCenter - radio, radio * 2, radio * 2);
            e.Graphics.FillEllipse(new SolidBrush(Color), XCenter - radio, YCenter - radio, radio * 2, radio * 2);
            //e.Graphics.DrawPie(new System.Drawing.Pen(System.Drawing.Color.Aquamarine), xCenter, yCenter, radio, radio, 0, 360);
            //e.Graphics.FillPie(new SolidBrush(color), xCenter, yCenter, radio, radio, 0, 360);
        }
        // Mètodo que devuelve True si se trata del mismo vértice.
        public bool IsTheSameVertex(Vertex v)
        {
            // Coincide el primer vértice con el primero o segundo, y el segundo con el que queda.
            return (v.XVertex == XVertex && v.YVertex == YVertex) || (v.XVertex == YVertex && v.YVertex == XVertex);
        }

    }
}
