namespace Lab2.UI
{
    partial class InputForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.graph = new Microsoft.Web.WebView2.WinForms.WebView2();
            this.loadButton = new System.Windows.Forms.Button();
            this.calculateButton = new System.Windows.Forms.Button();
            this.inputGrid = new System.Windows.Forms.DataGridView();
            this.X = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Y = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.outputGrid = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.resultLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.graph)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.inputGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.outputGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // graph
            // 
            this.graph.AllowExternalDrop = true;
            this.graph.CreationProperties = null;
            this.graph.DefaultBackgroundColor = System.Drawing.Color.White;
            this.graph.Location = new System.Drawing.Point(170, 11);
            this.graph.Margin = new System.Windows.Forms.Padding(2);
            this.graph.Name = "graph";
            this.graph.Size = new System.Drawing.Size(364, 281);
            this.graph.TabIndex = 16;
            this.graph.ZoomFactor = 1D;
            // 
            // loadButton
            // 
            this.loadButton.Location = new System.Drawing.Point(2, 272);
            this.loadButton.Name = "loadButton";
            this.loadButton.Size = new System.Drawing.Size(163, 20);
            this.loadButton.TabIndex = 36;
            this.loadButton.Text = "Загрузить";
            this.loadButton.UseVisualStyleBackColor = true;
            this.loadButton.Click += new System.EventHandler(this.loadButton_Click);
            // 
            // calculateButton
            // 
            this.calculateButton.Enabled = false;
            this.calculateButton.Location = new System.Drawing.Point(539, 272);
            this.calculateButton.Name = "calculateButton";
            this.calculateButton.Size = new System.Drawing.Size(163, 20);
            this.calculateButton.TabIndex = 37;
            this.calculateButton.Text = "Вычислить";
            this.calculateButton.UseVisualStyleBackColor = true;
            this.calculateButton.Click += new System.EventHandler(this.calculateButton_Click);
            // 
            // inputGrid
            // 
            this.inputGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.inputGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.X,
            this.Y});
            this.inputGrid.Location = new System.Drawing.Point(2, 11);
            this.inputGrid.Name = "inputGrid";
            this.inputGrid.Size = new System.Drawing.Size(163, 255);
            this.inputGrid.TabIndex = 38;
            this.inputGrid.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.inputGrid_CellEndEdit);
            this.inputGrid.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.inputGrid_CellValueChanged);
            this.inputGrid.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.inputGrid_RowsAdded);
            this.inputGrid.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.inputGrid_RowsRemoved);
            this.inputGrid.UserAddedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.inputGrid_UserAddedRow);
            this.inputGrid.UserDeletedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.inputGrid_UserDeletedRow);
            // 
            // X
            // 
            this.X.Frozen = true;
            this.X.HeaderText = "X";
            this.X.Name = "X";
            this.X.Width = 50;
            // 
            // Y
            // 
            this.Y.Frozen = true;
            this.Y.HeaderText = "Y";
            this.Y.Name = "Y";
            this.Y.Width = 50;
            // 
            // outputGrid
            // 
            this.outputGrid.AllowUserToAddRows = false;
            this.outputGrid.AllowUserToDeleteRows = false;
            this.outputGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.outputGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2});
            this.outputGrid.Location = new System.Drawing.Point(539, 11);
            this.outputGrid.Name = "outputGrid";
            this.outputGrid.ReadOnly = true;
            this.outputGrid.Size = new System.Drawing.Size(163, 255);
            this.outputGrid.TabIndex = 39;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.Frozen = true;
            this.dataGridViewTextBoxColumn1.HeaderText = "φ";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 50;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.Frozen = true;
            this.dataGridViewTextBoxColumn2.HeaderText = "ε";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 50;
            // 
            // resultLabel
            // 
            this.resultLabel.Location = new System.Drawing.Point(-1, 294);
            this.resultLabel.Name = "resultLabel";
            this.resultLabel.Size = new System.Drawing.Size(703, 172);
            this.resultLabel.TabIndex = 40;
            this.resultLabel.Text = "Результат:\r\nВычисления не проводились\r\n";
            // 
            // InputForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(709, 475);
            this.Controls.Add(this.resultLabel);
            this.Controls.Add(this.outputGrid);
            this.Controls.Add(this.inputGrid);
            this.Controls.Add(this.calculateButton);
            this.Controls.Add(this.loadButton);
            this.Controls.Add(this.graph);
            this.Name = "InputForm";
            this.Text = "Лабораторная работа №3";
            this.Load += new System.EventHandler(this.InputForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.graph)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.inputGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.outputGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Web.WebView2.WinForms.WebView2 graph;
        private System.Windows.Forms.Button loadButton;
        private System.Windows.Forms.Button calculateButton;
        private System.Windows.Forms.DataGridView inputGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn X;
        private System.Windows.Forms.DataGridViewTextBoxColumn Y;
        private System.Windows.Forms.DataGridView outputGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.Label resultLabel;
    }
}