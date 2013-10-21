namespace QuickCodeSel.Interface
{
    partial class TableSelectionForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TableSelectionForm));
            this.cmbTables = new System.Windows.Forms.ComboBox();
            this.lblSelectTables = new System.Windows.Forms.Label();
            this.dtGridColumn = new System.Windows.Forms.DataGridView();
            this.columnBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dtGridTable = new System.Windows.Forms.DataGridView();
            this.tableBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.lblCurrentAction = new System.Windows.Forms.Label();
            this.grpBoxTables = new System.Windows.Forms.GroupBox();
            this.grpBoxColumns = new System.Windows.Forms.GroupBox();
            this.btnChooseTemplates = new System.Windows.Forms.Button();
            this.nameDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DbType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.isPKDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.isFKDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.isAIDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.isUNDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.isNullAbleDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OneToOne = new System.Windows.Forms.DataGridViewButtonColumn();
            this.OneToMany = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dtGridColumn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.columnBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtGridTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tableBindingSource)).BeginInit();
            this.grpBoxTables.SuspendLayout();
            this.grpBoxColumns.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmbTables
            // 
            this.cmbTables.FormattingEnabled = true;
            this.cmbTables.Location = new System.Drawing.Point(74, 9);
            this.cmbTables.Name = "cmbTables";
            this.cmbTables.Size = new System.Drawing.Size(181, 21);
            this.cmbTables.TabIndex = 0;
            this.cmbTables.SelectedIndexChanged += new System.EventHandler(this.cmbTables_SelectedIndexChanged);
            // 
            // lblSelectTables
            // 
            this.lblSelectTables.AutoSize = true;
            this.lblSelectTables.Location = new System.Drawing.Point(12, 12);
            this.lblSelectTables.Name = "lblSelectTables";
            this.lblSelectTables.Size = new System.Drawing.Size(56, 13);
            this.lblSelectTables.TabIndex = 1;
            this.lblSelectTables.Text = "Database:";
            // 
            // dtGridColumn
            // 
            this.dtGridColumn.AllowUserToAddRows = false;
            this.dtGridColumn.AllowUserToDeleteRows = false;
            this.dtGridColumn.AllowUserToOrderColumns = true;
            this.dtGridColumn.AutoGenerateColumns = false;
            this.dtGridColumn.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtGridColumn.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nameDataGridViewTextBoxColumn1,
            this.DbType,
            this.isPKDataGridViewCheckBoxColumn,
            this.isFKDataGridViewCheckBoxColumn,
            this.isAIDataGridViewCheckBoxColumn,
            this.isUNDataGridViewCheckBoxColumn,
            this.isNullAbleDataGridViewCheckBoxColumn});
            this.dtGridColumn.DataSource = this.columnBindingSource;
            this.dtGridColumn.Location = new System.Drawing.Point(6, 19);
            this.dtGridColumn.MultiSelect = false;
            this.dtGridColumn.Name = "dtGridColumn";
            this.dtGridColumn.RowHeadersVisible = false;
            this.dtGridColumn.Size = new System.Drawing.Size(394, 279);
            this.dtGridColumn.TabIndex = 2;
            // 
            // columnBindingSource
            // 
            this.columnBindingSource.DataSource = typeof(QuickCodeSel.Data.Entities.Column);
            // 
            // dtGridTable
            // 
            this.dtGridTable.AllowUserToAddRows = false;
            this.dtGridTable.AllowUserToDeleteRows = false;
            this.dtGridTable.AllowUserToOrderColumns = true;
            this.dtGridTable.AutoGenerateColumns = false;
            this.dtGridTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtGridTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nameDataGridViewTextBoxColumn,
            this.OneToOne,
            this.OneToMany});
            this.dtGridTable.DataSource = this.tableBindingSource;
            this.dtGridTable.Location = new System.Drawing.Point(6, 19);
            this.dtGridTable.MultiSelect = false;
            this.dtGridTable.Name = "dtGridTable";
            this.dtGridTable.RowHeadersVisible = false;
            this.dtGridTable.Size = new System.Drawing.Size(270, 279);
            this.dtGridTable.TabIndex = 3;
            this.dtGridTable.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtGridTable_RowEnter);
            // 
            // tableBindingSource
            // 
            this.tableBindingSource.DataSource = typeof(QuickCodeSel.Data.Entities.Table);
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(12, 351);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(595, 29);
            this.progressBar.TabIndex = 4;
            // 
            // lblCurrentAction
            // 
            this.lblCurrentAction.AutoSize = true;
            this.lblCurrentAction.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentAction.Location = new System.Drawing.Point(288, 12);
            this.lblCurrentAction.Name = "lblCurrentAction";
            this.lblCurrentAction.Size = new System.Drawing.Size(0, 13);
            this.lblCurrentAction.TabIndex = 5;
            // 
            // grpBoxTables
            // 
            this.grpBoxTables.Controls.Add(this.dtGridTable);
            this.grpBoxTables.Location = new System.Drawing.Point(12, 36);
            this.grpBoxTables.Name = "grpBoxTables";
            this.grpBoxTables.Size = new System.Drawing.Size(289, 309);
            this.grpBoxTables.TabIndex = 7;
            this.grpBoxTables.TabStop = false;
            this.grpBoxTables.Text = "Tables";
            // 
            // grpBoxColumns
            // 
            this.grpBoxColumns.Controls.Add(this.dtGridColumn);
            this.grpBoxColumns.Location = new System.Drawing.Point(307, 36);
            this.grpBoxColumns.Name = "grpBoxColumns";
            this.grpBoxColumns.Size = new System.Drawing.Size(410, 309);
            this.grpBoxColumns.TabIndex = 4;
            this.grpBoxColumns.TabStop = false;
            this.grpBoxColumns.Text = "Columns";
            // 
            // btnChooseTemplates
            // 
            this.btnChooseTemplates.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnChooseTemplates.Image = global::QuickCodeSel.Interface.Properties.Resources._1382119585_newspaper_go1;
            this.btnChooseTemplates.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnChooseTemplates.Location = new System.Drawing.Point(613, 351);
            this.btnChooseTemplates.Name = "btnChooseTemplates";
            this.btnChooseTemplates.Size = new System.Drawing.Size(104, 29);
            this.btnChooseTemplates.TabIndex = 6;
            this.btnChooseTemplates.Text = "Next";
            this.btnChooseTemplates.UseVisualStyleBackColor = true;
            this.btnChooseTemplates.Click += new System.EventHandler(this.btnChooseTemplates_Click);
            // 
            // nameDataGridViewTextBoxColumn1
            // 
            this.nameDataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.nameDataGridViewTextBoxColumn1.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn1.HeaderText = "Name";
            this.nameDataGridViewTextBoxColumn1.Name = "nameDataGridViewTextBoxColumn1";
            // 
            // DbType
            // 
            this.DbType.DataPropertyName = "DbType";
            this.DbType.HeaderText = "DbType";
            this.DbType.Name = "DbType";
            // 
            // isPKDataGridViewCheckBoxColumn
            // 
            this.isPKDataGridViewCheckBoxColumn.DataPropertyName = "IsPK";
            this.isPKDataGridViewCheckBoxColumn.HeaderText = "PK";
            this.isPKDataGridViewCheckBoxColumn.Name = "isPKDataGridViewCheckBoxColumn";
            this.isPKDataGridViewCheckBoxColumn.Width = 27;
            // 
            // isFKDataGridViewCheckBoxColumn
            // 
            this.isFKDataGridViewCheckBoxColumn.DataPropertyName = "IsFK";
            this.isFKDataGridViewCheckBoxColumn.HeaderText = "FK";
            this.isFKDataGridViewCheckBoxColumn.Name = "isFKDataGridViewCheckBoxColumn";
            this.isFKDataGridViewCheckBoxColumn.Width = 27;
            // 
            // isAIDataGridViewCheckBoxColumn
            // 
            this.isAIDataGridViewCheckBoxColumn.DataPropertyName = "IsAI";
            this.isAIDataGridViewCheckBoxColumn.HeaderText = "AI";
            this.isAIDataGridViewCheckBoxColumn.Name = "isAIDataGridViewCheckBoxColumn";
            this.isAIDataGridViewCheckBoxColumn.Width = 27;
            // 
            // isUNDataGridViewCheckBoxColumn
            // 
            this.isUNDataGridViewCheckBoxColumn.DataPropertyName = "IsUN";
            this.isUNDataGridViewCheckBoxColumn.HeaderText = "UN";
            this.isUNDataGridViewCheckBoxColumn.Name = "isUNDataGridViewCheckBoxColumn";
            this.isUNDataGridViewCheckBoxColumn.Width = 27;
            // 
            // isNullAbleDataGridViewCheckBoxColumn
            // 
            this.isNullAbleDataGridViewCheckBoxColumn.DataPropertyName = "IsNullAble";
            this.isNullAbleDataGridViewCheckBoxColumn.HeaderText = "NA";
            this.isNullAbleDataGridViewCheckBoxColumn.Name = "isNullAbleDataGridViewCheckBoxColumn";
            this.isNullAbleDataGridViewCheckBoxColumn.Width = 27;
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "Name";
            this.nameDataGridViewTextBoxColumn.MinimumWidth = 40;
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            // 
            // OneToOne
            // 
            this.OneToOne.DataPropertyName = "OneToOne";
            this.OneToOne.HeaderText = "1 to 1";
            this.OneToOne.Name = "OneToOne";
            this.OneToOne.Text = "Edit";
            this.OneToOne.UseColumnTextForButtonValue = true;
            this.OneToOne.Width = 42;
            // 
            // OneToMany
            // 
            this.OneToMany.DataPropertyName = "OneToMany";
            this.OneToMany.HeaderText = "1 to N";
            this.OneToMany.Name = "OneToMany";
            this.OneToMany.Text = "Edit";
            this.OneToMany.UseColumnTextForButtonValue = true;
            this.OneToMany.Width = 42;
            // 
            // TableSelectionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(729, 387);
            this.Controls.Add(this.grpBoxTables);
            this.Controls.Add(this.grpBoxColumns);
            this.Controls.Add(this.btnChooseTemplates);
            this.Controls.Add(this.lblCurrentAction);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.lblSelectTables);
            this.Controls.Add(this.cmbTables);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TableSelectionForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Database Selection";
            ((System.ComponentModel.ISupportInitialize)(this.dtGridColumn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.columnBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtGridTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tableBindingSource)).EndInit();
            this.grpBoxTables.ResumeLayout(false);
            this.grpBoxColumns.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbTables;
        private System.Windows.Forms.Label lblSelectTables;
        private System.Windows.Forms.DataGridView dtGridColumn;
        private System.Windows.Forms.BindingSource columnBindingSource;
        private System.Windows.Forms.DataGridView dtGridTable;
        private System.Windows.Forms.BindingSource tableBindingSource;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label lblCurrentAction;
        private System.Windows.Forms.Button btnChooseTemplates;
        private System.Windows.Forms.GroupBox grpBoxTables;
        private System.Windows.Forms.GroupBox grpBoxColumns;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn DbType;
        private System.Windows.Forms.DataGridViewCheckBoxColumn isPKDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn isFKDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn isAIDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn isUNDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn isNullAbleDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewButtonColumn OneToOne;
        private System.Windows.Forms.DataGridViewButtonColumn OneToMany;
    }
}