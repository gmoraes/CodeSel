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
        Dictionary<string, List<string>> TablesToMany;
        Dictionary<string, List<string>> TablesToOne;

        public TableSelectionForm(List<Entities.Database> Databases)
        {
            InitializeComponent();
            DataDictionary = new Dictionary<string, List<Entities.Table>>();
            this.cmbTables.ValueMember = "Name";
            this.cmbTables.DisplayMember = "Name";
            this.cmbTables.DataSource = Databases;
            progressBar.Step = 100;
            this.dtGridTable.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.CellContentClick);
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
                TablesToMany = Entities.Table.ListOneToManyTablesDictionary(database);
                TablesToOne = Entities.Table.ListOneToOneTablesDictionary(database);                
            }
            else
            {
                btnChooseTemplates.Enabled = false;
            }

            lblCurrentAction.Text = "";
            this.Cursor = Cursors.Arrow;
        }

        private void CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && ((DataGridView)sender).Columns[e.ColumnIndex].GetType() == typeof(DataGridViewButtonColumn))
            {
                var Tables = ((List<Entities.Table>)dtGridTable.DataSource).Select(table => (Entities.Table)table.Clone()).ToList();
                var cell = ((DataGridView)sender).Columns[e.ColumnIndex];

                switch (cell.DataPropertyName)
                {
                    case "OneToOne":
                        PopEditTables popToOne = new PopEditTables(((Entities.Table)dtGridTable.Rows[e.RowIndex].DataBoundItem).ToOneTables, Tables);
                        popToOne.ShowDialog();
                        ((Entities.Table)dtGridTable.Rows[e.RowIndex].DataBoundItem).ToOneTables = Tables.Where(table => table.Selected).ToList();
                        break;
                    case "OneToMany":
                        PopEditTables popToMany = new PopEditTables(((Entities.Table)dtGridTable.Rows[e.RowIndex].DataBoundItem).ToManyTables, Tables);
                        popToMany.ShowDialog();
                        ((Entities.Table)dtGridTable.Rows[e.RowIndex].DataBoundItem).ToManyTables = Tables.Where(table => table.Selected).ToList();
                        break;
                }
            }
        }

        private void dtGridTable_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            var lTable = (Entities.Table)dtGridTable.Rows[e.RowIndex].DataBoundItem;
            if (lTable.Columns == null)
            {
                lblCurrentAction.Text = "Loading columns for " + lTable.Name + "...";
                lTable.Columns = Entities.Column.ListColumnsByTableNameAndDbKey(lTable.Name, cmbTables.SelectedValue.ToString());
                lTable.ToManyTables = DataDictionary[cmbTables.SelectedValue.ToString()]
                    .Where(item =>
                        TablesToMany.ContainsKey(lTable.Name) ? TablesToMany[lTable.Name].Contains(item.Name) : false)
                    .ToList();

                lTable.ToOneTables = DataDictionary[cmbTables.SelectedValue.ToString()]
                    .Where(item =>
                        TablesToOne.ContainsKey(lTable.Name) ? TablesToOne[lTable.Name].Contains(item.Name) : false)
                    .ToList();
            }
            dtGridColumn.DataSource = lTable.Columns;
            lblCurrentAction.Text = "";
            this.Cursor = Cursors.Arrow;
            this.Validate();
        }

        private void btnChooseTemplates_Click(object sender, EventArgs e)
        {
            btnChooseTemplates.Enabled = false;
            btnChooseTemplates.Text = "    Processing...";
            var Tables = (List<Entities.Table>)dtGridTable.DataSource;
            progressBar.Maximum = Tables.Count * 100;
            foreach (Entities.Table Table in Tables)
            {
                if (Table.Columns == null)
                {
                    lblCurrentAction.Text = "Preparing " + Table.Name + " for template generation...";
                    Table.Columns = Entities.Column.ListColumnsByTableNameAndDbKey(Table.Name, cmbTables.SelectedValue.ToString());
                    Table.ToManyTables = DataDictionary[cmbTables.SelectedValue.ToString()]
                        .Where(item =>
                            TablesToMany.ContainsKey(Table.Name) ? TablesToMany[Table.Name].Contains(item.Name) : false)
                        .ToList();
                    Table.ToOneTables = DataDictionary[cmbTables.SelectedValue.ToString()]
                        .Where(item =>
                            TablesToOne.ContainsKey(Table.Name) ? TablesToOne[Table.Name].Contains(item.Name) : false)
                        .ToList();
                }
                //Table.ToOneTables = Entities.Table.ListOneToOneTables(Table.Name, cmbTables.SelectedValue.ToString());
                //Table.ToManyTables = Entities.Table.ListOneToManyTables(Table.Name, cmbTables.SelectedValue.ToString());
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
