namespace GRAPH_COLORING
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.panel_Buttons = new System.Windows.Forms.Panel();
            this.btn_EraseGraph = new System.Windows.Forms.Button();
            this.btn_EraseVertex = new System.Windows.Forms.Button();
            this.btn_GraphColoring = new System.Windows.Forms.Button();
            this.btn_AddEdge = new System.Windows.Forms.Button();
            this.btn_AddVertex = new System.Windows.Forms.Button();
            this.panel_GraphGrid = new System.Windows.Forms.Panel();
            this.label_names = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel_Buttons.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel_Buttons
            // 
            resources.ApplyResources(this.panel_Buttons, "panel_Buttons");
            this.panel_Buttons.Controls.Add(this.btn_EraseGraph);
            this.panel_Buttons.Controls.Add(this.btn_EraseVertex);
            this.panel_Buttons.Controls.Add(this.btn_GraphColoring);
            this.panel_Buttons.Controls.Add(this.btn_AddEdge);
            this.panel_Buttons.Controls.Add(this.btn_AddVertex);
            this.panel_Buttons.Name = "panel_Buttons";
            // 
            // btn_EraseGraph
            // 
            resources.ApplyResources(this.btn_EraseGraph, "btn_EraseGraph");
            this.btn_EraseGraph.Name = "btn_EraseGraph";
            this.btn_EraseGraph.Tag = "Button";
            this.btn_EraseGraph.UseVisualStyleBackColor = true;
            // 
            // btn_EraseVertex
            // 
            resources.ApplyResources(this.btn_EraseVertex, "btn_EraseVertex");
            this.btn_EraseVertex.Name = "btn_EraseVertex";
            this.btn_EraseVertex.Tag = "Button";
            this.btn_EraseVertex.UseVisualStyleBackColor = true;
            // 
            // btn_GraphColoring
            // 
            resources.ApplyResources(this.btn_GraphColoring, "btn_GraphColoring");
            this.btn_GraphColoring.Name = "btn_GraphColoring";
            this.btn_GraphColoring.Tag = "Button";
            this.btn_GraphColoring.UseVisualStyleBackColor = true;
            // 
            // btn_AddEdge
            // 
            resources.ApplyResources(this.btn_AddEdge, "btn_AddEdge");
            this.btn_AddEdge.Name = "btn_AddEdge";
            this.btn_AddEdge.Tag = "Button";
            this.btn_AddEdge.UseVisualStyleBackColor = true;
            // 
            // btn_AddVertex
            // 
            resources.ApplyResources(this.btn_AddVertex, "btn_AddVertex");
            this.btn_AddVertex.Name = "btn_AddVertex";
            this.btn_AddVertex.Tag = "Button";
            this.btn_AddVertex.UseVisualStyleBackColor = true;
            // 
            // panel_GraphGrid
            // 
            resources.ApplyResources(this.panel_GraphGrid, "panel_GraphGrid");
            this.panel_GraphGrid.BackColor = System.Drawing.Color.MistyRose;
            this.panel_GraphGrid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_GraphGrid.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panel_GraphGrid.Name = "panel_GraphGrid";
            this.panel_GraphGrid.Tag = "GraphElements";
            this.panel_GraphGrid.Paint += new System.Windows.Forms.PaintEventHandler(this.panel_GraphGrid_Paint);
            // 
            // label_names
            // 
            resources.ApplyResources(this.label_names, "label_names");
            this.label_names.BackColor = System.Drawing.Color.SeaShell;
            this.label_names.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label_names.Cursor = System.Windows.Forms.Cursors.No;
            this.label_names.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label_names.Name = "label_names";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.BackColor = System.Drawing.Color.SeaShell;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Cursor = System.Windows.Forms.Cursors.No;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label1.Name = "label1";
            // 
            // Form1
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label_names);
            this.Controls.Add(this.panel_GraphGrid);
            this.Controls.Add(this.panel_Buttons);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.HelpButton = true;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.panel_Buttons.ResumeLayout(false);
            this.panel_Buttons.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btn_AddVertex;
        private System.Windows.Forms.Button btn_EraseGraph;
        private System.Windows.Forms.Button btn_EraseVertex;
        private System.Windows.Forms.Button btn_GraphColoring;
        private System.Windows.Forms.Button btn_AddEdge;
        public System.Windows.Forms.Panel panel_Buttons;
        private System.Windows.Forms.Panel panel_GraphGrid;
        private System.Windows.Forms.Label label_names;
        private System.Windows.Forms.Label label1;
    }
}

