using System;
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
            this.dtGridTemplates.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.CellContentClick);
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
            var Tables = (List<InterfaceEntities.TableTemplate>)dtGridTemplates.DataSource;
            if (Tables.FirstOrDefault(item => string.IsNullOrEmpty(item.TemplateOutput)) != null)
            {
                MessageBox.Show("All templates must have an output path specified!", "Error!");
            }

            if (Tables.FirstOrDefault(item => item.SelectedTables.Count == 0) != null)
            {
                MessageBox.Show("All templates must have at least one table selected!", "Error!");
            }

            PopProcessTemplate process = new PopProcessTemplate(Tables);
            process.ShowDialog();
        }

        private void btnAddGlobalParameter_Click(object sender, EventArgs e)
        {
            PopAddGlobalParameter param = new PopAddGlobalParameter();
            param.ShowDialog();
        }

        private void btConfiguration_Click(object sender, EventArgs e)
        {
            PopSetUpConfiguration config = new PopSetUpConfiguration((List<InterfaceEntities.TableTemplate>)dtGridTemplates.DataSource);
            config.ShowDialog();
        }

        private void btnGlobalOutput_Click(object sender, EventArgs e)
        {
            folderBrowserDialog.ShowDialog();
            foreach (DataGridViewRow row in dtGridTemplates.Rows)
            {
                row.Cells["TemplateOutput"].Value = folderBrowserDialog.SelectedPath;
            }
        }
    }

    static class Extensions
    {
        public static IList<T> Clone<T>(this IList<T> listToClone) where T : ICloneable
        {
            return listToClone.Select(item => (T)item.Clone()).ToList();
        }
    }
}
