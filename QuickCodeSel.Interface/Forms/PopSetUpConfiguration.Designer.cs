namespace QuickCodeSel.Interface
{
    partial class PopSetUpConfiguration
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PopSetUpConfiguration));
            this.chkOverwrite = new System.Windows.Forms.CheckBox();
            this.chkWarnOverwrite = new System.Windows.Forms.CheckBox();
            this.chkCreateDirectory = new System.Windows.Forms.CheckBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // chkOverwrite
            // 
            this.chkOverwrite.AutoSize = true;
            this.chkOverwrite.Location = new System.Drawing.Point(12, 13);
            this.chkOverwrite.Name = "chkOverwrite";
            this.chkOverwrite.Size = new System.Drawing.Size(190, 17);
            this.chkOverwrite.TabIndex = 0;
            this.chkOverwrite.Text = "Overwrite if a generated file exists?";
            this.chkOverwrite.UseVisualStyleBackColor = true;
            this.chkOverwrite.CheckedChanged += new System.EventHandler(this.chkOverwrite_CheckedChanged);
            // 
            // chkWarnOverwrite
            // 
            this.chkWarnOverwrite.AutoSize = true;
            this.chkWarnOverwrite.Location = new System.Drawing.Point(208, 13);
            this.chkWarnOverwrite.Name = "chkWarnOverwrite";
            this.chkWarnOverwrite.Size = new System.Drawing.Size(100, 17);
            this.chkWarnOverwrite.TabIndex = 1;
            this.chkWarnOverwrite.Text = "Warn if it does?";
            this.chkWarnOverwrite.UseVisualStyleBackColor = true;
            // 
            // chkCreateDirectory
            // 
            this.chkCreateDirectory.AutoSize = true;
            this.chkCreateDirectory.Location = new System.Drawing.Point(12, 36);
            this.chkCreateDirectory.Name = "chkCreateDirectory";
            this.chkCreateDirectory.Size = new System.Drawing.Size(192, 17);
            this.chkCreateDirectory.TabIndex = 2;
            this.chkCreateDirectory.Text = "Create Directory if it does\'nt existis?";
            this.chkCreateDirectory.UseVisualStyleBackColor = true;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(111, 59);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(98, 23);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // PopSetUpConfiguration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(320, 94);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.chkCreateDirectory);
            this.Controls.Add(this.chkWarnOverwrite);
            this.Controls.Add(this.chkOverwrite);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PopSetUpConfiguration";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Global Configuration";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PopSetUpConfiguration_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkOverwrite;
        private System.Windows.Forms.CheckBox chkWarnOverwrite;
        private System.Windows.Forms.CheckBox chkCreateDirectory;
        private System.Windows.Forms.Button btnClose;
    }
}