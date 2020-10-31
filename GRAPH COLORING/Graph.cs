using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * CLASE PARA MANEJAR A LOS GRAFOS Y SUS MÉTODOS.
 * **/

namespace GRAPH_COLORING
{
    class Graph
    {
        // Matriz de adyacencia.
        bool[,] adjacencyMatrix;
        int graphSize;
        // Tomemos en cuenta que el grafo será de nxn.
        public Graph(int graphSize)
        {
            this.graphSize = graphSize;
            adjacencyMatrix = new bool[graphSize, graphSize];
            initializeAdjMatrix(ref adjacencyMatrix);
        }
        // Método que agrega un vértice.
        public void addVertex(int v1, int v2){

        }
        // Método que inicializa la mariz de adyacencia.
        private void initializeAdjMatrix(ref bool[,] adjacencyMatrix)
        {
            for (int i = 0; i < adjacencyMatrix.Length; i++)
                for(int j = 0; j < adjacencyMatrix.Length; j++)
                    adjacencyMatrix[i, j] = false;
        }
    }
}
