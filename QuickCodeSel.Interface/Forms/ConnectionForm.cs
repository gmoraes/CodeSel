﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Entities = QuickCodeSel.Data.Entities;

namespace QuickCodeSel.Interface
{
    public partial class ConnectionForm : Form
    {
        public ConnectionForm()
        {
            InitializeComponent();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                btnConnect.Enabled = false;
                btnConnect.Text = "         Connecting...";
                lblCurrentAction.ForeColor = Color.Blue;
                lblCurrentAction.Text = "Gathering information from server...";
                List<Entities.Database> Databases = Entities.Database.ListDatabases(txtConnection.Text);
                lblCurrentAction.ForeColor = Color.Green;
                lblCurrentAction.Text = "Success!";
                TableSelectionForm tableSelection = new TableSelectionForm(Databases);
                this.Hide();
                tableSelection.ShowDialog();
                this.Close();
            }
            catch(Exception ex)
            {
                this.Show();
                if (ex.GetType().ToString().Contains("MySqlException")) 
                {
                    lblCurrentAction.ForeColor = Color.Red;
                    lblCurrentAction.Text = "Invalid connection string. Please verify."; 
                }
                else
                {
                    MessageBox.Show("Error trying to gather information.\nReason: " + ex.Message + "\nStackTrace: " + ex.StackTrace);
                }
            }
            finally 
            {
                btnConnect.Enabled = true;
                btnConnect.Text = "Connect";
                this.Cursor = Cursors.Arrow;
            }
        }

        private void txtConnection_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode.Equals(Keys.Enter))
            {
                btnConnect.PerformClick();
            }
            else if (e.KeyCode.Equals(Keys.Escape)) 
            {
                this.Close();
            }
        }
    }
}
