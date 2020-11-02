using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* 
 * Clase que manejará el coloreado del grafo.
 * **/

namespace GRAPH_COLORING
{
    class Coloring
    {
        // Lista de colores para ir agregando más cuando no haya solución, por eso es pública.
        public List<Color> Colors { get; set; }
        //Color[] colors;
        int colorCount;
        int numberOfVertices;

        public Coloring(List<Color> colors, int N)
        {
            this.Colors = colors;
            this.numberOfVertices = N;
            colorCount = 0;

        }

        public bool SetColors(Vertex vertex)
        {

            for (int colorIndex = 0; colorIndex < Colors.Count; colorIndex++)
            {

                // Step-1 : checking validity
                // Si no se puede colorear el actual, avanzar el índice.
                if (!CanColorWith(colorIndex, vertex)) continue;  //Step-2 : Continue

                //Step-3 : coloring
                //vertex.Color = colors[colorIndex]; // Colorear el vértice actual.
                vertex.Color = Colors.ElementAt(colorIndex); // Colorear el vértice actual.
                vertex.IsColored = true;
                colorCount++;

                //Step-4 : Whether all vertices colored?
                if (colorCount == numberOfVertices) //Base Case
                    return true;

                //Step-5 : Next uncolored vertex
                foreach (Edge edge in vertex.AdjacentEdges)
                {
                    if (!edge.targetVertex.IsColored)
                    {

                        if (SetColors(edge.targetVertex))
                            return true;
                    }

                }
            }

            // Step-3 : Backtracking
            vertex.Color = Color.Transparent;
            vertex.IsColored = false;
            return false;
        }

        //Function to check whether it is valid to color with color[colorIndex]
        private bool CanColorWith(int colorIndex, Vertex vertex)
        {
            Vertex neighborVertex;
            // Recorrer los vértices adyacentes del Edge en el vértice.
            foreach (Edge edge in vertex.AdjacentEdges)
            {
                neighborVertex = edge.targetVertex;
                //if (neighborVertex.IsColored && neighborVertex.Color == colors[colorIndex])
                if (neighborVertex.IsColored && neighborVertex.Color == Colors.ElementAt(colorIndex))
                    return false;
            }
            return true;
        }
    }
}
