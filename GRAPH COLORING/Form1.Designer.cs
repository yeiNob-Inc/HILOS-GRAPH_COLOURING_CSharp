﻿namespace GRAPH_COLORING
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
            System.Windows.Forms.Panel panel1;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label_EdgeList = new System.Windows.Forms.Label();
            this.panel_Buttons = new System.Windows.Forms.Panel();
            this.btn_CreateRandomGraph = new System.Windows.Forms.Button();
            this.btn_EraseGraph = new System.Windows.Forms.Button();
            this.btn_EraseVertex = new System.Windows.Forms.Button();
            this.btn_GraphColoring = new System.Windows.Forms.Button();
            this.btn_AddEdge = new System.Windows.Forms.Button();
            this.btn_AddVertex = new System.Windows.Forms.Button();
            this.panel_GraphGrid = new System.Windows.Forms.Panel();
            this.label_names = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_VertexX = new System.Windows.Forms.TextBox();
            this.textBox_VertexY = new System.Windows.Forms.TextBox();
            this.label_XY = new System.Windows.Forms.Label();
            this.textBox_EdgeV1X = new System.Windows.Forms.TextBox();
            this.textBox_EdgeV1Y = new System.Windows.Forms.TextBox();
            this.textBox_EdgeV2Y = new System.Windows.Forms.TextBox();
            this.textBox_EdgeV2X = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox_RandomGraph = new System.Windows.Forms.TextBox();
            this.label_RandomGraph = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label_ColorNumber = new System.Windows.Forms.Label();
            this.label_VertexNumber = new System.Windows.Forms.Label();
            this.label_EdgeNumber = new System.Windows.Forms.Label();
            panel1 = new System.Windows.Forms.Panel();
            panel1.SuspendLayout();
            this.panel_Buttons.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            resources.ApplyResources(panel1, "panel1");
            panel1.BackColor = System.Drawing.Color.SeaShell;
            panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            panel1.Controls.Add(this.label_EdgeList);
            panel1.Cursor = System.Windows.Forms.Cursors.IBeam;
            panel1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            panel1.Name = "panel1";
            // 
            // label_EdgeList
            // 
            resources.ApplyResources(this.label_EdgeList, "label_EdgeList");
            this.label_EdgeList.Name = "label_EdgeList";
            // 
            // panel_Buttons
            // 
            resources.ApplyResources(this.panel_Buttons, "panel_Buttons");
            this.panel_Buttons.Controls.Add(this.btn_CreateRandomGraph);
            this.panel_Buttons.Controls.Add(this.btn_EraseGraph);
            this.panel_Buttons.Controls.Add(this.btn_EraseVertex);
            this.panel_Buttons.Controls.Add(this.btn_GraphColoring);
            this.panel_Buttons.Controls.Add(this.btn_AddEdge);
            this.panel_Buttons.Controls.Add(this.btn_AddVertex);
            this.panel_Buttons.Name = "panel_Buttons";
            // 
            // btn_CreateRandomGraph
            // 
            resources.ApplyResources(this.btn_CreateRandomGraph, "btn_CreateRandomGraph");
            this.btn_CreateRandomGraph.Name = "btn_CreateRandomGraph";
            this.btn_CreateRandomGraph.UseVisualStyleBackColor = true;
            this.btn_CreateRandomGraph.Click += new System.EventHandler(this.btn_CreateRandomGraph_Click);
            // 
            // btn_EraseGraph
            // 
            resources.ApplyResources(this.btn_EraseGraph, "btn_EraseGraph");
            this.btn_EraseGraph.Name = "btn_EraseGraph";
            this.btn_EraseGraph.TabStop = false;
            this.btn_EraseGraph.Tag = "Button";
            this.btn_EraseGraph.UseVisualStyleBackColor = true;
            this.btn_EraseGraph.Click += new System.EventHandler(this.btn_EraseGraph_Click);
            // 
            // btn_EraseVertex
            // 
            resources.ApplyResources(this.btn_EraseVertex, "btn_EraseVertex");
            this.btn_EraseVertex.Name = "btn_EraseVertex";
            this.btn_EraseVertex.TabStop = false;
            this.btn_EraseVertex.Tag = "Button";
            this.btn_EraseVertex.UseVisualStyleBackColor = true;
            // 
            // btn_GraphColoring
            // 
            resources.ApplyResources(this.btn_GraphColoring, "btn_GraphColoring");
            this.btn_GraphColoring.Name = "btn_GraphColoring";
            this.btn_GraphColoring.Tag = "Button";
            this.btn_GraphColoring.UseVisualStyleBackColor = true;
            this.btn_GraphColoring.Click += new System.EventHandler(this.btn_GraphColoring_Click);
            // 
            // btn_AddEdge
            // 
            resources.ApplyResources(this.btn_AddEdge, "btn_AddEdge");
            this.btn_AddEdge.Name = "btn_AddEdge";
            this.btn_AddEdge.Tag = "Button";
            this.btn_AddEdge.UseVisualStyleBackColor = true;
            this.btn_AddEdge.Click += new System.EventHandler(this.btn_AddEdge_Click);
            // 
            // btn_AddVertex
            // 
            resources.ApplyResources(this.btn_AddVertex, "btn_AddVertex");
            this.btn_AddVertex.Name = "btn_AddVertex";
            this.btn_AddVertex.Tag = "Button";
            this.btn_AddVertex.UseVisualStyleBackColor = true;
            this.btn_AddVertex.Click += new System.EventHandler(this.btn_AddVertex_Click);
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
            // textBox_VertexX
            // 
            resources.ApplyResources(this.textBox_VertexX, "textBox_VertexX");
            this.textBox_VertexX.Name = "textBox_VertexX";
            this.textBox_VertexX.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_VertexXY_KeyDown);
            // 
            // textBox_VertexY
            // 
            resources.ApplyResources(this.textBox_VertexY, "textBox_VertexY");
            this.textBox_VertexY.Name = "textBox_VertexY";
            this.textBox_VertexY.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_VertexXY_KeyDown);
            // 
            // label_XY
            // 
            resources.ApplyResources(this.label_XY, "label_XY");
            this.label_XY.Name = "label_XY";
            // 
            // textBox_EdgeV1X
            // 
            resources.ApplyResources(this.textBox_EdgeV1X, "textBox_EdgeV1X");
            this.textBox_EdgeV1X.Name = "textBox_EdgeV1X";
            this.textBox_EdgeV1X.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_EdgeV1V2_KeyDown);
            // 
            // textBox_EdgeV1Y
            // 
            resources.ApplyResources(this.textBox_EdgeV1Y, "textBox_EdgeV1Y");
            this.textBox_EdgeV1Y.Name = "textBox_EdgeV1Y";
            this.textBox_EdgeV1Y.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_EdgeV1V2_KeyDown);
            // 
            // textBox_EdgeV2Y
            // 
            resources.ApplyResources(this.textBox_EdgeV2Y, "textBox_EdgeV2Y");
            this.textBox_EdgeV2Y.Name = "textBox_EdgeV2Y";
            this.textBox_EdgeV2Y.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_EdgeV1V2_KeyDown);
            // 
            // textBox_EdgeV2X
            // 
            resources.ApplyResources(this.textBox_EdgeV2X, "textBox_EdgeV2X");
            this.textBox_EdgeV2X.Name = "textBox_EdgeV2X";
            this.textBox_EdgeV2X.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_EdgeV1V2_KeyDown);
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // textBox_RandomGraph
            // 
            resources.ApplyResources(this.textBox_RandomGraph, "textBox_RandomGraph");
            this.textBox_RandomGraph.Name = "textBox_RandomGraph";
            this.textBox_RandomGraph.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_RandomGraph_KeyDown);
            // 
            // label_RandomGraph
            // 
            resources.ApplyResources(this.label_RandomGraph, "label_RandomGraph");
            this.label_RandomGraph.Name = "label_RandomGraph";
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // label_ColorNumber
            // 
            resources.ApplyResources(this.label_ColorNumber, "label_ColorNumber");
            this.label_ColorNumber.Name = "label_ColorNumber";
            // 
            // label_VertexNumber
            // 
            resources.ApplyResources(this.label_VertexNumber, "label_VertexNumber");
            this.label_VertexNumber.Name = "label_VertexNumber";
            // 
            // label_EdgeNumber
            // 
            resources.ApplyResources(this.label_EdgeNumber, "label_EdgeNumber");
            this.label_EdgeNumber.Name = "label_EdgeNumber";
            // 
            // Form1
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label_EdgeNumber);
            this.Controls.Add(this.label_VertexNumber);
            this.Controls.Add(this.label_ColorNumber);
            this.Controls.Add(this.textBox_RandomGraph);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label_RandomGraph);
            this.Controls.Add(panel1);
            this.Controls.Add(this.textBox_EdgeV2Y);
            this.Controls.Add(this.textBox_EdgeV2X);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label_XY);
            this.Controls.Add(this.textBox_EdgeV1Y);
            this.Controls.Add(this.textBox_VertexY);
            this.Controls.Add(this.textBox_EdgeV1X);
            this.Controls.Add(this.textBox_VertexX);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label_names);
            this.Controls.Add(this.panel_GraphGrid);
            this.Controls.Add(this.panel_Buttons);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.HelpButton = true;
            this.MaximizeBox = false;
            this.Name = "Form1";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
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
        public System.Windows.Forms.TextBox textBox_VertexX;
        public System.Windows.Forms.TextBox textBox_VertexY;
        private System.Windows.Forms.Label label_XY;
        public System.Windows.Forms.TextBox textBox_EdgeV1X;
        public System.Windows.Forms.TextBox textBox_EdgeV1Y;
        public System.Windows.Forms.TextBox textBox_EdgeV2Y;
        public System.Windows.Forms.TextBox textBox_EdgeV2X;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.Label label_EdgeList;
        private System.Windows.Forms.Button btn_CreateRandomGraph;
        public System.Windows.Forms.Label label_RandomGraph;
        private System.Windows.Forms.TextBox textBox_RandomGraph;
        public System.Windows.Forms.Label label6;
        public System.Windows.Forms.Label label_ColorNumber;
        public System.Windows.Forms.Label label_VertexNumber;
        public System.Windows.Forms.Label label7;
        public System.Windows.Forms.Label label_EdgeNumber;
    }
}

