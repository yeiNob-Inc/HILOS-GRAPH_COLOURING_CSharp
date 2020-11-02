using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

/*
 * CLASE PARA MANEJAR A LOS GRAFOS Y SUS MÉTODOS.
 * **/

namespace GRAPH_COLORING
{
    class Graph
    {
        // Lista de vèrtices para imprimirlos.
        List<Vertex> vertexPrintable;
        Vertex[,] vertexSet;
        List<Edge> edgeSet;
        // Matriz en donde un elemento guardará el vértice con el que se relaciona y viceversa.
        //Edge[,] edgeSet/*;*/
        // Matriz de adyacencia.
        //bool[,] adjacencyMatrix, vertexMatrix;
        bool[,] vertexMatrix; // Si hay vértice o no.
        int graphSize;
        // Tomemos en cuenta que el grafo será de nxn.
        public Graph()
        {
            graphSize = Grid.NumCells;
            //vertexSet = new List<Vertex>();
            edgeSet = new List<Edge>();
            vertexPrintable = new List<Vertex>();
            //edgeSet = new Edge[graphSize, graphSize];

            vertexSet = new Vertex[graphSize, graphSize];
            //adjacencyMatrix = new bool[graphSize, graphSize];
            vertexMatrix = new bool[graphSize, graphSize];
            //this.graphSize = graphSize;
            //adjacencyMatrix = new bool[graphSize, graphSize];
            //InitializeMatrix(ref adjacencyMatrix);
            InitializeMatrix(ref vertexMatrix);
            //vertexSet.Add(new Vertex(System.Drawing.Color.Beige, 3, 4));
            //vertexSet.Add(new Vertex(System.Drawing.Color.Red, 1, 2));
        }
        
        // Método que agrega un vértice.
        public void AddVertex(int v1, int v2){
            // Que el vértice esté dentro del rango y no exista aún.
            if (v1 >= 0 && v1 < graphSize && v2 >= 0 && v2 < graphSize && !vertexMatrix[v1, v2])
            {
                vertexPrintable.Add(new Vertex(System.Drawing.Color.Black, v1, v2));
                vertexSet[v1, v2] = new Vertex(System.Drawing.Color.Black, v1, v2);
                vertexMatrix[v1, v2] = true;
            }
        }

        public void AddEdge(int startVX, int startVY, int targetVX, int targetVY, Label label_EdgeList)
        {
            Edge e = new Edge(vertexSet[startVX, startVY], vertexSet[targetVX, targetVY]);
            // Si se intenta hacer relaciones con vértices no existentes no deja.
            // Si existen los vértices a relacionar, hacer el proceso.
            if (vertexMatrix[startVX, startVY] && vertexMatrix[targetVX, targetVY]
                && !EdgeExist(e))
            {
                edgeSet.Add(e);
                // Agregamos el último elemento como vecino.
                vertexSet[startVX, startVY].addNeighbor(edgeSet.ElementAt(edgeSet.Count - 1));

                // Hacer el proceso anterior para ser bidireccional
                // edgeSet.Add(new Edge(vertexSet[targetVX - 1, targetVY - 1], vertexSet[startVX - 1, startVY - 1]));
                vertexSet[targetVX, targetVY].addNeighbor(new Edge(vertexSet[targetVX, targetVY], vertexSet[startVX, startVY]));

                edgeSet.ElementAt(edgeSet.Count - 1).WriteEdge(label_EdgeList);
            }

        }
        // Método que dibujará todo el grafo: Vértices y relaciones (aristas).
        public void DrawGraph(PaintEventArgs e)
        {
            // Dibuja los aristas abajo de los vértices para que no se vean por encima de todo.

            DrawAllEdges(e);
            DrawAllVertex(e);
        }
        // Método que imprime todos los vértices.
        public void DrawAllVertex(PaintEventArgs e)
        {
            for (int i = 0; i < vertexPrintable.Count; i++)
                vertexPrintable.ElementAt(i).DrawVertex(e);
        }
        
        public void DrawAllEdges(PaintEventArgs e)
        {
            for (int i = 0; i < edgeSet.Count; i++)
                edgeSet.ElementAt(i).DrawEdge(e);
        }
        // Método para ver si los Edges que se quieren meter ya existen.
        private bool EdgeExist(Edge edge)
        {
            // Si la lista sí tiene elementos (Edges)
            if(edgeSet.Count > 0)
                // Recorrer toda la lista y buscar si ya existe ese Edge.
                for(int i = 0; i < edgeSet.Count; i++)
                    if ((edgeSet.ElementAt(i).startVertex == edge.startVertex
                            || edgeSet.ElementAt(i).startVertex == edge.targetVertex)
                            && (edgeSet.ElementAt(i).targetVertex == edge.startVertex
                            || edgeSet.ElementAt(i).targetVertex == edge.targetVertex))
                        return true; // True si se encontró.
            return false; // False si no se salió en la condición anterior (no encontró nada).
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
