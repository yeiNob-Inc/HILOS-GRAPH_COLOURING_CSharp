using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GRAPH_COLORING
{
    class Vertex
    { 
        // Lista con los aristas adyacentes.
        List<Edge> adjacentEdges;
        private bool isColored { get; set; }
        // El color del vértice se podrá obtener y asignar.
        private System.Drawing.Color color { set; get; }
        private int xCenter, yCenter; // Para saber el centro de x y y.
        public Vertex(System.Drawing.Color vertexColor, int xCenter, int yCenter)
        {
            adjacentEdges = new List<Edge>();
            isColored = false;
            color = vertexColor;
            this.xCenter = xCenter;
            this.yCenter = yCenter;
        }

        public void addNeighbor(Edge edge)
        {
            adjacentEdges.Add(edge);
        }
    }
}
