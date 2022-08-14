namespace WindowsFormsApp1
{
    partial class EMaintenanceRequestForm
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.labelDepartment = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.labelAssetName = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.labelAssetSN = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBoxPriority = new System.Windows.Forms.ComboBox();
            this.richTextBoxDesc = new System.Windows.Forms.RichTextBox();
            this.richTextBoxOtherCon = new System.Windows.Forms.RichTextBox();
            this.buttonSubmit = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.wSC2019_Session2DataSet = new WindowsFormsApp1.WSC2019_Session2DataSet();
            this.prioritiesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.prioritiesTableAdapter = new WindowsFormsApp1.WSC2019_Session2DataSetTableAdapters.PrioritiesTableAdapter();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.wSC2019_Session2DataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.prioritiesBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.richTextBoxOtherCon);
            this.groupBox2.Controls.Add(this.richTextBoxDesc);
            this.groupBox2.Controls.Add(this.comboBoxPriority);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(22, 163);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(647, 226);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Request Report";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.labelDepartment);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.labelAssetName);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.labelAssetSN);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(22, 42);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(647, 100);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Select Asset";
            // 
            // labelDepartment
            // 
            this.labelDepartment.AutoSize = true;
            this.labelDepartment.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDepartment.Location = new System.Drawing.Point(488, 44);
            this.labelDepartment.Name = "labelDepartment";
            this.labelDepartment.Size = new System.Drawing.Size(41, 13);
            this.labelDepartment.TabIndex = 8;
            this.labelDepartment.Text = "label5";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(423, 44);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(68, 13);
            this.label6.TabIndex = 7;
            this.label6.Text = "Department :";
            // 
            // labelAssetName
            // 
            this.labelAssetName.AutoSize = true;
            this.labelAssetName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAssetName.Location = new System.Drawing.Point(290, 44);
            this.labelAssetName.Name = "labelAssetName";
            this.labelAssetName.Size = new System.Drawing.Size(41, 13);
            this.labelAssetName.TabIndex = 6;
            this.labelAssetName.Text = "label3";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(222, 44);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Asset Name :";
            // 
            // labelAssetSN
            // 
            this.labelAssetSN.AutoSize = true;
            this.labelAssetSN.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAssetSN.Location = new System.Drawing.Point(89, 44);
            this.labelAssetSN.Name = "labelAssetSN";
            this.labelAssetSN.Size = new System.Drawing.Size(41, 13);
            this.labelAssetSN.TabIndex = 4;
            this.labelAssetSN.Text = "label2";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Asset SN :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Priority :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(26, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(134, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Descirption of Emergency :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(26, 150);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(111, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Other Considerations :";
            // 
            // comboBoxPriority
            // 
            this.comboBoxPriority.DataSource = this.prioritiesBindingSource;
            this.comboBoxPriority.DisplayMember = "Name";
            this.comboBoxPriority.FormattingEnabled = true;
            this.comboBoxPriority.Location = new System.Drawing.Point(76, 30);
            this.comboBoxPriority.Name = "comboBoxPriority";
            this.comboBoxPriority.Size = new System.Drawing.Size(179, 21);
            this.comboBoxPriority.TabIndex = 3;
            this.comboBoxPriority.ValueMember = "ID";
            // 
            // richTextBoxDesc
            // 
            this.richTextBoxDesc.Location = new System.Drawing.Point(54, 84);
            this.richTextBoxDesc.Name = "richTextBoxDesc";
            this.richTextBoxDesc.Size = new System.Drawing.Size(575, 48);
            this.richTextBoxDesc.TabIndex = 4;
            this.richTextBoxDesc.Text = "";
            // 
            // richTextBoxOtherCon
            // 
            this.richTextBoxOtherCon.Location = new System.Drawing.Point(54, 166);
            this.richTextBoxOtherCon.Name = "richTextBoxOtherCon";
            this.richTextBoxOtherCon.Size = new System.Drawing.Size(575, 47);
            this.richTextBoxOtherCon.TabIndex = 5;
            this.richTextBoxOtherCon.Text = "";
            // 
            // buttonSubmit
            // 
            this.buttonSubmit.Location = new System.Drawing.Point(165, 414);
            this.buttonSubmit.Name = "buttonSubmit";
            this.buttonSubmit.Size = new System.Drawing.Size(160, 23);
            this.buttonSubmit.TabIndex = 6;
            this.buttonSubmit.Text = "Submit Request";
            this.buttonSubmit.UseVisualStyleBackColor = true;
            this.buttonSubmit.Click += new System.EventHandler(this.buttonSubmit_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(353, 414);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(160, 23);
            this.buttonCancel.TabIndex = 7;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // wSC2019_Session2DataSet
            // 
            this.wSC2019_Session2DataSet.DataSetName = "WSC2019_Session2DataSet";
            this.wSC2019_Session2DataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // prioritiesBindingSource
            // 
            this.prioritiesBindingSource.DataMember = "Priorities";
            this.prioritiesBindingSource.DataSource = this.wSC2019_Session2DataSet;
            // 
            // prioritiesTableAdapter
            // 
            this.prioritiesTableAdapter.ClearBeforeFill = true;
            // 
            // EMRequest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(693, 454);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonSubmit);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Name = "EMRequest";
            this.Text = "Emergency Maintenance Request";
            this.Load += new System.EventHandler(this.EMRequest_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.wSC2019_Session2DataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.prioritiesBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RichTextBox richTextBoxOtherCon;
        private System.Windows.Forms.RichTextBox richTextBoxDesc;
        private System.Windows.Forms.ComboBox comboBoxPriority;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label labelDepartment;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label labelAssetName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label labelAssetSN;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonSubmit;
        private System.Windows.Forms.Button buttonCancel;
        private WSC2019_Session2DataSet wSC2019_Session2DataSet;
        private System.Windows.Forms.BindingSource prioritiesBindingSource;
        private WSC2019_Session2DataSetTableAdapters.PrioritiesTableAdapter prioritiesTableAdapter;
    }
}