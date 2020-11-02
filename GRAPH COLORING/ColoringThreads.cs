using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using System.Dynamic;

namespace GRAPH_COLORING
{
    class ColoringThreads
    {
        // La lista de colores será compartida.
        List<Color> colors; // Lista de colores. Se pueden ir agregando más.
        Graph graph;
        int tIndex = 0, numberOfData; // Para saber en cuál hilo vamos.
        //static Barrier sync; // Para que no regrese al form sin haber terminado los hilos.
        // Uso del Graph Coloring con Hilos.
        // El procedimiento debe ser secuencial porque los de adelante deben saber los colores del de atrás.
        public ColoringThreads(Graph graph)
        {
            this.graph = graph;
            colors = new List<Color>();
        }
        public void GraphColoring()
        {
            Random r = new Random();
            // Agregamos dos colores para empezar.
            colors.Add(Color.FromArgb(r.Next(256), r.Next(256), r.Next(256)));
            colors.Add(Color.FromArgb(r.Next(256), r.Next(256), r.Next(256)));

            // Comenzamos el sync para luego esperar a que los hilos terminen.
            //sync = new Barrier(participantCount: graph.NumberOfVertices);

            Thread[] threads = new Thread[graph.NumberOfVertices]; // n hilos.
            //int numberOfThreads = 5;
            //Thread[] threads = new Thread[numberOfThreads];
            int threadIndex = 0;
            // El total de datos que le toca a cada uno.
            //numberOfData = graph.NumberOfVertices / numberOfThreads;
            int[] ijValues = new int[3]; // Los índices del nodo, el número del hilo.
            for (int i = 0; i < graph.graphMatrix.GetLength(0); i++)
                for (int j = 0; j < graph.graphMatrix.GetLength(1); j++)
                    // Colorea solo si existe y tiene alguna relación.
                    if (graph.graphMatrix[i, j] && graph.VertexSet[i, j].ConnectedVertex.Count > 0)
                    {
                        ijValues[0] = i;
                        ijValues[1] = j;
                        ijValues[2] = threadIndex;
                        threads[threadIndex] = new Thread(MakeThreads);
                        threads[threadIndex].IsBackground = true;
                        threads[threadIndex].Start(ijValues);
                        threadIndex++;
                        //while (!threads[threadIndex].IsAlive) ;// Para que se inicie el hilo y empiece.
                        Thread.Sleep(200);
                    }

            //sync.SignalAndWait(); // Espera a que todos terminen.
        }
        private void MakeThreads(object ijValues)
        {
            int[] ij = (int[])ijValues;
            // Exploramos el nodo actual.
            ExploreNode(ref graph.VertexSet[ij[0], ij[1]], ij[2]);
        }
        // Método que explorará un nodo y a sus conectados.
        private void ExploreNode(ref Vertex currentVertex, int threadIndex)
        {
            while (tIndex != threadIndex) ;
            tIndex = threadIndex;
            int colorIndex = 0;
            Random r = new Random();
            // Primero coloreamos al nodo que hizo la llamada.
            if ((!IsColoreable(currentVertex, colorIndex) && colorIndex < colors.Count)) {
                while ((!IsColoreable(currentVertex, colorIndex)
                                && colorIndex < colors.Count))
                    colorIndex++; // Si no es coloreable intentar con el siguiente índice.
                if(colorIndex == colors.Count)
                {
                    Color c = Color.FromArgb(r.Next(256), r.Next(256), r.Next(256));
                    while (c == Color.Transparent || c == Color.Empty) // Que no salgan colores transparentes.
                        c = Color.FromArgb(r.Next(256), r.Next(256), r.Next(256));
                    colors.Add(c);
                }
            }
            currentVertex.Color = colors.ElementAt(colorIndex);
            SetNeighborNotColorable(ref currentVertex, colorIndex);
            // Luego coloreamos a los demás nodos vecinos y ponemos a sus vecinos los colores que no pueden usar.
            for (int i = 0; i < currentVertex.ConnectedVertex.Count; i++)
            {
                // Si se encuentra con el mismo color, seguir buscando.
                if (!IsColoreable(currentVertex.ConnectedVertex.ElementAt(i), colorIndex))
                {
                    colorIndex = 0;
                    while (!IsColoreable(currentVertex.ConnectedVertex.ElementAt(i), colorIndex)
                            && colorIndex < colors.Count)
                        colorIndex++;
                    if (colorIndex == colors.Count)
                    {
                        Color c = Color.FromArgb(r.Next(256), r.Next(256), r.Next(256));
                        while (c == Color.Transparent || c == Color.Empty) // Que no salgan colores transparentes.
                            c = Color.FromArgb(r.Next(256), r.Next(256), r.Next(256));
                        colors.Add(c);
                    }
                }
                currentVertex.Color = colors.ElementAt(colorIndex);
                SetNeighborNotColorable(ref currentVertex, colorIndex);
            }
            tIndex++; // Aumentar el índice del hilo.
        }
        // Método que busca en la lista de colores que no se pueden usar en el vértice para ver si 
        //  el actual aparece ahí.
        private bool IsColoreable(Vertex v, int colorIndex)
        {
            for (int i = 0; i < v.NotColoreable.Count; i++)
                // De esta forma indicamos a ese vecino que ya no se puede colorear de ese color.
                if (v.NotColoreable.ElementAt(i) == colorIndex)
                    return false;
            return true; // Si no encontró el índice en los que no puede colorear, regresar que sí puede.
        }
        // Establecer a los vecinos que no pueden colorear con el color actual.
        private void SetNeighborNotColorable(ref Vertex v, int colorIndex)
        {
            // Recorremos a los vértices vecinos.
            for (int i = 0; i < v.ConnectedVertex.Count; i++)
                // De esta forma indicamos a ese vecino que ya no se puede colorear de ese color.
                v.ConnectedVertex.ElementAt(i).NotColoreable.Add(colorIndex);
        }
    }
}
