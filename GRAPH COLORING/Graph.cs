using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/*
 * CLASE PARA MANEJAR A LOS GRAFOS Y SUS MÉTODOS.
 * **/

namespace GRAPH_COLORING
{
    class Graph
    {
        List<Vertex> vertexSet;
        // Matriz de adyacencia.
        bool[,] adjacencyMatrix;
        int graphSize;
        // Tomemos en cuenta que el grafo será de nxn.
        public Graph(int graphSize)
        {
            vertexSet = new List<Vertex>();
            this.graphSize = graphSize;
            adjacencyMatrix = new bool[graphSize, graphSize];
            //InitializeAdjMatrix(ref adjacencyMatrix);
            vertexSet.Add(new Vertex(System.Drawing.Color.Beige, 3, 4));
            vertexSet.Add(new Vertex(System.Drawing.Color.Red, 1, 2));
            vertexSet.Add(new Vertex(System.Drawing.Color.BlanchedAlmond, 1, 3));
        }
        // Método que imprime todos los vértices.
        public void DrawAllVertex(PaintEventArgs e)
        {
            for (int i = 0; i < vertexSet.Count; i++)
                vertexSet.ElementAt(i).DrawVertex(e);
        }

        // Método que agrega un vértice.
        public void addVertex(int v1, int v2){

        }
        // Método que inicializa la mariz de adyacencia.
        private void InitializeAdjMatrix(ref bool[,] adjacencyMatrix)
        {
            for (int i = 0; i < adjacencyMatrix.Length; i++)
                for(int j = 0; j < adjacencyMatrix.Length; j++)
                    adjacencyMatrix[i, j] = false;
        }
    }
}
