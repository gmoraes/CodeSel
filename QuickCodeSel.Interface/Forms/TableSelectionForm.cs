using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Entities = QuickCodeSel.Data.Entities;

namespace QuickCodeSel.Interface
{
    public partial class TableSelectionForm : Form
    {
        Dictionary<string, List<Entities.Table>> DataDictionary;

        public TableSelectionForm(List<Entities.Database> Databases)
        {
            InitializeComponent();
            DataDictionary = new Dictionary<string, List<Entities.Table>>();
            this.cmbTables.ValueMember = "Name";
            this.cmbTables.DisplayMember = "Name";
            this.cmbTables.DataSource = Databases;
            progressBar.Step = 100;
        }

        private void cmbTables_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            string database = ((ComboBox)sender).SelectedValue.ToString();
            if (!string.IsNullOrEmpty(database))
            {
                lblCurrentAction.Text = "Loading tables for " + database + "...";
                if (!DataDictionary.ContainsKey(database))
                    DataDictionary.Add(database, Entities.Table.ListTables(database));
                dtGridTable.DataSource = DataDictionary[database];
                btnChooseTemplates.Enabled = true;
            }
            else 
            {
                btnChooseTemplates.Enabled = false;
            }
            lblCurrentAction.Text = "";
            this.Cursor = Cursors.Arrow;
        }

        private void dtGridTable_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            var lTable = (Entities.Table)dtGridTable.Rows[e.RowIndex].DataBoundItem;
            if (lTable.Columns == null)
            {
                lblCurrentAction.Text = "Loading columns for " + lTable.Name + "...";
                lTable.Columns = Entities.Column.ListColumnsByTableNameAndDbKey(lTable.Name, cmbTables.SelectedValue.ToString());
            }
            dtGridColumn.DataSource = lTable.Columns;
            lblCurrentAction.Text = "";
            this.Cursor = Cursors.Arrow;
        }

        private void btnChooseTemplates_Click(object sender, EventArgs e)
        {
            btnChooseTemplates.Enabled = false;
            btnChooseTemplates.Text = "Processing...";
            var Tables = (List<Entities.Table>)dtGridTable.DataSource;
            progressBar.Maximum = Tables.Count * 100;
            foreach (Entities.Table Table in Tables)
            {
                if (Table.Columns == null)
                {
                    lblCurrentAction.Text = "Preparing " + Table.Name + " for template generation...";
                    Table.Columns = Entities.Column.ListColumnsByTableNameAndDbKey(Table.Name, cmbTables.SelectedValue.ToString());
                }
                Table.ToOneTables = Entities.Table.ListOneToOneTables(Table.Name, cmbTables.SelectedValue.ToString());
                Table.ToManyTables = Entities.Table.ListOneToManyTables(Table.Name, cmbTables.SelectedValue.ToString());
                progressBar.PerformStep();
            }

            lblCurrentAction.Text = "Success!";
            btnChooseTemplates.Enabled = true;
            btnChooseTemplates.Text = "Choose Templates";
            this.Hide();
            TemplateSelection templateSelection = new TemplateSelection(Tables);
            templateSelection.ShowDialog();
        }
    }
}
