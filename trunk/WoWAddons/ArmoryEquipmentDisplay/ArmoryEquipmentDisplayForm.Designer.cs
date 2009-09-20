namespace ArmoryEquipmentDisplay
{
    partial class ArmoryEquipmentDisplayForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ArmoryEquipmentDisplayForm));
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.dgViewCharacters = new System.Windows.Forms.DataGridView();
            this.colCharName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEquipHead = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEquipNeck = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEquipShoulders = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgViewCharacters)).BeginInit();
            this.SuspendLayout();
            // 
            // toolTip1
            // 
            this.toolTip1.Tag = "";
            // 
            // dgViewCharacters
            // 
            this.dgViewCharacters.AllowUserToDeleteRows = false;
            this.dgViewCharacters.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgViewCharacters.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colCharName,
            this.colEquipHead,
            this.colEquipNeck,
            this.colEquipShoulders});
            this.dgViewCharacters.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgViewCharacters.Location = new System.Drawing.Point(0, 0);
            this.dgViewCharacters.Name = "dgViewCharacters";
            this.dgViewCharacters.Size = new System.Drawing.Size(725, 335);
            this.dgViewCharacters.TabIndex = 0;
            this.dgViewCharacters.VirtualMode = true;
            this.dgViewCharacters.CellValueNeeded += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.dgViewCharacters_CellValueNeeded);
            this.dgViewCharacters.CellValuePushed += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.dgViewCharacters_CellValuePushed);
            this.dgViewCharacters.CellToolTipTextNeeded += new System.Windows.Forms.DataGridViewCellToolTipTextNeededEventHandler(this.dgViewCharacters_CellToolTipTextNeeded);
            this.dgViewCharacters.NewRowNeeded += new System.Windows.Forms.DataGridViewRowEventHandler(this.dgViewCharacters_NewRowNeeded);
            // 
            // colCharName
            // 
            this.colCharName.HeaderText = "Char Name";
            this.colCharName.Name = "colCharName";
            // 
            // colEquipHead
            // 
            this.colEquipHead.HeaderText = "Helm";
            this.colEquipHead.Name = "colEquipHead";
            // 
            // colEquipNeck
            // 
            this.colEquipNeck.HeaderText = "Neck";
            this.colEquipNeck.Name = "colEquipNeck";
            // 
            // colEquipShoulders
            // 
            this.colEquipShoulders.HeaderText = "Shoulders";
            this.colEquipShoulders.Name = "colEquipShoulders";
            // 
            // ArmoryEquipmentDisplayForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(725, 335);
            this.Controls.Add(this.dgViewCharacters);
            this.Name = "ArmoryEquipmentDisplayForm";
            this.Text = "Equipment";
            this.toolTip1.SetToolTip(this, resources.GetString("$this.ToolTip"));
            ((System.ComponentModel.ISupportInitialize)(this.dgViewCharacters)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.DataGridView dgViewCharacters;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCharName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEquipHead;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEquipNeck;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEquipShoulders;
    }
}

