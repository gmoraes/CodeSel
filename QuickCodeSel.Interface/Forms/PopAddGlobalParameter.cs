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
    public partial class PopAddGlobalParameter : Form
    {
        public PopAddGlobalParameter()
        {
            InitializeComponent();
        }

        private void btnAddParameter_Click(object sender, EventArgs e)
        {
            lblErrorMessage.ForeColor = Color.Red;
            lblErrorMessage.Text = "";
            if (InterfaceEntities.TableTemplate.Parameters.ContainsKey(txtKey.Text))
            {
                lblErrorMessage.ForeColor = Color.Orange;
                lblErrorMessage.Text = "Parameter " + txtKey.Text + " exists. Replaced.";
                InterfaceEntities.TableTemplate.Parameters[txtKey.Text] = txtValue.Text;
            }
            else 
            {
                InterfaceEntities.TableTemplate.Parameters.Add(txtKey.Text, txtValue.Text);
                lblErrorMessage.ForeColor = Color.Green;
                lblErrorMessage.Text = "Success.";
            }
            txtKey.Text = "";
            txtValue.Text = "";
            txtKey.Focus();
        }

        private void btnClearParameters_Click(object sender, EventArgs e)
        {
            InterfaceEntities.TableTemplate.Parameters = new Dictionary<string, string>();
            lblErrorMessage.ForeColor = Color.Green;
            lblErrorMessage.Text = "Cleared.";
        }

        private void txtKey_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                btnAddParameter.PerformClick();
            }
            else if (e.KeyCode.Equals(Keys.Escape))
            {
                this.Close();
            }
        }

        private void txtValue_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                btnAddParameter.PerformClick();
            }
            else if (e.KeyCode.Equals(Keys.Escape))
            {
                this.Close();
            }
        }
    }
}
