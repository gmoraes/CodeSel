namespace QuickCodeSel.Interface
{
    partial class ConnectionForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConnectionForm));
            this.txtConnection = new System.Windows.Forms.TextBox();
            this.lblConnection = new System.Windows.Forms.Label();
            this.lblCurrentAction = new System.Windows.Forms.Label();
            this.btnConnect = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtConnection
            // 
            this.txtConnection.Location = new System.Drawing.Point(12, 32);
            this.txtConnection.Name = "txtConnection";
            this.txtConnection.Size = new System.Drawing.Size(451, 20);
            this.txtConnection.TabIndex = 0;
            this.txtConnection.Text = "Persist Security Info=True; User ID=root;Password=root; Data Source=localhost";
            // 
            // lblConnection
            // 
            this.lblConnection.AutoSize = true;
            this.lblConnection.Location = new System.Drawing.Point(13, 13);
            this.lblConnection.Name = "lblConnection";
            this.lblConnection.Size = new System.Drawing.Size(94, 13);
            this.lblConnection.TabIndex = 1;
            this.lblConnection.Text = "Connection String:";
            // 
            // lblCurrentAction
            // 
            this.lblCurrentAction.AutoSize = true;
            this.lblCurrentAction.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentAction.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblCurrentAction.Location = new System.Drawing.Point(13, 64);
            this.lblCurrentAction.Name = "lblCurrentAction";
            this.lblCurrentAction.Size = new System.Drawing.Size(43, 13);
            this.lblCurrentAction.TabIndex = 4;
            this.lblCurrentAction.Text = "Ready";
            // 
            // btnConnect
            // 
            this.btnConnect.Image = global::QuickCodeSel.Interface.Properties.Resources._1382132604_database_connect;
            this.btnConnect.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnConnect.Location = new System.Drawing.Point(351, 55);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.btnConnect.Size = new System.Drawing.Size(112, 30);
            this.btnConnect.TabIndex = 2;
            this.btnConnect.Text = "     Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // ConnectionForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(475, 97);
            this.Controls.Add(this.lblCurrentAction);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.lblConnection);
            this.Controls.Add(this.txtConnection);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ConnectionForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Connection Form";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtConnection;
        private System.Windows.Forms.Label lblConnection;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Label lblCurrentAction;
    }
}

