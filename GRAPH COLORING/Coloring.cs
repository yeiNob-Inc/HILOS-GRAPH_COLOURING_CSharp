using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;

namespace GRAPH_COLORING
{
    class Coloring
    {
        Graph graph;
        public Coloring(Graph graph)
        {
            this.graph = graph;
        }
        public void GraphColoring()
        {
            List<Color> colors = new List<Color>() ; // Lista de colores. Se pueden ir agregando más.
            Random r = new Random();
            colors.Add(Color.FromArgb(r.Next(256), r.Next(256), r.Next(256)));
            for (int i = 0, colorIndex = 0; i < graph.graphMatrix.GetLength(0); i++)
                for (int j = 0; j < graph.graphMatrix.GetLength(1); j++)
                    // Colorea solo si existe y tiene alguna relación.
                    if (graph.graphMatrix[i, j] && graph.VertexSet[i, j].ConnectedVertex.Count > 0) {// Si hay un edge entre ellos.
                        graph.VertexSet[i, j].Color = colors.ElementAt(colorIndex);
                    }
        }
        // Establecer a los vecinos que no pueden colorear con el color actual.
        private void SetNeighborNotColorable()
        {

        }
    }
}
