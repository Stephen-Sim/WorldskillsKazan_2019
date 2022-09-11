namespace WindowsFormsApp1
{
    partial class WarehouseManagementForm
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
            this.partsTableAdapter = new WindowsFormsApp1.WSC2019_Session4DataSetTableAdapters.PartsTableAdapter();
            this.suppliersTableAdapter = new WindowsFormsApp1.WSC2019_Session4DataSetTableAdapters.SuppliersTableAdapter();
            this.buttonSubmit = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.partsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.wSC2019_Session4DataSet = new WindowsFormsApp1.WSC2019_Session4DataSet();
            this.buttonAddtoList = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxAmount = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxBatchNumber = new System.Windows.Forms.TextBox();
            this.comboBoxPart = new System.Windows.Forms.ComboBox();
            this.Column5 = new System.Windows.Forms.DataGridViewLinkColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.warehousesTableAdapter = new WindowsFormsApp1.WSC2019_Session4DataSetTableAdapters.WarehousesTableAdapter();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewPart = new System.Windows.Forms.DataGridView();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dateTimePickerDate = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.warehousesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.comboBoxWarehouse1 = new System.Windows.Forms.ComboBox();
            this.suppliersBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.comboBoxWarehouse = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.warehousesBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.partsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.wSC2019_Session4DataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPart)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.warehousesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.suppliersBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.warehousesBindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // partsTableAdapter
            // 
            this.partsTableAdapter.ClearBeforeFill = true;
            // 
            // suppliersTableAdapter
            // 
            this.suppliersTableAdapter.ClearBeforeFill = true;
            // 
            // buttonSubmit
            // 
            this.buttonSubmit.Location = new System.Drawing.Point(226, 339);
            this.buttonSubmit.Name = "buttonSubmit";
            this.buttonSubmit.Size = new System.Drawing.Size(127, 23);
            this.buttonSubmit.TabIndex = 16;
            this.buttonSubmit.Text = "Submit";
            this.buttonSubmit.UseVisualStyleBackColor = true;
            this.buttonSubmit.Click += new System.EventHandler(this.buttonSubmit_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 27);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Part Name:";
            // 
            // partsBindingSource
            // 
            this.partsBindingSource.DataMember = "Parts";
            this.partsBindingSource.DataSource = this.wSC2019_Session4DataSet;
            // 
            // wSC2019_Session4DataSet
            // 
            this.wSC2019_Session4DataSet.DataSetName = "WSC2019_Session4DataSet";
            this.wSC2019_Session4DataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // buttonAddtoList
            // 
            this.buttonAddtoList.Location = new System.Drawing.Point(632, 24);
            this.buttonAddtoList.Name = "buttonAddtoList";
            this.buttonAddtoList.Size = new System.Drawing.Size(100, 23);
            this.buttonAddtoList.TabIndex = 9;
            this.buttonAddtoList.Text = "Add to List";
            this.buttonAddtoList.UseVisualStyleBackColor = true;
            this.buttonAddtoList.Click += new System.EventHandler(this.buttonAddtoList_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(448, 27);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(46, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Amount:";
            // 
            // textBoxAmount
            // 
            this.textBoxAmount.Location = new System.Drawing.Point(500, 24);
            this.textBoxAmount.Name = "textBoxAmount";
            this.textBoxAmount.Size = new System.Drawing.Size(109, 20);
            this.textBoxAmount.TabIndex = 13;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(234, 27);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Batch Number:";
            // 
            // textBoxBatchNumber
            // 
            this.textBoxBatchNumber.Location = new System.Drawing.Point(318, 24);
            this.textBoxBatchNumber.Name = "textBoxBatchNumber";
            this.textBoxBatchNumber.Size = new System.Drawing.Size(109, 20);
            this.textBoxBatchNumber.TabIndex = 11;
            // 
            // comboBoxPart
            // 
            this.comboBoxPart.DataSource = this.partsBindingSource;
            this.comboBoxPart.DisplayMember = "Name";
            this.comboBoxPart.FormattingEnabled = true;
            this.comboBoxPart.Location = new System.Drawing.Point(72, 24);
            this.comboBoxPart.Name = "comboBoxPart";
            this.comboBoxPart.Size = new System.Drawing.Size(146, 21);
            this.comboBoxPart.TabIndex = 10;
            this.comboBoxPart.ValueMember = "ID";
            this.comboBoxPart.SelectedIndexChanged += new System.EventHandler(this.comboBoxPart_SelectedIndexChanged);
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Action";
            this.Column5.Name = "Column5";
            this.Column5.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Column5.Width = 160;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Amount";
            this.Column4.Name = "Column4";
            this.Column4.Width = 160;
            // 
            // warehousesTableAdapter
            // 
            this.warehousesTableAdapter.ClearBeforeFill = true;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Batch Number";
            this.Column3.Name = "Column3";
            this.Column3.Width = 170;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "PartId";
            this.Column1.Name = "Column1";
            this.Column1.Visible = false;
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
            this.dataGridViewPart.Location = new System.Drawing.Point(9, 50);
            this.dataGridViewPart.Name = "dataGridViewPart";
            this.dataGridViewPart.Size = new System.Drawing.Size(723, 136);
            this.dataGridViewPart.TabIndex = 15;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Part Name";
            this.Column2.Name = "Column2";
            this.Column2.Width = 170;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dataGridViewPart);
            this.groupBox1.Controls.Add(this.buttonAddtoList);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.textBoxAmount);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.textBoxBatchNumber);
            this.groupBox1.Controls.Add(this.comboBoxPart);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(15, 129);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(750, 195);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Parts List";
            // 
            // dateTimePickerDate
            // 
            this.dateTimePickerDate.Location = new System.Drawing.Point(51, 82);
            this.dateTimePickerDate.Name = "dateTimePickerDate";
            this.dateTimePickerDate.Size = new System.Drawing.Size(206, 20);
            this.dateTimePickerDate.TabIndex = 14;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Date:";
            // 
            // warehousesBindingSource
            // 
            this.warehousesBindingSource.DataMember = "Warehouses";
            this.warehousesBindingSource.DataSource = this.wSC2019_Session4DataSet;
            // 
            // comboBoxWarehouse1
            // 
            this.comboBoxWarehouse1.DataSource = this.warehousesBindingSource;
            this.comboBoxWarehouse1.DisplayMember = "Name";
            this.comboBoxWarehouse1.FormattingEnabled = true;
            this.comboBoxWarehouse1.Location = new System.Drawing.Point(343, 38);
            this.comboBoxWarehouse1.Name = "comboBoxWarehouse1";
            this.comboBoxWarehouse1.Size = new System.Drawing.Size(242, 21);
            this.comboBoxWarehouse1.TabIndex = 12;
            this.comboBoxWarehouse1.ValueMember = "ID";
            // 
            // suppliersBindingSource
            // 
            this.suppliersBindingSource.DataMember = "Suppliers";
            this.suppliersBindingSource.DataSource = this.wSC2019_Session4DataSet;
            // 
            // comboBoxWarehouse
            // 
            this.comboBoxWarehouse.DataSource = this.warehousesBindingSource1;
            this.comboBoxWarehouse.DisplayMember = "Name";
            this.comboBoxWarehouse.FormattingEnabled = true;
            this.comboBoxWarehouse.Location = new System.Drawing.Point(15, 38);
            this.comboBoxWarehouse.Name = "comboBoxWarehouse";
            this.comboBoxWarehouse.Size = new System.Drawing.Size(242, 21);
            this.comboBoxWarehouse.TabIndex = 11;
            this.comboBoxWarehouse.ValueMember = "ID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(340, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(121, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Destination Warehouse:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Source Warehouse:";
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(382, 339);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(127, 23);
            this.buttonCancel.TabIndex = 17;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // warehousesBindingSource1
            // 
            this.warehousesBindingSource1.DataMember = "Warehouses";
            this.warehousesBindingSource1.DataSource = this.wSC2019_Session4DataSet;
            // 
            // WarehouseManagementForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(770, 378);
            this.Controls.Add(this.buttonSubmit);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dateTimePickerDate);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboBoxWarehouse1);
            this.Controls.Add(this.comboBoxWarehouse);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonCancel);
            this.Name = "WarehouseManagementForm";
            this.Text = "WarehouseManagementForm";
            this.Load += new System.EventHandler(this.WarehouseManagementForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.partsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.wSC2019_Session4DataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPart)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.warehousesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.suppliersBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.warehousesBindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private WSC2019_Session4DataSetTableAdapters.PartsTableAdapter partsTableAdapter;
        private WSC2019_Session4DataSetTableAdapters.SuppliersTableAdapter suppliersTableAdapter;
        private System.Windows.Forms.Button buttonSubmit;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.BindingSource partsBindingSource;
        private WSC2019_Session4DataSet wSC2019_Session4DataSet;
        private System.Windows.Forms.Button buttonAddtoList;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxAmount;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxBatchNumber;
        private System.Windows.Forms.ComboBox comboBoxPart;
        private System.Windows.Forms.DataGridViewLinkColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private WSC2019_Session4DataSetTableAdapters.WarehousesTableAdapter warehousesTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridView dataGridViewPart;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker dateTimePickerDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.BindingSource warehousesBindingSource;
        private System.Windows.Forms.ComboBox comboBoxWarehouse1;
        private System.Windows.Forms.BindingSource suppliersBindingSource;
        private System.Windows.Forms.ComboBox comboBoxWarehouse;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.BindingSource warehousesBindingSource1;
    }
}