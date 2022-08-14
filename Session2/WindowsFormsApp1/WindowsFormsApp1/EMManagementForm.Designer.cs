namespace WindowsFormsApp1
{
    partial class EMManagementForm
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
            this.dataGridViewAssets = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonSendRequest = new System.Windows.Forms.Button();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AssetSN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AssetName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LastEMDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EMCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAssets)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewAssets
            // 
            this.dataGridViewAssets.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewAssets.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.AssetSN,
            this.AssetName,
            this.LastEMDate,
            this.EMCount});
            this.dataGridViewAssets.Location = new System.Drawing.Point(12, 57);
            this.dataGridViewAssets.Name = "dataGridViewAssets";
            this.dataGridViewAssets.Size = new System.Drawing.Size(766, 304);
            this.dataGridViewAssets.TabIndex = 0;
            this.dataGridViewAssets.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewAssets_CellClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Available Assets:";
            // 
            // buttonSendRequest
            // 
            this.buttonSendRequest.Location = new System.Drawing.Point(15, 389);
            this.buttonSendRequest.Name = "buttonSendRequest";
            this.buttonSendRequest.Size = new System.Drawing.Size(227, 23);
            this.buttonSendRequest.TabIndex = 2;
            this.buttonSendRequest.Text = "Send Emergency Maintenance Request";
            this.buttonSendRequest.UseVisualStyleBackColor = true;
            this.buttonSendRequest.Click += new System.EventHandler(this.buttonSendRequest_Click);
            // 
            // ID
            // 
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.Visible = false;
            // 
            // AssetSN
            // 
            this.AssetSN.HeaderText = "AssetSN";
            this.AssetSN.Name = "AssetSN";
            this.AssetSN.Width = 180;
            // 
            // AssetName
            // 
            this.AssetName.HeaderText = "AssetName";
            this.AssetName.Name = "AssetName";
            this.AssetName.Width = 180;
            // 
            // LastEMDate
            // 
            this.LastEMDate.HeaderText = "Last Closed EM";
            this.LastEMDate.Name = "LastEMDate";
            this.LastEMDate.Width = 180;
            // 
            // EMCount
            // 
            this.EMCount.HeaderText = "Number of EMs";
            this.EMCount.Name = "EMCount";
            this.EMCount.Width = 180;
            // 
            // EMManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(787, 424);
            this.Controls.Add(this.buttonSendRequest);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridViewAssets);
            this.Name = "EMManagement";
            this.Text = "Emergency Maintenance Management";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAssets)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewAssets;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonSendRequest;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn AssetSN;
        private System.Windows.Forms.DataGridViewTextBoxColumn AssetName;
        private System.Windows.Forms.DataGridViewTextBoxColumn LastEMDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn EMCount;
    }
}