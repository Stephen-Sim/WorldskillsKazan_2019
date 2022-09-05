namespace WindowsFormsApp1
{
    partial class Form1
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.purchaseOrderManagementToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.warehouseManagementToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.inventoryReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridViewInventory = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewLinkColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewLinkColumn();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewInventory)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.purchaseOrderManagementToolStripMenuItem,
            this.warehouseManagementToolStripMenuItem,
            this.inventoryReportToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1106, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // purchaseOrderManagementToolStripMenuItem
            // 
            this.purchaseOrderManagementToolStripMenuItem.Name = "purchaseOrderManagementToolStripMenuItem";
            this.purchaseOrderManagementToolStripMenuItem.Size = new System.Drawing.Size(174, 20);
            this.purchaseOrderManagementToolStripMenuItem.Text = "Purchase Order Management";
            // 
            // warehouseManagementToolStripMenuItem
            // 
            this.warehouseManagementToolStripMenuItem.Name = "warehouseManagementToolStripMenuItem";
            this.warehouseManagementToolStripMenuItem.Size = new System.Drawing.Size(152, 20);
            this.warehouseManagementToolStripMenuItem.Text = "Warehouse Management";
            // 
            // inventoryReportToolStripMenuItem
            // 
            this.inventoryReportToolStripMenuItem.Name = "inventoryReportToolStripMenuItem";
            this.inventoryReportToolStripMenuItem.Size = new System.Drawing.Size(107, 20);
            this.inventoryReportToolStripMenuItem.Text = "Inventory Report";
            this.inventoryReportToolStripMenuItem.Click += new System.EventHandler(this.inventoryReportToolStripMenuItem_Click);
            // 
            // dataGridViewInventory
            // 
            this.dataGridViewInventory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewInventory.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column3,
            this.Column2,
            this.Column4,
            this.Column10,
            this.Column5,
            this.Column6,
            this.Column7,
            this.Column8,
            this.Column9});
            this.dataGridViewInventory.Location = new System.Drawing.Point(12, 27);
            this.dataGridViewInventory.Name = "dataGridViewInventory";
            this.dataGridViewInventory.Size = new System.Drawing.Size(1082, 434);
            this.dataGridViewInventory.TabIndex = 1;
            this.dataGridViewInventory.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewInventory_CellClick);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "ItemOrderID";
            this.Column1.Name = "Column1";
            this.Column1.Visible = false;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "OrderID";
            this.Column3.Name = "Column3";
            this.Column3.Visible = false;
            // 
            // Column2
            // 
            this.Column2.HeaderText = " Part Name";
            this.Column2.Name = "Column2";
            this.Column2.Width = 120;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Transaction Type";
            this.Column4.Name = "Column4";
            this.Column4.Width = 180;
            // 
            // Column10
            // 
            this.Column10.HeaderText = "Date";
            this.Column10.Name = "Column10";
            this.Column10.Width = 120;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Amount";
            this.Column5.Name = "Column5";
            // 
            // Column6
            // 
            this.Column6.HeaderText = "Source";
            this.Column6.Name = "Column6";
            this.Column6.Width = 150;
            // 
            // Column7
            // 
            this.Column7.HeaderText = "Destination";
            this.Column7.Name = "Column7";
            this.Column7.Width = 150;
            // 
            // Column8
            // 
            this.Column8.HeaderText = "Action";
            this.Column8.Name = "Column8";
            // 
            // Column9
            // 
            this.Column9.HeaderText = "";
            this.Column9.Name = "Column9";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DodgerBlue;
            this.ClientSize = new System.Drawing.Size(1106, 473);
            this.Controls.Add(this.dataGridViewInventory);
            this.Controls.Add(this.menuStrip1);
            this.Name = "Form1";
            this.Text = "Inventory Management";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewInventory)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem purchaseOrderManagementToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem warehouseManagementToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem inventoryReportToolStripMenuItem;
        private System.Windows.Forms.DataGridView dataGridViewInventory;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewLinkColumn Column8;
        private System.Windows.Forms.DataGridViewLinkColumn Column9;
    }
}

