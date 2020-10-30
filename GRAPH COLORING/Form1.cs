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
                int y = panel_GraphGrid.Location.Y + (panel_GraphGrid.ClientSize.Height - Size.Height);
                Grid g = new Grid(panel_GraphGrid, panel_GraphGrid.Location.X, y);
                g.makeGridNoThreads(25, e);
            }
            isPaint = true;
        }
    }
}
