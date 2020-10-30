using System.Drawing;
using System.Windows.Forms;

/*
 * CLASE QUE MANEJARÁ LA MALLA EN DONDE SE DIBUJARÁN LOS NODOS DEL GRAFO.
 * LA CLASE SERÁ ESTÁTICA (static) PORQUE NO REQUERIMOS SU INSTANCIA,
 *  SOLO SUS MÉTODOS.
 *  
 *  De acuerdo a GeeksforGeeks: https://www.geeksforgeeks.org/c-sharp-static-class/#:~:text=In%20C%23%2C%20one%20is%20allowed,static%20class%20from%20another%20class.
 *  A static class can only contain static data members, static methods, and a static constructor.It is not allowed to create objects of the static class. Static classes are sealed, means you cannot inherit a static class from another class.
 * **/

namespace GRAPH_COLORING
{
    static class Grid
    {
        // Variables globales que guardarán los valores de la malla.
        // static int gridX, gridY, gridWidth, gridHeight;



        /// <summary>
        /// 
        /// Método que creará las líneas de la malla en el panel.
        /// Dividirá este proceso entre varios hilos.
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="grid"></param>
        /// <param name="numCells"></param>
        public static void MakeGridNoThreads(PaintEventArgs e, System.Windows.Forms.Panel grid, int numCells)
        {
            Pen color = new Pen(Color.Black);
            int cellSize = grid.Size.Width / numCells, x, y, finalCoord = numCells * cellSize;
            // finalCoord es la última coordenada, el último punto de la línea.
            for (int i = 0; i < numCells; i++)
            {
                x = y = i * cellSize;

                /* e.Graphics.DrawLine(color, x1, y1, 2, y2); */

                // Las líneas de y van del 0 en y hasta el máximo, que es el número de celdas por su tamaño.
                // Las x no cambian por imprimir en y.
                e.Graphics.DrawLine(color, x, 0, x, finalCoord);
                // Lo mismo pasa con las líneas en x. La y no cambia, pero las x van del 0 al xFinal.
                e.Graphics.DrawLine(color, 0, y, finalCoord, y);
            }
        }
    }
}
