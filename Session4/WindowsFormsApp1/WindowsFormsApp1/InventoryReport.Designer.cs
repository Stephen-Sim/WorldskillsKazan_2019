namespace WindowsFormsApp1
{
    partial class InventoryReport
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxWarehouse = new System.Windows.Forms.ComboBox();
            this.warehousesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.wSC2019_Session4DataSet = new WindowsFormsApp1.WSC2019_Session4DataSet();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButtonOutOfStock = new System.Windows.Forms.RadioButton();
            this.radioButtonReceivedStock = new System.Windows.Forms.RadioButton();
            this.radioButtonCurrentStock = new System.Windows.Forms.RadioButton();
            this.dataGridViewPartList = new System.Windows.Forms.DataGridView();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewLinkColumn();
            this.warehousesTableAdapter = new WindowsFormsApp1.WSC2019_Session4DataSetTableAdapters.WarehousesTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.warehousesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.wSC2019_Session4DataSet)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPartList)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Warehouse:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 97);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Result:";
            // 
            // comboBoxWarehouse
            // 
            this.comboBoxWarehouse.DataSource = this.warehousesBindingSource;
            this.comboBoxWarehouse.DisplayMember = "Name";
            this.comboBoxWarehouse.FormattingEnabled = true;
            this.comboBoxWarehouse.Location = new System.Drawing.Point(12, 36);
            this.comboBoxWarehouse.Name = "comboBoxWarehouse";
            this.comboBoxWarehouse.Size = new System.Drawing.Size(206, 21);
            this.comboBoxWarehouse.TabIndex = 2;
            this.comboBoxWarehouse.ValueMember = "ID";
            this.comboBoxWarehouse.SelectedIndexChanged += new System.EventHandler(this.comboBoxWarehouse_SelectedIndexChanged);
            // 
            // warehousesBindingSource
            // 
            this.warehousesBindingSource.DataMember = "Warehouses";
            this.warehousesBindingSource.DataSource = this.wSC2019_Session4DataSet;
            // 
            // wSC2019_Session4DataSet
            // 
            this.wSC2019_Session4DataSet.DataSetName = "WSC2019_Session4DataSet";
            this.wSC2019_Session4DataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButtonOutOfStock);
            this.groupBox1.Controls.Add(this.radioButtonReceivedStock);
            this.groupBox1.Controls.Add(this.radioButtonCurrentStock);
            this.groupBox1.Location = new System.Drawing.Point(248, 20);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(544, 61);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Inventory Type";
            // 
            // radioButtonOutOfStock
            // 
            this.radioButtonOutOfStock.AutoSize = true;
            this.radioButtonOutOfStock.Location = new System.Drawing.Point(362, 29);
            this.radioButtonOutOfStock.Name = "radioButtonOutOfStock";
            this.radioButtonOutOfStock.Size = new System.Drawing.Size(85, 17);
            this.radioButtonOutOfStock.TabIndex = 2;
            this.radioButtonOutOfStock.TabStop = true;
            this.radioButtonOutOfStock.Text = "Out of Stock";
            this.radioButtonOutOfStock.UseVisualStyleBackColor = true;
            this.radioButtonOutOfStock.CheckedChanged += new System.EventHandler(this.radioButton3_CheckedChanged);
            // 
            // radioButtonReceivedStock
            // 
            this.radioButtonReceivedStock.AutoSize = true;
            this.radioButtonReceivedStock.Location = new System.Drawing.Point(181, 29);
            this.radioButtonReceivedStock.Name = "radioButtonReceivedStock";
            this.radioButtonReceivedStock.Size = new System.Drawing.Size(102, 17);
            this.radioButtonReceivedStock.TabIndex = 1;
            this.radioButtonReceivedStock.TabStop = true;
            this.radioButtonReceivedStock.Text = "Received Stock";
            this.radioButtonReceivedStock.UseVisualStyleBackColor = true;
            this.radioButtonReceivedStock.CheckedChanged += new System.EventHandler(this.radioButtonReceivedStock_CheckedChanged);
            // 
            // radioButtonCurrentStock
            // 
            this.radioButtonCurrentStock.AutoSize = true;
            this.radioButtonCurrentStock.Location = new System.Drawing.Point(20, 29);
            this.radioButtonCurrentStock.Name = "radioButtonCurrentStock";
            this.radioButtonCurrentStock.Size = new System.Drawing.Size(90, 17);
            this.radioButtonCurrentStock.TabIndex = 0;
            this.radioButtonCurrentStock.TabStop = true;
            this.radioButtonCurrentStock.Text = "Current Stock";
            this.radioButtonCurrentStock.UseVisualStyleBackColor = true;
            this.radioButtonCurrentStock.CheckedChanged += new System.EventHandler(this.radioButtonCurrentStock_CheckedChanged);
            // 
            // dataGridViewPartList
            // 
            this.dataGridViewPartList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewPartList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column5,
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4});
            this.dataGridViewPartList.Location = new System.Drawing.Point(12, 113);
            this.dataGridViewPartList.Name = "dataGridViewPartList";
            this.dataGridViewPartList.Size = new System.Drawing.Size(780, 248);
            this.dataGridViewPartList.TabIndex = 3;
            this.dataGridViewPartList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewPartList_CellClick);
            // 
            // Column5
            // 
            this.Column5.HeaderText = "ID";
            this.Column5.Name = "Column5";
            this.Column5.Visible = false;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Part Name";
            this.Column1.Name = "Column1";
            this.Column1.Width = 180;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Current Stock";
            this.Column2.Name = "Column2";
            this.Column2.Width = 180;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Received Stock";
            this.Column3.Name = "Column3";
            this.Column3.Width = 180;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Action";
            this.Column4.Name = "Column4";
            this.Column4.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Column4.Width = 180;
            // 
            // warehousesTableAdapter
            // 
            this.warehousesTableAdapter.ClearBeforeFill = true;
            // 
            // InventoryReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(801, 377);
            this.Controls.Add(this.dataGridViewPartList);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.comboBoxWarehouse);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "InventoryReport";
            this.Text = "InventoryReport";
            this.Load += new System.EventHandler(this.InventoryReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.warehousesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.wSC2019_Session4DataSet)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPartList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxWarehouse;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dataGridViewPartList;
        private System.Windows.Forms.RadioButton radioButtonOutOfStock;
        private System.Windows.Forms.RadioButton radioButtonReceivedStock;
        private System.Windows.Forms.RadioButton radioButtonCurrentStock;
        private WSC2019_Session4DataSet wSC2019_Session4DataSet;
        private System.Windows.Forms.BindingSource warehousesBindingSource;
        private WSC2019_Session4DataSetTableAdapters.WarehousesTableAdapter warehousesTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewLinkColumn Column4;
    }
}