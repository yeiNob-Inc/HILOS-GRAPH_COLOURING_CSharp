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
        bool[,] adjacencyMatrix, vertexMatrix;
        int graphSize;
        // Tomemos en cuenta que el grafo será de nxn.
        public Graph(int graphSize)
        {
            vertexSet = new List<Vertex>();
            adjacencyMatrix = new bool[graphSize, graphSize];
            vertexMatrix = new bool[graphSize, graphSize];
            this.graphSize = graphSize;
            adjacencyMatrix = new bool[graphSize, graphSize];
            InitializeMatrix(ref adjacencyMatrix);
            InitializeMatrix(ref vertexMatrix);
            //vertexSet.Add(new Vertex(System.Drawing.Color.Beige, 3, 4));
            //vertexSet.Add(new Vertex(System.Drawing.Color.Red, 1, 2));
        }
        
        // Método que agrega un vértice.
        public void AddVertex(int v1, int v2){
            // Que el vértice esté dentro del rango y no exista aún.
            if (v1 > 0 && v1 <= graphSize && v2 > 0 && v2 <= graphSize && !vertexMatrix[v1 - 1, v2 - 1])
            {
                vertexSet.Add(new Vertex(System.Drawing.Color.Black, v1 - 1, v2 - 1));
                vertexMatrix[v1 - 1, v2 - 1] = true;
            }
        }
        // Método que imprime todos los vértices.
        public void DrawAllVertex(PaintEventArgs e)
        {
            for (int i = 0; i < vertexSet.Count; i++)
                vertexSet.ElementAt(i).DrawVertex(e);
        }

        // Método que inicializa la mariz de adyacencia.
        private void InitializeMatrix(ref bool[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
                for(int j = 0; j < matrix.GetLength(1); j++)
                    matrix[i, j] = false;
        }
    }
}
