using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using InterfaceEntities = QuickCodeSel.Interface.InterfaceEntities;

namespace QuickCodeSel.Interface
{
    public partial class PopSetUpConfiguration : Form
    {
        public PopSetUpConfiguration()
        {
            InitializeComponent();

            this.chkWarnOverwrite.Checked = InterfaceEntities.Configuration.WarnOnExisting;
            this.chkOverwrite.Checked = InterfaceEntities.Configuration.OnExistingOverwrite;
            this.chkCreateDirectory.Checked = InterfaceEntities.Configuration.CreateDirectory;
            this.chkWarnOverwrite.Enabled = InterfaceEntities.Configuration.OnExistingOverwrite;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void chkOverwrite_CheckedChanged(object sender, EventArgs e)
        {
            InterfaceEntities.Configuration.OnExistingOverwrite = this.chkOverwrite.Checked;
            if (this.chkOverwrite.Checked)
            {
                InterfaceEntities.Configuration.WarnOnExisting = this.chkWarnOverwrite.Checked;
                this.chkWarnOverwrite.Enabled = true;
            }
            else
            {
                this.chkWarnOverwrite.Enabled = false;
                InterfaceEntities.Configuration.WarnOnExisting = false;
            }
        }

        private void chkWarnOverwrite_CheckedChanged(object sender, EventArgs e)
        {
            InterfaceEntities.Configuration.WarnOnExisting = this.chkWarnOverwrite.Checked;
        }

        private void chkCreateDirectory_CheckedChanged(object sender, EventArgs e)
        {
            InterfaceEntities.Configuration.CreateDirectory = this.chkCreateDirectory.Checked;
        }
    }
}
