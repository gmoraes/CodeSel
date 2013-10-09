namespace QuickCodeSel.Interface
{
    partial class TemplateSelection
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
            this.tableBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.btnAddTemplate = new System.Windows.Forms.Button();
            this.dtGridTemplates = new System.Windows.Forms.DataGridView();
            this.TemplateName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TemplatePath = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TemplateOutput = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AppendOutput = new System.Windows.Forms.DataGridViewButtonColumn();
            this.EditTables = new System.Windows.Forms.DataGridViewButtonColumn();
            this.tableTemplateBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tableBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.btnProcessTemplate = new System.Windows.Forms.Button();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.tableBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtGridTemplates)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tableTemplateBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tableBindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // tableBindingSource
            // 
            this.tableBindingSource.DataSource = typeof(QuickCodeSel.Data.Entities.Table);
            // 
            // openFileDialog
            // 
            this.openFileDialog.DefaultExt = "*.tt";
            this.openFileDialog.Filter = "T4 Files (*.tt)|*tt";
            this.openFileDialog.Multiselect = true;
            // 
            // btnAddTemplate
            // 
            this.btnAddTemplate.Location = new System.Drawing.Point(12, 292);
            this.btnAddTemplate.Name = "btnAddTemplate";
            this.btnAddTemplate.Size = new System.Drawing.Size(90, 24);
            this.btnAddTemplate.TabIndex = 3;
            this.btnAddTemplate.Text = "Add Template";
            this.btnAddTemplate.UseVisualStyleBackColor = true;
            this.btnAddTemplate.Click += new System.EventHandler(this.btnAddTemplate_Click);
            // 
            // dtGridTemplates
            // 
            this.dtGridTemplates.AllowUserToAddRows = false;
            this.dtGridTemplates.AllowUserToDeleteRows = false;
            this.dtGridTemplates.AutoGenerateColumns = false;
            this.dtGridTemplates.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtGridTemplates.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TemplateName,
            this.TemplatePath,
            this.TemplateOutput,
            this.AppendOutput,
            this.EditTables});
            this.dtGridTemplates.DataSource = this.tableTemplateBindingSource;
            this.dtGridTemplates.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dtGridTemplates.Location = new System.Drawing.Point(12, 12);
            this.dtGridTemplates.MultiSelect = false;
            this.dtGridTemplates.Name = "dtGridTemplates";
            this.dtGridTemplates.RowHeadersVisible = false;
            this.dtGridTemplates.Size = new System.Drawing.Size(527, 276);
            this.dtGridTemplates.TabIndex = 4;
            // 
            // TemplateName
            // 
            this.TemplateName.DataPropertyName = "TemplateName";
            this.TemplateName.HeaderText = "TemplateName";
            this.TemplateName.Name = "TemplateName";
            this.TemplateName.ReadOnly = true;
            this.TemplateName.Width = 150;
            // 
            // TemplatePath
            // 
            this.TemplatePath.DataPropertyName = "TemplatePath";
            this.TemplatePath.HeaderText = "TemplatePath";
            this.TemplatePath.Name = "TemplatePath";
            this.TemplatePath.ReadOnly = true;
            this.TemplatePath.Visible = false;
            // 
            // TemplateOutput
            // 
            this.TemplateOutput.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.TemplateOutput.DataPropertyName = "TemplateOutput";
            this.TemplateOutput.HeaderText = "TemplateOutput";
            this.TemplateOutput.Name = "TemplateOutput";
            // 
            // AppendOutput
            // 
            this.AppendOutput.DataPropertyName = "AppendOutput";
            this.AppendOutput.HeaderText = "";
            this.AppendOutput.Name = "AppendOutput";
            this.AppendOutput.Text = "...";
            this.AppendOutput.UseColumnTextForButtonValue = true;
            this.AppendOutput.Width = 20;
            // 
            // EditTables
            // 
            this.EditTables.DataPropertyName = "EditTables";
            this.EditTables.HeaderText = "";
            this.EditTables.Name = "EditTables";
            this.EditTables.Text = "Edit";
            this.EditTables.UseColumnTextForButtonValue = true;
            this.EditTables.Width = 30;
            // 
            // tableTemplateBindingSource
            // 
            this.tableTemplateBindingSource.DataSource = typeof(QuickCodeSel.Interface.InterfaceEntities.TableTemplate);
            // 
            // tableBindingSource1
            // 
            this.tableBindingSource1.DataSource = typeof(QuickCodeSel.Data.Entities.Table);
            // 
            // btnProcessTemplate
            // 
            this.btnProcessTemplate.Location = new System.Drawing.Point(464, 292);
            this.btnProcessTemplate.Name = "btnProcessTemplate";
            this.btnProcessTemplate.Size = new System.Drawing.Size(75, 23);
            this.btnProcessTemplate.TabIndex = 5;
            this.btnProcessTemplate.Text = "Start";
            this.btnProcessTemplate.UseVisualStyleBackColor = true;
            this.btnProcessTemplate.Click += new System.EventHandler(this.btnProcessTemplate_Click);
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(108, 292);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(350, 24);
            this.progressBar.TabIndex = 6;
            // 
            // TemplateSelection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(549, 320);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.btnProcessTemplate);
            this.Controls.Add(this.dtGridTemplates);
            this.Controls.Add(this.btnAddTemplate);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TemplateSelection";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Template Selection";
            ((System.ComponentModel.ISupportInitialize)(this.tableBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtGridTemplates)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tableTemplateBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tableBindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource tableBindingSource;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Button btnAddTemplate;
        private System.Windows.Forms.DataGridView dtGridTemplates;
        private System.Windows.Forms.BindingSource tableBindingSource1;
        private System.Windows.Forms.BindingSource tableTemplateBindingSource;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.DataGridViewTextBoxColumn TemplateName;
        private System.Windows.Forms.DataGridViewTextBoxColumn TemplatePath;
        private System.Windows.Forms.DataGridViewTextBoxColumn TemplateOutput;
        private System.Windows.Forms.DataGridViewButtonColumn AppendOutput;
        private System.Windows.Forms.DataGridViewButtonColumn EditTables;
        private System.Windows.Forms.Button btnProcessTemplate;
        private System.Windows.Forms.ProgressBar progressBar;
    }
}