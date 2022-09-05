namespace WindowsFormsApp1
{
    partial class InventoryReportForm
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
            this.comboBoxWarehouse = new System.Windows.Forms.ComboBox();
            this.warehousesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.wSC2019_Session4DataSet = new WindowsFormsApp1.WSC2019_Session4DataSet();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButtonOutOfStock = new System.Windows.Forms.RadioButton();
            this.radioButtonReceivedStock = new System.Windows.Forms.RadioButton();
            this.radioButtonCurrentStock = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.warehousesTableAdapter = new WindowsFormsApp1.WSC2019_Session4DataSetTableAdapters.WarehousesTableAdapter();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridViewPart = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewLinkColumn();
            ((System.ComponentModel.ISupportInitialize)(this.warehousesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.wSC2019_Session4DataSet)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPart)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBoxWarehouse
            // 
            this.comboBoxWarehouse.DataSource = this.warehousesBindingSource;
            this.comboBoxWarehouse.DisplayMember = "Name";
            this.comboBoxWarehouse.FormattingEnabled = true;
            this.comboBoxWarehouse.Location = new System.Drawing.Point(12, 40);
            this.comboBoxWarehouse.Name = "comboBoxWarehouse";
            this.comboBoxWarehouse.Size = new System.Drawing.Size(234, 21);
            this.comboBoxWarehouse.TabIndex = 0;
            this.comboBoxWarehouse.ValueMember = "ID";
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
            this.groupBox1.Location = new System.Drawing.Point(269, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(407, 65);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Inventory Type";
            // 
            // radioButtonOutOfStock
            // 
            this.radioButtonOutOfStock.AutoSize = true;
            this.radioButtonOutOfStock.Location = new System.Drawing.Point(274, 32);
            this.radioButtonOutOfStock.Name = "radioButtonOutOfStock";
            this.radioButtonOutOfStock.Size = new System.Drawing.Size(85, 17);
            this.radioButtonOutOfStock.TabIndex = 2;
            this.radioButtonOutOfStock.TabStop = true;
            this.radioButtonOutOfStock.Text = "Out of Stock";
            this.radioButtonOutOfStock.UseVisualStyleBackColor = true;
            // 
            // radioButtonReceivedStock
            // 
            this.radioButtonReceivedStock.AutoSize = true;
            this.radioButtonReceivedStock.Location = new System.Drawing.Point(124, 32);
            this.radioButtonReceivedStock.Name = "radioButtonReceivedStock";
            this.radioButtonReceivedStock.Size = new System.Drawing.Size(102, 17);
            this.radioButtonReceivedStock.TabIndex = 1;
            this.radioButtonReceivedStock.TabStop = true;
            this.radioButtonReceivedStock.Text = "Received Stock";
            this.radioButtonReceivedStock.UseVisualStyleBackColor = true;
            // 
            // radioButtonCurrentStock
            // 
            this.radioButtonCurrentStock.AutoSize = true;
            this.radioButtonCurrentStock.Location = new System.Drawing.Point(6, 32);
            this.radioButtonCurrentStock.Name = "radioButtonCurrentStock";
            this.radioButtonCurrentStock.Size = new System.Drawing.Size(90, 17);
            this.radioButtonCurrentStock.TabIndex = 0;
            this.radioButtonCurrentStock.TabStop = true;
            this.radioButtonCurrentStock.Text = "Current Stock";
            this.radioButtonCurrentStock.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Warehouse:";
            // 
            // warehousesTableAdapter
            // 
            this.warehousesTableAdapter.ClearBeforeFill = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 112);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Result:";
            // 
            // dataGridViewPart
            // 
            this.dataGridViewPart.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewPart.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5});
            this.dataGridViewPart.Location = new System.Drawing.Point(15, 138);
            this.dataGridViewPart.Name = "dataGridViewPart";
            this.dataGridViewPart.Size = new System.Drawing.Size(661, 286);
            this.dataGridViewPart.TabIndex = 5;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "ID";
            this.Column1.Name = "Column1";
            this.Column1.Visible = false;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Part Name";
            this.Column2.Name = "Column2";
            this.Column2.Width = 150;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Curent Stock";
            this.Column3.Name = "Column3";
            this.Column3.Width = 150;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Received Stock";
            this.Column4.Name = "Column4";
            this.Column4.Width = 150;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Action";
            this.Column5.Name = "Column5";
            this.Column5.Width = 150;
            // 
            // InventoryReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(711, 450);
            this.Controls.Add(this.dataGridViewPart);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.comboBoxWarehouse);
            this.Name = "InventoryReportForm";
            this.Text = "Inventory Report";
            this.Load += new System.EventHandler(this.InventoryReportForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.warehousesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.wSC2019_Session4DataSet)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxWarehouse;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButtonOutOfStock;
        private System.Windows.Forms.RadioButton radioButtonReceivedStock;
        private System.Windows.Forms.RadioButton radioButtonCurrentStock;
        private System.Windows.Forms.Label label1;
        private WSC2019_Session4DataSet wSC2019_Session4DataSet;
        private System.Windows.Forms.BindingSource warehousesBindingSource;
        private WSC2019_Session4DataSetTableAdapters.WarehousesTableAdapter warehousesTableAdapter;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dataGridViewPart;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewLinkColumn Column5;
    }
}