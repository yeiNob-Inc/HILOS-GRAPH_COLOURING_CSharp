using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GRAPH_COLORING
{
    public partial class Form1 : Form
    {
        bool isPaint = false; // Bool que verificará si se pintó o no la malla.
        public Form1()
        {
            InitializeComponent();
        }

        private void panel_GraphGrid_Paint(object sender, PaintEventArgs e)
        {
            if (!isPaint)
            {
                //int x = panel_GraphGrid.Location.X + ClientSize.Width - Size.Width;
                //int y = panel_GraphGrid.Location.Y + (panel_GraphGrid.ClientSize.Height - Size.Height);
                //Grid g = new Grid(panel_GraphGrid, panel_GraphGrid.Location.X, y);
                //g.makeGridNoThreads(25, e);
                Pen color = new Pen(Color.Black);
                int cellSize = 500 / 25, numCells = 25, x, y, finalCoord = numCells * cellSize;
                // finalCoord es la última coordenada, el último punto de la línea.
                for(int i = 0; i < numCells; i++)
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
            isPaint = true;
        }
    }
}
