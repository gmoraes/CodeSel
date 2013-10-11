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
            this.AppendOutput = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Config = new System.Windows.Forms.DataGridViewButtonColumn();
            this.EditTables = new System.Windows.Forms.DataGridViewButtonColumn();
            this.tableBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.btnProcessTemplate = new System.Windows.Forms.Button();
            this.btnAddGlobalParameter = new System.Windows.Forms.Button();
            this.btConfiguration = new System.Windows.Forms.Button();
            this.TemplateName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TemplatePath = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TemplateOutput = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableTemplateBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnGlobalOutput = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.tableBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtGridTemplates)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tableBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tableTemplateBindingSource)).BeginInit();
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
            this.Config,
            this.EditTables});
            this.dtGridTemplates.DataSource = this.tableTemplateBindingSource;
            this.dtGridTemplates.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dtGridTemplates.Location = new System.Drawing.Point(12, 12);
            this.dtGridTemplates.MultiSelect = false;
            this.dtGridTemplates.Name = "dtGridTemplates";
            this.dtGridTemplates.RowHeadersVisible = false;
            this.dtGridTemplates.Size = new System.Drawing.Size(607, 276);
            this.dtGridTemplates.TabIndex = 4;
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
            // Config
            // 
            this.Config.DataPropertyName = "Config";
            this.Config.HeaderText = "";
            this.Config.Name = "Config";
            this.Config.Text = "Config.";
            this.Config.UseColumnTextForButtonValue = true;
            this.Config.Width = 30;
            // 
            // EditTables
            // 
            this.EditTables.DataPropertyName = "EditTables";
            this.EditTables.HeaderText = "";
            this.EditTables.Name = "EditTables";
            this.EditTables.Text = "Tables";
            this.EditTables.UseColumnTextForButtonValue = true;
            this.EditTables.Width = 40;
            // 
            // tableBindingSource1
            // 
            this.tableBindingSource1.DataSource = typeof(QuickCodeSel.Data.Entities.Table);
            // 
            // btnProcessTemplate
            // 
            this.btnProcessTemplate.Location = new System.Drawing.Point(544, 292);
            this.btnProcessTemplate.Name = "btnProcessTemplate";
            this.btnProcessTemplate.Size = new System.Drawing.Size(75, 23);
            this.btnProcessTemplate.TabIndex = 5;
            this.btnProcessTemplate.Text = "Start";
            this.btnProcessTemplate.UseVisualStyleBackColor = true;
            this.btnProcessTemplate.Click += new System.EventHandler(this.btnProcessTemplate_Click);
            // 
            // btnAddGlobalParameter
            // 
            this.btnAddGlobalParameter.Location = new System.Drawing.Point(108, 292);
            this.btnAddGlobalParameter.Name = "btnAddGlobalParameter";
            this.btnAddGlobalParameter.Size = new System.Drawing.Size(89, 24);
            this.btnAddGlobalParameter.TabIndex = 6;
            this.btnAddGlobalParameter.Text = "Add Parameter";
            this.btnAddGlobalParameter.UseVisualStyleBackColor = true;
            this.btnAddGlobalParameter.Click += new System.EventHandler(this.btnAddGlobalParameter_Click);
            // 
            // btConfiguration
            // 
            this.btConfiguration.Location = new System.Drawing.Point(549, 13);
            this.btConfiguration.Name = "btConfiguration";
            this.btConfiguration.Size = new System.Drawing.Size(27, 20);
            this.btConfiguration.TabIndex = 7;
            this.btConfiguration.Text = "Configuration";
            this.btConfiguration.UseVisualStyleBackColor = true;
            this.btConfiguration.Click += new System.EventHandler(this.btConfiguration_Click);
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
            // tableTemplateBindingSource
            // 
            this.tableTemplateBindingSource.DataSource = typeof(QuickCodeSel.Interface.InterfaceEntities.TableTemplate);
            // 
            // btnGlobalOutput
            // 
            this.btnGlobalOutput.Location = new System.Drawing.Point(526, 13);
            this.btnGlobalOutput.Name = "btnGlobalOutput";
            this.btnGlobalOutput.Size = new System.Drawing.Size(21, 20);
            this.btnGlobalOutput.TabIndex = 8;
            this.btnGlobalOutput.Text = "...";
            this.btnGlobalOutput.UseVisualStyleBackColor = true;
            this.btnGlobalOutput.Click += new System.EventHandler(this.btnGlobalOutput_Click);
            // 
            // TemplateSelection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(631, 320);
            this.Controls.Add(this.btnGlobalOutput);
            this.Controls.Add(this.btConfiguration);
            this.Controls.Add(this.btnAddGlobalParameter);
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
            ((System.ComponentModel.ISupportInitialize)(this.tableBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tableTemplateBindingSource)).EndInit();
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
        private System.Windows.Forms.Button btnProcessTemplate;
        private System.Windows.Forms.Button btnAddGlobalParameter;
        private System.Windows.Forms.Button btConfiguration;
        private System.Windows.Forms.DataGridViewTextBoxColumn TemplateName;
        private System.Windows.Forms.DataGridViewTextBoxColumn TemplatePath;
        private System.Windows.Forms.DataGridViewTextBoxColumn TemplateOutput;
        private System.Windows.Forms.DataGridViewButtonColumn AppendOutput;
        private System.Windows.Forms.DataGridViewButtonColumn Config;
        private System.Windows.Forms.DataGridViewButtonColumn EditTables;
        private System.Windows.Forms.Button btnGlobalOutput;
    }
}