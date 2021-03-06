﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using Entities = QuickCodeSel.Data.Entities;
using Host = QuickCodeSel.TemplateProcessor;

namespace QuickCodeSel.Interface
{
    public partial class TemplateSelection : Form
    {
        List<Entities.Table> Tables;
        private string DebugEntityPath { get { return Path.GetDirectoryName(Environment.GetCommandLineArgs()[0]) + @"\DebugEntities\DebugEntity.xml"; } }
        public string DebugEntity { get { try { return File.ReadAllText(Path.GetDirectoryName(Environment.GetCommandLineArgs()[0]) + @"\DebugEntities\DebugEntity.xml"); } catch { return ""; } } }

        public TemplateSelection(List<Entities.Table> Tables)
        {
            Tables.ForEach(item => item.Selected = true);
            this.Tables = Tables;
            InitializeComponent();
            openFileDialog.InitialDirectory = Path.GetDirectoryName(Environment.GetCommandLineArgs()[0]);
            if (!Directory.Exists(Path.GetDirectoryName(Environment.GetCommandLineArgs()[0]) + @"\Templates"))
            {
                Directory.CreateDirectory(Path.GetDirectoryName(Environment.GetCommandLineArgs()[0]) + @"\Templates");
            }
            this.dtGridTemplates.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.CellContentClick);
        }

        private void btnAddTemplate_Click(object sender, EventArgs e)
        {
            openFileDialog.Filter = "T4 Files (*.tt)|*tt";
            openFileDialog.ShowDialog();
            var files = openFileDialog.FileNames;
            FillDataGridTemplates(files);
        }

        public void FillDataGridTemplates(string[] Templates)
        {
            if (Templates.Count() > 0)
            {
                List<InterfaceEntities.TableTemplate> Collection = new List<InterfaceEntities.TableTemplate>();
                foreach (var template in Templates)
                {
                    var item = new InterfaceEntities.TableTemplate();
                    item.TemplateName = Path.GetFileName(template);
                    item.TemplatePath = template;
                    item.Tables = Tables.Select(table => (Entities.Table)table.Clone()).ToList();
                    item.Configuration = new Host.Configuration() { CreateDirectory = true, OnExistingOverwrite = true };
                    Collection.Add(item);
                }
                dtGridTemplates.DataSource = Collection;
            }
        }

        private void CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && ((DataGridView)sender).Columns[e.ColumnIndex].GetType() == typeof(DataGridViewButtonColumn))
            {
                var cell = ((DataGridView)sender).Columns[e.ColumnIndex];
                switch (cell.DataPropertyName)
                {
                    case "EditTables":
                        PopEditTables pop = new PopEditTables(((InterfaceEntities.TableTemplate)dtGridTemplates.Rows[e.RowIndex].DataBoundItem).Tables);
                        pop.ShowDialog();
                        break;
                    case "Config":
                        PopSetUpConfiguration config = new PopSetUpConfiguration((InterfaceEntities.TableTemplate)dtGridTemplates.Rows[e.RowIndex].DataBoundItem);
                        config.ShowDialog();
                        break;
                    case "AppendOutput":
                        folderBrowserDialog.ShowDialog();
                        dtGridTemplates.Rows[e.RowIndex].Cells["TemplateOutput"].Value = folderBrowserDialog.SelectedPath + @"\{Entity}";
                        break;
                }
            }
        }

        private void btnProcessTemplate_Click(object sender, EventArgs e)
        {
            var tableTemplate = new List<InterfaceEntities.TableTemplate>();
            if (dtGridViewTryCast<List<InterfaceEntities.TableTemplate>>(out tableTemplate))
            {
                if (tableTemplate.FirstOrDefault(item => string.IsNullOrEmpty(item.TemplateOutput)) != null)
                {
                    MessageBox.Show("All templates must have an output path specified!", "Error!");
                    return;
                }

                if (tableTemplate.FirstOrDefault(item => item.SelectedTables.Count == 0) != null)
                {
                    MessageBox.Show("All templates must have at least one table selected!", "Error!");
                    return;
                }

                foreach (var table in tableTemplate)
                {
                    if (!File.Exists(table.TemplatePath))
                    {
                        MessageBox.Show(String.Format("The template {0} does not exist anymore.\nIt must have been deleted or the application lacks the necessary permissions to access it.", table.TemplatePath),"Error!");
                        return;                    
                    }
                    if (!table.TemplateOutput.Contains("{Entity}")) 
                    {
                        MessageBox.Show(String.Format("The template {0} does not contain the directive Entity between braces. Without it the generated files will always be overwritten.", table.TemplateOutput), "Error!");
                        return;
                    }
                }

                if (MessageBox.Show("Would you like to debug the templates before processing them?", "Warning!", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    if (string.IsNullOrEmpty(DebugEntity))
                    {
                        MessageBox.Show("The DebugEntity that should be in " + DebugEntityPath + " is either empty or not there. Please verify!", "Error!");
                        return;
                    }
                    StringBuilder Builder = new StringBuilder();
                    foreach (var table in tableTemplate)
                    {
                        lblDebug.Text = "Debugging " + Path.GetFileName(table.TemplatePath) + "...";
                        if (Host.TemplateProcessor.HasCompilationError(
                                File.ReadAllText(table.TemplatePath),
                                table.TemplatePath,
                                InterfaceEntities.TableTemplate.Parameters,
                                Entities.Table.XmlToTable(DebugEntity)))
                        {
                            Builder.AppendLine(Path.GetFileName(table.TemplatePath) + ",");
                        }
                    }
                    lblDebug.Text = "";
                    if (!string.IsNullOrEmpty(Builder.ToString()))
                    {
                        MessageBox.Show("The Templates: " + Builder.ToString() + " contain errors! Use the debugger: QuickCodeSel.exe for details.", "Error!");
                        return;
                    }
                }

                PopProcessTemplate process = new PopProcessTemplate(tableTemplate);
                process.ShowDialog();
            }
            else
            {
                MessageBox.Show("You have to select at least one template!", "Error!");
            }
        }

        private void btnAddGlobalParameter_Click(object sender, EventArgs e)
        {
            PopAddGlobalParameter param = new PopAddGlobalParameter();
            param.ShowDialog();
        }

        private void btConfiguration_Click(object sender, EventArgs e)
        {
            var tableTemplate = new List<InterfaceEntities.TableTemplate>();
            if (dtGridViewTryCast<List<InterfaceEntities.TableTemplate>>(out tableTemplate))
            {
                PopSetUpConfiguration config = new PopSetUpConfiguration(tableTemplate);
                config.ShowDialog();
            }
        }

        private void btnGlobalOutput_Click(object sender, EventArgs e)
        {
            folderBrowserDialog.ShowDialog();
            foreach (DataGridViewRow row in dtGridTemplates.Rows)
            {
                string concat = string.Empty;
                try
                {
                    if (!File.Exists(row.Cells["TemplatePath"].Value.ToString()))
                    {
                        MessageBox.Show(String.Format("The template {0} does not exist anymore.\nIt must have been deleted or the application lacks the necessary permissions to access it.", row.Cells["TemplatePath"].Value.ToString()), "Error!");
                        continue;
                    }
                    row.Cells["TemplateOutput"].Value = folderBrowserDialog.SelectedPath;
                    var content = String.Concat(File.ReadAllText(row.Cells["TemplatePath"].Value.ToString()).Split('\n').Where(line => line.StartsWith("<#@")));
                    var index = content.IndexOf("appendPath=\"");
                    if (index > 0)
                    {
                        try
                        {
                            content = content.Substring(index).Replace("appendPath=\"", "");
                            concat = content.Substring(0, content.IndexOf("\""));
                            concat = concat.StartsWith("\\") ? concat : "\\" + concat;
                        }
                        catch
                        {
                            concat = string.Empty;
                        }
                    }
                }
                finally
                {
                    row.Cells["TemplateOutput"].Value = String.Concat(folderBrowserDialog.SelectedPath, concat);
                }
            }
        }

        private void btnAllTables_Click(object sender, EventArgs e)
        {
            var tableTemplate = new List<InterfaceEntities.TableTemplate>();
            if (dtGridViewTryCast<List<InterfaceEntities.TableTemplate>>(out tableTemplate))
            {
                var tables = this.Tables.Select(table => (Entities.Table)table.Clone()).ToList();
                PopEditTables popTables = new PopEditTables(tables);
                popTables.ShowDialog();
                tableTemplate.ForEach(tableTemp => tableTemp.Tables = tables.Select(table => (Entities.Table)table.Clone()).ToList());
            }
            else
            {
                MessageBox.Show("You have to select at least one template to edit all tables!", "Error!");
            }
        }

        private bool dtGridViewTryCast<T>(out T Obj)
        {
            try
            {
                Obj = (T)dtGridTemplates.DataSource;
                return true;
            }
            catch
            {
                Obj = default(T);
                return false;
            }
        }
    }
}
