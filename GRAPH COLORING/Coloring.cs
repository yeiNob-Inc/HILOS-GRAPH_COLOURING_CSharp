using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* 
 * Clase que manejará el coloreado del grafo.**/

namespace GRAPH_COLORING
{
    //class Coloring
    //{
    //    Color[] colors;
    //    int colorCount;
    //    int numberOfVertices;

    //    public Coloring(Color[] colors, int N)
    //    {
    //        this.colors = colors;
    //        this.numberOfVertices = N;

    //    }

    //    public bool setColors(Vertex vertex)
    //    {

    //        for (int colorIndex = 0; colorIndex < colors.Length; colorIndex++)
    //        {

    //            // Step-1 : checking validity
    //            if (!canColorWith(colorIndex, vertex)) continue;  //Step-2 : Continue

    //            //Step-2 : coloring
    //            vertex.color = colors[colorIndex];
    //            vertex.IsColored = true;
    //            colorCount++;

    //            //Step-4 : Whether all vertices colored?
    //            if (colorCount == numberOfVertices) //Base Case
    //                return true;

    //            //Step-5 : Next uncolored vertex
    //            for (Edge edge:vertex.adjacentEdges)
    //            {
    //                if (!edge.targetVertex.colored)
    //                {

    //                    if (setColors(edge.targetVertex))
    //                        return true;
    //                }

    //            }
    //        }

    //        // Step-3 : Backtracking
    //        vertex.color = "";
    //        vertex.colored = false;
    //        return false;
    //    }

    //    //Function to check whether it is valid to color with color[colorIndex]
    //    private bool canColorWith(int colorIndex, Vertex vertex)
    //    {
    //        Vertex neighborVertex;
    //        for (Edge edge:vertex.adjacentEdges)
    //        {
    //            neighborVertex = edge.targetVertex;
    //            if (neighborVertex.colored && neighborVertex.color == colors[colorIndex])
    //                return false;
    //        }

    //        return true;
    //    }
    //}
}
