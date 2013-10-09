namespace QuickCodeSel.Interface
{
    partial class PopEditTables
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
            this.dtGridTablesTemplate = new System.Windows.Forms.DataGridView();
            this.CheckTable = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.btnClose = new System.Windows.Forms.Button();
            this.chkAllTables = new System.Windows.Forms.CheckBox();
            this.Table = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CSName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dtGridTablesTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tableBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dtGridTablesTemplate
            // 
            this.dtGridTablesTemplate.AllowUserToAddRows = false;
            this.dtGridTablesTemplate.AllowUserToDeleteRows = false;
            this.dtGridTablesTemplate.AllowUserToOrderColumns = true;
            this.dtGridTablesTemplate.AutoGenerateColumns = false;
            this.dtGridTablesTemplate.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtGridTablesTemplate.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CheckTable,
            this.Table,
            this.CSName});
            this.dtGridTablesTemplate.DataSource = this.tableBindingSource;
            this.dtGridTablesTemplate.Location = new System.Drawing.Point(14, 8);
            this.dtGridTablesTemplate.MultiSelect = false;
            this.dtGridTablesTemplate.Name = "dtGridTablesTemplate";
            this.dtGridTablesTemplate.RowHeadersVisible = false;
            this.dtGridTablesTemplate.Size = new System.Drawing.Size(264, 306);
            this.dtGridTablesTemplate.TabIndex = 1;
            // 
            // CheckTable
            // 
            this.CheckTable.DataPropertyName = "Selected";
            this.CheckTable.HeaderText = "";
            this.CheckTable.Name = "CheckTable";
            this.CheckTable.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.CheckTable.Width = 20;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(109, 324);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // chkAllTables
            // 
            this.chkAllTables.AutoSize = true;
            this.chkAllTables.Location = new System.Drawing.Point(19, 12);
            this.chkAllTables.Name = "chkAllTables";
            this.chkAllTables.Size = new System.Drawing.Size(15, 14);
            this.chkAllTables.TabIndex = 3;
            this.chkAllTables.UseVisualStyleBackColor = true;
            this.chkAllTables.CheckedChanged += new System.EventHandler(this.chkAllTables_CheckedChanged);
            // 
            // Table
            // 
            this.Table.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Table.DataPropertyName = "Name";
            this.Table.FillWeight = 50F;
            this.Table.HeaderText = "Name";
            this.Table.Name = "Table";
            this.Table.ReadOnly = true;
            // 
            // CSName
            // 
            this.CSName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.CSName.DataPropertyName = "CSName";
            this.CSName.FillWeight = 50F;
            this.CSName.HeaderText = "C# Name";
            this.CSName.Name = "CSName";
            this.CSName.ReadOnly = true;
            // 
            // tableBindingSource
            // 
            this.tableBindingSource.DataSource = typeof(QuickCodeSel.Data.Entities.Table);
            // 
            // PopEditTables
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 359);
            this.Controls.Add(this.chkAllTables);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.dtGridTablesTemplate);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PopEditTables";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Edit Tables";
            ((System.ComponentModel.ISupportInitialize)(this.dtGridTablesTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tableBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource tableBindingSource;
        private System.Windows.Forms.DataGridView dtGridTablesTemplate;
        private System.Windows.Forms.DataGridViewCheckBoxColumn CheckTable;
        private System.Windows.Forms.DataGridViewTextBoxColumn Table;
        private System.Windows.Forms.DataGridViewTextBoxColumn CSName;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.CheckBox chkAllTables;

    }
}