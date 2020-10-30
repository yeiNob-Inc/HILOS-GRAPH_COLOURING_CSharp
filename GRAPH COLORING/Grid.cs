using System.Drawing;
using System.Windows.Forms;
using System.Threading;
using System;

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
        int cellSize, numCells; // El número de celdas también será global.
        PaintEventArgs e; // Con el que se hará el dibujado.

        /*
         * Utilizamos un DELEGATE para poder pasar el método como parámetro.**/
        // private delegate void DivideGridThreads(object _startFinalIterator);

        public Grid(int numCells)
        {
            this.numCells = numCells;
        }

        public void MakeGridThreads(System.Windows.Forms.Panel grid, PaintEventArgs e, int numThreads)
        {
            Thread[] threads = new Thread[numThreads]; // Definimos el arreglo de hilos.
            this.e = e; // Asignamos el evento.
            // Definimos el tamaño de la celda compartido por los hilos.
            cellSize = grid.Size.Width / numCells;

            createThreads(ref threads, numThreads);
        }
        /// <summary>
        /// MÉTODO QUE CREA LOS n HILOS CON EL MÉTODO QUE SE PASE COMO PARÁMETRO
        ///     Y EL ARGUMENTO QUE SE PASE COMO PARÁMETRO PARA LA FUNCIÓN QUE CORRA
        ///     LOS HILOS.
        /// </summary>
        /// <param name="threads"></param>
        ///     Arreglo de hilos, en donde se crearán y correrán.
        ///     Pasan por referencia, por eso la palabra reservada "ref".
        /// <param name="numThreads"></param>
        ///     Número de hilos a crear.
        /// <param name="method"></param>
        ///     Nombre del método a correr en los hilos.
        ///     Es del tipo System.Threading.ThreadStart porque es el parámetro
        ///         que admite el constructor.
        /// <param name="threadMethodParams"></param>
        ///     Son los parámetros con los que correrán los métodos.
        ///     Esto tomando en consideración que se corren de la siguiente manera:
        ///         threads[i] = new Thread(Método a correr);
        ///         threads[i].Start(Parámetros de la función);
        private void createThreads(ref Thread[] threads, int numThreads)
        {
            // Este arreglo que se pasará como parámetro es provisional. Buscaré una mejor forma de implementarlo.
            int[] StartFinalIterator = new int[2];
            int actualIterator = 0; // Para guardarlo y pasarlo como parámetro.
            int incrementIterator = numCells / numThreads; // La porción de líneas que le tocará a cada hilo
            for (int i = 0; i < numThreads; i++)
            {
                StartFinalIterator[0] = actualIterator;// Iterador inicial
                actualIterator += incrementIterator; // Le sumamos el incremento.
                StartFinalIterator[1] = actualIterator;// Iterador Final

                threads[i] = new Thread(DivideGridThreads); // Método de los hilos.
                threads[i].Start(StartFinalIterator); // Parámetros del método.
            }
            // RunThreads(ref threads, StartFinalIterator);
        }
        
        private void RunThreads(ref Thread[] threads, object threadMethodParams)
        {
            for (int i = 0; i < threads.Length; i++)
            {
                threads[i].Start(threadMethodParams); // Parámetros del método.
            }
        }
        
        /// <summary>
        /// MÉTODO QUE DIVIDE EL PINTAR LAS MATRICES TOMANDO EN CUENTA EL
        ///     VALOR INICIAL DEL ITERADOR, Y EL VALOR FINAL.
        ///     Estos valores dependen de en cuántos hilos se divida el proceso.
        ///     
        /// El parámetro recibirá un arreglo con los dos valores, pero solo así se pueden mandar
        ///     parámetros en funciones con hilos.
        ///     
        /// Thread t = new Thread(DivideGridThreads);
        /// t.Start(parámetro: int[] valoresIteradores);
        /// 
        /// numCells, cellSize, y e (para dibujar las líneas) son globales.
        /// 
        /// </summary>
        /// <param name="startIteratorFinalIterator"></param>
        private void DivideGridThreads(object _startFinalIterator)
        {
            // startIteratorFinalIterator[0] = Iterador inicial.
            // startIteratorFinalIterator[1] = Máximo iterador.
            Pen color = new Pen(Color.Black);
            int x, y, finalCoord = numCells * cellSize;
            // Recibimos un arreglo de enteros como parámetro. Aquí lo convertimos.
            int[] startFinalIterator = (int[])_startFinalIterator;
            // Se hace un cast a int del parámetro, ya que solo podemos recibir 
            //      de tipo Object (del cuál heredan todas las clases), y aquí dentro
            //      podemos ser explícitos con el tipo de parámetro que es.

            // Usar una copia del que va a dibujar para que no se intente ocupar por todos a la vez.
            Graphics paint = e.Graphics;
            for (int i = (int)startFinalIterator[0]; i < (int)startFinalIterator[1]; i++)
            {
                x = y = i * cellSize;

                /* e.Graphics.DrawLine(color, x1, y1, 2, y2); */

                // Las líneas de y van del 0 en y hasta el máximo, que es el número de celdas por su tamaño.
                // Las x no cambian por imprimir en y.
                //paint.DrawLine(color, x, 0, x, finalCoord);
                //// Lo mismo pasa con las líneas en x. La y no cambia, pero las x van del 0 al xFinal.
                //paint.DrawLine(color, 0, y, finalCoord, y);
            }
        }


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
