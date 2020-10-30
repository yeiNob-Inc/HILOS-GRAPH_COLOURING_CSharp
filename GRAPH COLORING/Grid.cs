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
    class Grid
    {
        // Variables globales que guardarán los valores de la malla.
        int gridX, gridY, gridWidth, gridHeight;
        /// <summary>
        /// Constructor que recibe el cuadro en donde se dibujarán los nodos,
        ///     para así poder dibujar la malla repartiendo el trabajo entre varios hilos.
        /// </summary>
        /// <param name="gridForm"></param>
        public Grid(System.Windows.Forms.Panel gridForm, int gridPosX, int gridPosY)
        {
            // Establecemos los valores que utilizaremos.
            gridWidth = gridForm.ClientSize.Width;
            gridHeight = gridForm.ClientSize.Height;
            gridX = gridPosX;
            //gridY = gridPosY;
            gridY = 0;
            // $Grid: gridWidth = 498, gridWidth = 498, gridX = 50, gridY = 0
        }
        /// <summary>
        /// 
        /// Método que creará las líneas de la malla en el panel.
        /// Dividirá este proceso entre varios hilos.
        /// </summary>
        /// <param name="matrixTam"></param>
        /// El parámetro indicará el tamaño del que queremos la matriz nxn.
        public void makeGridNoThreads(int matrixTam, PaintEventArgs e)
        {
            int incrementX = gridWidth / matrixTam, incrementY = gridHeight / matrixTam;
            Pen color = new Pen(Color.Black);
            for(int i = 0, x = gridX, y = gridY; i < matrixTam; i++, x += incrementX)
            {
                e.Graphics.DrawLine(color, x, y, incrementX, y);
                for (int j = 0; j < matrixTam; j++, y += incrementY)
                {
                    //System.Drawing.Drawing2D.
                    e.Graphics.DrawLine(color, x, y, x, incrementY);
                }
            }
        }
    }
}
