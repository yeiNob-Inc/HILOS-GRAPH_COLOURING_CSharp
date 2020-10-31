using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GRAPH_COLORING
{
    class Edge
    {
        Vertex startVertex;
        Vertex targetVertex;
        public Edge(Vertex startVertex, Vertex targetVertex)
        {
            this.startVertex = startVertex;
            this.targetVertex = targetVertex;
        }
    }
}
