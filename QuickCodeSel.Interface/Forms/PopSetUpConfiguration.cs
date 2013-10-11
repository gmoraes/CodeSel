using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using InterfaceEntities = QuickCodeSel.Interface.InterfaceEntities;
using Host = QuickCodeSel.TemplateProcessor;

namespace QuickCodeSel.Interface
{
    public partial class PopSetUpConfiguration : Form
    {
        List<InterfaceEntities.TableTemplate> Templates = new List<InterfaceEntities.TableTemplate>();

        public PopSetUpConfiguration(List<InterfaceEntities.TableTemplate> Templates)
        {
            InitializeComponent();
            Templates.ForEach(template => template.Configuration = template.Configuration == null ? new Host.Configuration() : template.Configuration);
            this.chkWarnOverwrite.Enabled = false;
            this.Templates = Templates;
        }

        public PopSetUpConfiguration(InterfaceEntities.TableTemplate Template)
        {
            InitializeComponent();
            Template.Configuration = Template.Configuration == null ? new Host.Configuration() : Template.Configuration;
            this.chkWarnOverwrite.Checked = Template.Configuration.WarnOnExisting;
            this.chkOverwrite.Checked = Template.Configuration.OnExistingOverwrite;
            this.chkCreateDirectory.Checked = Template.Configuration.CreateDirectory;
            this.chkWarnOverwrite.Enabled = Template.Configuration.OnExistingOverwrite;
            Templates.Add(Template);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void chkOverwrite_CheckedChanged(object sender, EventArgs e)
        {
            foreach (InterfaceEntities.TableTemplate template in Templates)
            {
                if (this.chkOverwrite.Checked)
                {
                    this.chkWarnOverwrite.Enabled = true;
                }
                else
                {
                    this.chkWarnOverwrite.Enabled = false;
                    this.chkWarnOverwrite.Checked = false;
                }
            }
        }

        private void PopSetUpConfiguration_FormClosing(object sender, FormClosingEventArgs e)
        {
            foreach (InterfaceEntities.TableTemplate template in Templates)
            {
                template.Configuration.CreateDirectory = this.chkCreateDirectory.Checked;
                template.Configuration.WarnOnExisting = this.chkWarnOverwrite.Checked;
                template.Configuration.OnExistingOverwrite = this.chkOverwrite.Checked;
            }
        }
    }
}
