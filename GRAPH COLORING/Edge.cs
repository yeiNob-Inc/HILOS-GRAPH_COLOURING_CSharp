using System;
using System.Drawing;
using System.Windows.Forms;

namespace GRAPH_COLORING
{
    class Edge
    {
        // Queremos obtener los vértices.
        public Vertex startVertex { get; }
        public Vertex targetVertex { get; }
        Color color;
        public Edge(Vertex startVertex, Vertex targetVertex)
        {
            this.startVertex = startVertex;
            this.targetVertex = targetVertex;

            Random r = new Random(); // Para los colores.
            color = Color.FromArgb(r.Next(256), r.Next(256), r.Next(256));
            while (color == Color.Transparent || color == Color.Empty) // Que no salgan colores transparentes.
                color = Color.FromArgb(r.Next(256), r.Next(256), r.Next(256));
        }
        public void DrawEdge(PaintEventArgs e)
        {
            e.Graphics.DrawLine(new System.Drawing.Pen(color, 3), startVertex.XCenter, startVertex.YCenter, targetVertex.XCenter, targetVertex.YCenter);
        }
        // Escribir los Edges.
        public void WriteEdge(Label label_EdgeList)
        {
            label_EdgeList.Text += " V("+ startVertex.XVertex + ", " + startVertex.YVertex + "), " + "V("+ targetVertex.XVertex + ", " + targetVertex.YVertex + ")\n";
        }
    }
}
