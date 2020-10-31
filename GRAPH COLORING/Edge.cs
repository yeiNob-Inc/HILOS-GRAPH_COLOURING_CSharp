using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GRAPH_COLORING
{
    class Edge
    {
        Vertex startVertex;
        Vertex targetVertex;
        System.Drawing.Color color;
        public Edge(Vertex startVertex, Vertex targetVertex)
        {
            this.startVertex = startVertex;
            this.targetVertex = targetVertex;

            Random r = new Random(); // Para los colores.
            color = System.Drawing.Color.FromArgb(r.Next(256), r.Next(256), r.Next(256));
        }
        public void DrawEdge(PaintEventArgs e)
        {
            e.Graphics.DrawLine(new System.Drawing.Pen(color, 3), startVertex.XCenter, startVertex.YCenter, targetVertex.XCenter, targetVertex.YCenter);
        }
    }
}
