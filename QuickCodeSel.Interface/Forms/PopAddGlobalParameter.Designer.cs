namespace QuickCodeSel.Interface
{
    partial class PopAddGlobalParameter
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PopAddGlobalParameter));
            this.txtKey = new System.Windows.Forms.TextBox();
            this.txtValue = new System.Windows.Forms.TextBox();
            this.lvlKey = new System.Windows.Forms.Label();
            this.lblValue = new System.Windows.Forms.Label();
            this.btnAddParameter = new System.Windows.Forms.Button();
            this.lblErrorMessage = new System.Windows.Forms.Label();
            this.btnClearParameters = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtKey
            // 
            this.txtKey.Location = new System.Drawing.Point(97, 12);
            this.txtKey.Name = "txtKey";
            this.txtKey.Size = new System.Drawing.Size(167, 20);
            this.txtKey.TabIndex = 0;
            // 
            // txtValue
            // 
            this.txtValue.Location = new System.Drawing.Point(97, 38);
            this.txtValue.Name = "txtValue";
            this.txtValue.Size = new System.Drawing.Size(167, 20);
            this.txtValue.TabIndex = 1;
            // 
            // lvlKey
            // 
            this.lvlKey.AutoSize = true;
            this.lvlKey.Location = new System.Drawing.Point(12, 15);
            this.lvlKey.Name = "lvlKey";
            this.lvlKey.Size = new System.Drawing.Size(79, 13);
            this.lvlKey.TabIndex = 2;
            this.lvlKey.Text = "Parameter Key:";
            // 
            // lblValue
            // 
            this.lblValue.AutoSize = true;
            this.lblValue.Location = new System.Drawing.Point(3, 41);
            this.lblValue.Name = "lblValue";
            this.lblValue.Size = new System.Drawing.Size(88, 13);
            this.lblValue.TabIndex = 3;
            this.lblValue.Text = "Parameter Value:";
            // 
            // btnAddParameter
            // 
            this.btnAddParameter.Location = new System.Drawing.Point(270, 12);
            this.btnAddParameter.Name = "btnAddParameter";
            this.btnAddParameter.Size = new System.Drawing.Size(41, 45);
            this.btnAddParameter.TabIndex = 4;
            this.btnAddParameter.Text = "Add";
            this.btnAddParameter.UseVisualStyleBackColor = true;
            this.btnAddParameter.Click += new System.EventHandler(this.btnAddParameter_Click);
            // 
            // lblErrorMessage
            // 
            this.lblErrorMessage.AutoSize = true;
            this.lblErrorMessage.Font = new System.Drawing.Font("Microsoft Tai Le", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblErrorMessage.ForeColor = System.Drawing.Color.Red;
            this.lblErrorMessage.Location = new System.Drawing.Point(12, 63);
            this.lblErrorMessage.Name = "lblErrorMessage";
            this.lblErrorMessage.Size = new System.Drawing.Size(0, 14);
            this.lblErrorMessage.TabIndex = 5;
            // 
            // btnClearParameters
            // 
            this.btnClearParameters.Location = new System.Drawing.Point(270, 63);
            this.btnClearParameters.Name = "btnClearParameters";
            this.btnClearParameters.Size = new System.Drawing.Size(41, 20);
            this.btnClearParameters.TabIndex = 6;
            this.btnClearParameters.Text = "Clear";
            this.btnClearParameters.UseVisualStyleBackColor = true;
            this.btnClearParameters.Click += new System.EventHandler(this.btnClearParameters_Click);
            // 
            // PopAddGlobalParameter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(323, 89);
            this.Controls.Add(this.btnClearParameters);
            this.Controls.Add(this.lblErrorMessage);
            this.Controls.Add(this.btnAddParameter);
            this.Controls.Add(this.lblValue);
            this.Controls.Add(this.lvlKey);
            this.Controls.Add(this.txtValue);
            this.Controls.Add(this.txtKey);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PopAddGlobalParameter";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Global Parameters";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtKey;
        private System.Windows.Forms.TextBox txtValue;
        private System.Windows.Forms.Label lvlKey;
        private System.Windows.Forms.Label lblValue;
        private System.Windows.Forms.Button btnAddParameter;
        private System.Windows.Forms.Label lblErrorMessage;
        private System.Windows.Forms.Button btnClearParameters;
    }
}