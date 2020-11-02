using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
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
        public void GraphColoring(Form1 form)
        {
            List<Color> colors = new List<Color>() ; // Lista de colores. Se pueden ir agregando más.
            Random r = new Random();
            // Agregamos un color para empezar.
            colors.Add(Color.FromArgb(r.Next(256), r.Next(256), r.Next(256)));

            int maxColors = -1;

            for (int i = 0; i < graph.graphMatrix.GetLength(0); i++)
                for (int j = 0, colorIndex = 0; j < graph.graphMatrix.GetLength(1); j++)
                    // Colorea solo si existe y tiene alguna relación.
                    if (graph.graphMatrix[i, j] && graph.VertexSet[i, j].ConnectedVertex.Count > 0) {// Si hay un edge entre ellos.
                        /* Buscamos si se puede colorear con el color actual,
                         * si no, reiniciamos el índice de color y lo intentamos.
                         * Si recorremos todos los colores, agreamos uno nuevo y lo coloreamos.**/
                        if (!IsColoreable(ref graph.VertexSet[i, j], colorIndex))
                        {
                            colorIndex = 0;
                            
                            /* Mientras que no se pueda colorear hasta que el índice llegue al límite de colores.*/
                            while (!IsColoreable(ref graph.VertexSet[i, j], colorIndex)
                                    && colorIndex < colors.Count) 
                            {
                                colorIndex++; // Aumentamos el índice de colores.
                                if (colorIndex > maxColors)
                                    maxColors = colorIndex;
                            }
                            /* 
                             * Si el índice supera el número de colores, agregar un nuevo color.
                             * En este punto el índice de color ya aumentó, por eso salió del while.**/
                            if (colorIndex == colors.Count)
                            {
                                Color c = Color.FromArgb(r.Next(256), r.Next(256), r.Next(256));
                                while (c == Color.Transparent || c == Color.Empty) // Que no salgan colores transparentes.
                                    c = Color.FromArgb(r.Next(256), r.Next(256), r.Next(256));
                                colors.Add(c);
                            }
                            // Si no se entró a la condición, significa que sí encontró un color
                            // con el cual colorearse.
                        }
                        // Si ya es coloreable, agregar el color del índice actual.
                        graph.VertexSet[i, j].Color = colors.ElementAt(colorIndex);
                        SetNeighborNotColorable(ref graph.VertexSet[i, j], colorIndex);
                    }
            // Se le suma 1 a maxColors porque el 0 también cuenta.
            form.label_ColorNumber.Text = "NÚMERO DE COLORES: "+ (maxColors + 1);
            form.label_ColorNumber.Refresh();
        }

        // Establecer a los vecinos que no pueden colorear con el color actual.
        private void SetNeighborNotColorable(ref Vertex v, int colorIndex)
        {
            // Recorremos a los vértices vecinos.
            for(int i = 0; i < v.ConnectedVertex.Count; i++)
                // De esta forma indicamos a ese vecino que ya no se puede colorear de ese color.
                v.ConnectedVertex.ElementAt(i).NotColoreable.Add(colorIndex);
        }
        // Método que revisa si el colorIndex actual lo puede colorear o no.
        private bool IsColoreable(ref Vertex v, int colorIndex)
        {
            for (int i = 0; i < v.NotColoreable.Count; i++)
                // De esta forma indicamos a ese vecino que ya no se puede colorear de ese color.
                if (v.NotColoreable.ElementAt(i) == colorIndex)
                    return false;
            return true; // Si no encontró el índice en los que no puede colorear, regresar que sí puede.
        }
    }
}
