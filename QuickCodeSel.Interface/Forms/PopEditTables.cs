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
    public partial class PopEditTables : Form
    {
        List<Entities.Table> SelectedTables;

        public PopEditTables(List<Entities.Table> Tables)
        {
            InitializeComponent();
            dtGridTablesTemplate.DataSource = Tables;
        }

        public PopEditTables(List<Entities.Table> SelectedTables, List<Entities.Table> AllTables)
        {
            InitializeComponent();
            this.SelectedTables = SelectedTables;
            AllTables.ForEach(table => table.Selected = SelectedTables.Select<Entities.Table, string>(item => item.Name).ToArray().Contains(table.Name));
            dtGridTablesTemplate.DataSource = AllTables;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void chkAllTables_CheckedChanged(object sender, EventArgs e)
        {
            var tables = ((List<Entities.Table>)dtGridTablesTemplate.DataSource);
            foreach(Entities.Table table in tables)
            {
                table.Selected = this.chkAllTables.Checked;
            }
            dtGridTablesTemplate.Refresh();
        }
    }
}
