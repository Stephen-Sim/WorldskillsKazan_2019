namespace WindowsFormsApp1
{
    partial class InventoryControlForm
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
            this.comboBoxAsset = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.groupBoxSearchPart = new System.Windows.Forms.GroupBox();
            this.buttonAllocate = new System.Windows.Forms.Button();
            this.comboBoxAllocationMethod = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxAmount = new System.Windows.Forms.TextBox();
            this.comboBoxPart = new System.Windows.Forms.ComboBox();
            this.comboBoxWarehouse = new System.Windows.Forms.ComboBox();
            this.warehousesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.wSC2019_Session6DataSet = new WindowsFormsApp1.WSC2019_Session6DataSet();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.buttonAssingToEM = new System.Windows.Forms.Button();
            this.dataGridViewAllocatedPart = new System.Windows.Forms.DataGridView();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dataGridViewAssignedPart = new System.Windows.Forms.DataGridView();
            this.Column11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewLinkColumn();
            this.buttonSubmit = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.warehousesTableAdapter = new WindowsFormsApp1.WSC2019_Session6DataSetTableAdapters.WarehousesTableAdapter();
            this.groupBoxSearchPart.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.warehousesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.wSC2019_Session6DataSet)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAllocatedPart)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAssignedPart)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Asset Name (EM number):";
            // 
            // comboBoxAsset
            // 
            this.comboBoxAsset.FormattingEnabled = true;
            this.comboBoxAsset.Location = new System.Drawing.Point(148, 6);
            this.comboBoxAsset.Name = "comboBoxAsset";
            this.comboBoxAsset.Size = new System.Drawing.Size(268, 21);
            this.comboBoxAsset.TabIndex = 1;
            this.comboBoxAsset.SelectedIndexChanged += new System.EventHandler(this.comboBoxAsset_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(508, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Date:";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(547, 6);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker1.TabIndex = 3;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // groupBoxSearchPart
            // 
            this.groupBoxSearchPart.Controls.Add(this.buttonAllocate);
            this.groupBoxSearchPart.Controls.Add(this.comboBoxAllocationMethod);
            this.groupBoxSearchPart.Controls.Add(this.label6);
            this.groupBoxSearchPart.Controls.Add(this.textBoxAmount);
            this.groupBoxSearchPart.Controls.Add(this.comboBoxPart);
            this.groupBoxSearchPart.Controls.Add(this.comboBoxWarehouse);
            this.groupBoxSearchPart.Controls.Add(this.label5);
            this.groupBoxSearchPart.Controls.Add(this.label4);
            this.groupBoxSearchPart.Controls.Add(this.label3);
            this.groupBoxSearchPart.Location = new System.Drawing.Point(15, 46);
            this.groupBoxSearchPart.Name = "groupBoxSearchPart";
            this.groupBoxSearchPart.Size = new System.Drawing.Size(804, 120);
            this.groupBoxSearchPart.TabIndex = 4;
            this.groupBoxSearchPart.TabStop = false;
            this.groupBoxSearchPart.Text = "Serach for parts:";
            // 
            // buttonAllocate
            // 
            this.buttonAllocate.Location = new System.Drawing.Point(684, 68);
            this.buttonAllocate.Name = "buttonAllocate";
            this.buttonAllocate.Size = new System.Drawing.Size(106, 23);
            this.buttonAllocate.TabIndex = 16;
            this.buttonAllocate.Text = "Allocate";
            this.buttonAllocate.UseVisualStyleBackColor = true;
            this.buttonAllocate.Click += new System.EventHandler(this.buttonAllocate_Click);
            // 
            // comboBoxAllocationMethod
            // 
            this.comboBoxAllocationMethod.FormattingEnabled = true;
            this.comboBoxAllocationMethod.Location = new System.Drawing.Point(502, 70);
            this.comboBoxAllocationMethod.Name = "comboBoxAllocationMethod";
            this.comboBoxAllocationMethod.Size = new System.Drawing.Size(163, 21);
            this.comboBoxAllocationMethod.TabIndex = 15;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(401, 74);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(95, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Allocation Method:";
            // 
            // textBoxAmount
            // 
            this.textBoxAmount.Location = new System.Drawing.Point(286, 71);
            this.textBoxAmount.Name = "textBoxAmount";
            this.textBoxAmount.Size = new System.Drawing.Size(100, 20);
            this.textBoxAmount.TabIndex = 13;
            // 
            // comboBoxPart
            // 
            this.comboBoxPart.FormattingEnabled = true;
            this.comboBoxPart.Location = new System.Drawing.Point(117, 71);
            this.comboBoxPart.Name = "comboBoxPart";
            this.comboBoxPart.Size = new System.Drawing.Size(111, 21);
            this.comboBoxPart.TabIndex = 12;
            // 
            // comboBoxWarehouse
            // 
            this.comboBoxWarehouse.DataSource = this.warehousesBindingSource;
            this.comboBoxWarehouse.DisplayMember = "Name";
            this.comboBoxWarehouse.FormattingEnabled = true;
            this.comboBoxWarehouse.Location = new System.Drawing.Point(117, 39);
            this.comboBoxWarehouse.Name = "comboBoxWarehouse";
            this.comboBoxWarehouse.Size = new System.Drawing.Size(269, 21);
            this.comboBoxWarehouse.TabIndex = 11;
            this.comboBoxWarehouse.ValueMember = "ID";
            this.comboBoxWarehouse.SelectedIndexChanged += new System.EventHandler(this.comboBoxWarehouse_SelectedIndexChanged);
            // 
            // warehousesBindingSource
            // 
            this.warehousesBindingSource.DataMember = "Warehouses";
            this.warehousesBindingSource.DataSource = this.wSC2019_Session6DataSet;
            // 
            // wSC2019_Session6DataSet
            // 
            this.wSC2019_Session6DataSet.DataSetName = "WSC2019_Session6DataSet";
            this.wSC2019_Session6DataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(30, 74);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Part Name:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(234, 74);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Amount:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(30, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Warehoue:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.buttonAssingToEM);
            this.groupBox2.Controls.Add(this.dataGridViewAllocatedPart);
            this.groupBox2.Location = new System.Drawing.Point(15, 184);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(804, 169);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Allocated Parts:";
            // 
            // buttonAssingToEM
            // 
            this.buttonAssingToEM.Location = new System.Drawing.Point(671, 131);
            this.buttonAssingToEM.Name = "buttonAssingToEM";
            this.buttonAssingToEM.Size = new System.Drawing.Size(119, 23);
            this.buttonAssingToEM.TabIndex = 17;
            this.buttonAssingToEM.Text = "Assign to EM";
            this.buttonAssingToEM.UseVisualStyleBackColor = true;
            this.buttonAssingToEM.Click += new System.EventHandler(this.buttonAssingToEM_Click);
            // 
            // dataGridViewAllocatedPart
            // 
            this.dataGridViewAllocatedPart.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewAllocatedPart.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column10,
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4});
            this.dataGridViewAllocatedPart.Location = new System.Drawing.Point(20, 19);
            this.dataGridViewAllocatedPart.Name = "dataGridViewAllocatedPart";
            this.dataGridViewAllocatedPart.Size = new System.Drawing.Size(645, 144);
            this.dataGridViewAllocatedPart.TabIndex = 8;
            // 
            // Column10
            // 
            this.Column10.HeaderText = "ID";
            this.Column10.Name = "Column10";
            this.Column10.Visible = false;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Part Name";
            this.Column1.Name = "Column1";
            this.Column1.Width = 150;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Batch Number";
            this.Column2.Name = "Column2";
            this.Column2.Width = 150;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Unit Price";
            this.Column3.Name = "Column3";
            this.Column3.Width = 150;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Amount";
            this.Column4.Name = "Column4";
            this.Column4.Width = 150;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dataGridViewAssignedPart);
            this.groupBox3.Location = new System.Drawing.Point(15, 359);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(804, 225);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Assigned Parts:";
            // 
            // dataGridViewAssignedPart
            // 
            this.dataGridViewAssignedPart.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewAssignedPart.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column11,
            this.Column5,
            this.Column6,
            this.Column7,
            this.Column8,
            this.Column9});
            this.dataGridViewAssignedPart.Location = new System.Drawing.Point(20, 25);
            this.dataGridViewAssignedPart.Name = "dataGridViewAssignedPart";
            this.dataGridViewAssignedPart.Size = new System.Drawing.Size(770, 194);
            this.dataGridViewAssignedPart.TabIndex = 9;
            this.dataGridViewAssignedPart.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewAssignedPart_CellClick);
            // 
            // Column11
            // 
            this.Column11.HeaderText = "ID";
            this.Column11.Name = "Column11";
            this.Column11.Visible = false;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Part Name";
            this.Column5.Name = "Column5";
            this.Column5.Width = 150;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "Batch Number";
            this.Column6.Name = "Column6";
            this.Column6.Width = 150;
            // 
            // Column7
            // 
            this.Column7.HeaderText = "Unit Price";
            this.Column7.Name = "Column7";
            this.Column7.Width = 150;
            // 
            // Column8
            // 
            this.Column8.HeaderText = "Amount";
            this.Column8.Name = "Column8";
            this.Column8.Width = 150;
            // 
            // Column9
            // 
            this.Column9.HeaderText = "Action";
            this.Column9.Name = "Column9";
            this.Column9.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column9.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Column9.Width = 120;
            // 
            // buttonSubmit
            // 
            this.buttonSubmit.Location = new System.Drawing.Point(301, 590);
            this.buttonSubmit.Name = "buttonSubmit";
            this.buttonSubmit.Size = new System.Drawing.Size(112, 23);
            this.buttonSubmit.TabIndex = 6;
            this.buttonSubmit.Text = "Submit";
            this.buttonSubmit.UseVisualStyleBackColor = true;
            this.buttonSubmit.Click += new System.EventHandler(this.buttonSubmit_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(440, 590);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(112, 23);
            this.buttonCancel.TabIndex = 7;
            this.buttonCancel.Text = "Camcel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // warehousesTableAdapter
            // 
            this.warehousesTableAdapter.ClearBeforeFill = true;
            // 
            // InventoryControlForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(836, 635);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonSubmit);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBoxSearchPart);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBoxAsset);
            this.Controls.Add(this.label1);
            this.Name = "InventoryControlForm";
            this.Text = "Inventory Control";
            this.Load += new System.EventHandler(this.InventoryControlForm_Load);
            this.groupBoxSearchPart.ResumeLayout(false);
            this.groupBoxSearchPart.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.warehousesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.wSC2019_Session6DataSet)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAllocatedPart)).EndInit();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAssignedPart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxAsset;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.GroupBox groupBoxSearchPart;
        private System.Windows.Forms.Button buttonAllocate;
        private System.Windows.Forms.ComboBox comboBoxAllocationMethod;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxAmount;
        private System.Windows.Forms.ComboBox comboBoxPart;
        private System.Windows.Forms.ComboBox comboBoxWarehouse;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button buttonSubmit;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.DataGridView dataGridViewAllocatedPart;
        private System.Windows.Forms.Button buttonAssingToEM;
        private System.Windows.Forms.DataGridView dataGridViewAssignedPart;
        private WSC2019_Session6DataSet wSC2019_Session6DataSet;
        private System.Windows.Forms.BindingSource warehousesBindingSource;
        private WSC2019_Session6DataSetTableAdapters.WarehousesTableAdapter warehousesTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column11;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewLinkColumn Column9;
    }
}