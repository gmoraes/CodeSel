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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TemplateSelection));
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.dtGridTemplates = new System.Windows.Forms.DataGridView();
            this.AppendOutput = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Config = new System.Windows.Forms.DataGridViewButtonColumn();
            this.EditTables = new System.Windows.Forms.DataGridViewButtonColumn();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.btnProcessTemplate = new System.Windows.Forms.Button();
            this.btnAllTables = new System.Windows.Forms.Button();
            this.btnGlobalOutput = new System.Windows.Forms.Button();
            this.btConfiguration = new System.Windows.Forms.Button();
            this.btnAddGlobalParameter = new System.Windows.Forms.Button();
            this.btnAddTemplate = new System.Windows.Forms.Button();
            this.tableBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tableBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.lblDebug = new System.Windows.Forms.Label();
            this.TemplateName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TemplatePath = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TemplateOutput = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableTemplateBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dtGridTemplates)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tableBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tableBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tableTemplateBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // openFileDialog
            // 
            this.openFileDialog.DefaultExt = "*.tt";
            this.openFileDialog.Filter = "T4 Files (*.tt)|*tt";
            this.openFileDialog.Multiselect = true;
            // 
            // dtGridTemplates
            // 
            this.dtGridTemplates.AllowUserToAddRows = false;
            this.dtGridTemplates.AllowUserToDeleteRows = false;
            this.dtGridTemplates.AutoGenerateColumns = false;
            this.dtGridTemplates.ColumnHeadersHeight = 35;
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
            this.dtGridTemplates.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dtGridTemplates.RowHeadersVisible = false;
            this.dtGridTemplates.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
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
            this.AppendOutput.Width = 40;
            // 
            // Config
            // 
            this.Config.DataPropertyName = "Config";
            this.Config.HeaderText = "";
            this.Config.Name = "Config";
            this.Config.Text = "Edit";
            this.Config.UseColumnTextForButtonValue = true;
            this.Config.Width = 40;
            // 
            // EditTables
            // 
            this.EditTables.DataPropertyName = "EditTables";
            this.EditTables.HeaderText = "";
            this.EditTables.Name = "EditTables";
            this.EditTables.Text = "Edit";
            this.EditTables.UseColumnTextForButtonValue = true;
            this.EditTables.Width = 40;
            // 
            // btnProcessTemplate
            // 
            this.btnProcessTemplate.Image = global::QuickCodeSel.Interface.Properties.Resources._1382119585_newspaper_go;
            this.btnProcessTemplate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnProcessTemplate.Location = new System.Drawing.Point(544, 292);
            this.btnProcessTemplate.Name = "btnProcessTemplate";
            this.btnProcessTemplate.Size = new System.Drawing.Size(75, 23);
            this.btnProcessTemplate.TabIndex = 5;
            this.btnProcessTemplate.Text = "    Start";
            this.btnProcessTemplate.UseVisualStyleBackColor = true;
            this.btnProcessTemplate.Click += new System.EventHandler(this.btnProcessTemplate_Click);
            // 
            // btnAllTables
            // 
            this.btnAllTables.BackgroundImage = global::QuickCodeSel.Interface.Properties.Resources._1382110681_table_multiple;
            this.btnAllTables.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnAllTables.Location = new System.Drawing.Point(581, 15);
            this.btnAllTables.Name = "btnAllTables";
            this.btnAllTables.Size = new System.Drawing.Size(32, 32);
            this.btnAllTables.TabIndex = 9;
            this.btnAllTables.UseVisualStyleBackColor = true;
            this.btnAllTables.Click += new System.EventHandler(this.btnAllTables_Click);
            // 
            // btnGlobalOutput
            // 
            this.btnGlobalOutput.BackgroundImage = global::QuickCodeSel.Interface.Properties.Resources._1382110814_Open_file;
            this.btnGlobalOutput.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnGlobalOutput.Location = new System.Drawing.Point(503, 15);
            this.btnGlobalOutput.Name = "btnGlobalOutput";
            this.btnGlobalOutput.Size = new System.Drawing.Size(30, 32);
            this.btnGlobalOutput.TabIndex = 8;
            this.btnGlobalOutput.UseVisualStyleBackColor = true;
            this.btnGlobalOutput.Click += new System.EventHandler(this.btnGlobalOutput_Click);
            // 
            // btConfiguration
            // 
            this.btConfiguration.BackgroundImage = global::QuickCodeSel.Interface.Properties.Resources._1382111499_cog;
            this.btConfiguration.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btConfiguration.Location = new System.Drawing.Point(541, 15);
            this.btConfiguration.Name = "btConfiguration";
            this.btConfiguration.Size = new System.Drawing.Size(32, 32);
            this.btConfiguration.TabIndex = 7;
            this.btConfiguration.UseVisualStyleBackColor = true;
            this.btConfiguration.Click += new System.EventHandler(this.btConfiguration_Click);
            // 
            // btnAddGlobalParameter
            // 
            this.btnAddGlobalParameter.Image = global::QuickCodeSel.Interface.Properties.Resources._1382119321_params;
            this.btnAddGlobalParameter.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddGlobalParameter.Location = new System.Drawing.Point(118, 292);
            this.btnAddGlobalParameter.Name = "btnAddGlobalParameter";
            this.btnAddGlobalParameter.Size = new System.Drawing.Size(106, 24);
            this.btnAddGlobalParameter.TabIndex = 6;
            this.btnAddGlobalParameter.Text = "    Add Parameter";
            this.btnAddGlobalParameter.UseVisualStyleBackColor = true;
            this.btnAddGlobalParameter.Click += new System.EventHandler(this.btnAddGlobalParameter_Click);
            // 
            // btnAddTemplate
            // 
            this.btnAddTemplate.Image = global::QuickCodeSel.Interface.Properties.Resources._1382119156_document_new;
            this.btnAddTemplate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddTemplate.Location = new System.Drawing.Point(12, 292);
            this.btnAddTemplate.Name = "btnAddTemplate";
            this.btnAddTemplate.Size = new System.Drawing.Size(100, 24);
            this.btnAddTemplate.TabIndex = 3;
            this.btnAddTemplate.Text = "    Add Template";
            this.btnAddTemplate.UseVisualStyleBackColor = true;
            this.btnAddTemplate.Click += new System.EventHandler(this.btnAddTemplate_Click);
            // 
            // tableBindingSource
            // 
            this.tableBindingSource.DataSource = typeof(QuickCodeSel.Data.Entities.Table);
            // 
            // tableBindingSource1
            // 
            this.tableBindingSource1.DataSource = typeof(QuickCodeSel.Data.Entities.Table);
            // 
            // lblDebug
            // 
            this.lblDebug.AutoSize = true;
            this.lblDebug.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDebug.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.lblDebug.Location = new System.Drawing.Point(231, 298);
            this.lblDebug.Name = "lblDebug";
            this.lblDebug.Size = new System.Drawing.Size(0, 13);
            this.lblDebug.TabIndex = 10;
            // 
            // TemplateName
            // 
            this.TemplateName.DataPropertyName = "TemplateName";
            this.TemplateName.HeaderText = "Template Name";
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
            this.TemplateOutput.HeaderText = "Template Output";
            this.TemplateOutput.Name = "TemplateOutput";
            // 
            // tableTemplateBindingSource
            // 
            this.tableTemplateBindingSource.DataSource = typeof(QuickCodeSel.Interface.InterfaceEntities.TableTemplate);
            // 
            // TemplateSelection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(631, 320);
            this.Controls.Add(this.lblDebug);
            this.Controls.Add(this.btnAllTables);
            this.Controls.Add(this.btnGlobalOutput);
            this.Controls.Add(this.btConfiguration);
            this.Controls.Add(this.btnAddGlobalParameter);
            this.Controls.Add(this.btnProcessTemplate);
            this.Controls.Add(this.dtGridTemplates);
            this.Controls.Add(this.btnAddTemplate);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TemplateSelection";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Template Selection";
            ((System.ComponentModel.ISupportInitialize)(this.dtGridTemplates)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tableBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tableBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tableTemplateBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

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
        private System.Windows.Forms.Button btnGlobalOutput;
        private System.Windows.Forms.Button btnAllTables;
        private System.Windows.Forms.DataGridViewTextBoxColumn TemplateName;
        private System.Windows.Forms.DataGridViewTextBoxColumn TemplatePath;
        private System.Windows.Forms.DataGridViewTextBoxColumn TemplateOutput;
        private System.Windows.Forms.DataGridViewButtonColumn AppendOutput;
        private System.Windows.Forms.DataGridViewButtonColumn Config;
        private System.Windows.Forms.DataGridViewButtonColumn EditTables;
        private System.Windows.Forms.Label lblDebug;
    }
}