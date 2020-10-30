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
            Grid.MakeGridNoThreads(e, panel_GraphGrid, 5);
        }
    }
}
