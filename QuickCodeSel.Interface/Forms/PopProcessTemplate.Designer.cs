namespace QuickCodeSel.Interface
{
    partial class PopProcessTemplate
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PopProcessTemplate));
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.richTxtBoxLog = new System.Windows.Forms.RichTextBox();
            this.grpBoxStatus = new System.Windows.Forms.GroupBox();
            this.grpLog = new System.Windows.Forms.GroupBox();
            this.btnProcess = new System.Windows.Forms.Button();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.grpBoxStatus.SuspendLayout();
            this.grpLog.SuspendLayout();
            this.SuspendLayout();
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(6, 19);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(451, 57);
            this.progressBar.TabIndex = 0;
            // 
            // richTxtBoxLog
            // 
            this.richTxtBoxLog.Location = new System.Drawing.Point(6, 19);
            this.richTxtBoxLog.Name = "richTxtBoxLog";
            this.richTxtBoxLog.Size = new System.Drawing.Size(451, 115);
            this.richTxtBoxLog.TabIndex = 2;
            this.richTxtBoxLog.Text = "";
            // 
            // grpBoxStatus
            // 
            this.grpBoxStatus.Controls.Add(this.progressBar);
            this.grpBoxStatus.Location = new System.Drawing.Point(12, 12);
            this.grpBoxStatus.Name = "grpBoxStatus";
            this.grpBoxStatus.Size = new System.Drawing.Size(463, 90);
            this.grpBoxStatus.TabIndex = 3;
            this.grpBoxStatus.TabStop = false;
            this.grpBoxStatus.Text = "Progress Status";
            // 
            // grpLog
            // 
            this.grpLog.Controls.Add(this.richTxtBoxLog);
            this.grpLog.Location = new System.Drawing.Point(12, 93);
            this.grpLog.Name = "grpLog";
            this.grpLog.Size = new System.Drawing.Size(463, 140);
            this.grpLog.TabIndex = 4;
            this.grpLog.TabStop = false;
            this.grpLog.Text = "Log";
            // 
            // btnProcess
            // 
            this.btnProcess.Image = global::QuickCodeSel.Interface.Properties.Resources._1382120804_process;
            this.btnProcess.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnProcess.Location = new System.Drawing.Point(408, 239);
            this.btnProcess.Name = "btnProcess";
            this.btnProcess.Size = new System.Drawing.Size(67, 23);
            this.btnProcess.TabIndex = 1;
            this.btnProcess.Text = "    Start";
            this.btnProcess.UseVisualStyleBackColor = true;
            this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // timer
            // 
            this.timer.Interval = 250;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // PopProcessTemplate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(487, 270);
            this.Controls.Add(this.grpLog);
            this.Controls.Add(this.grpBoxStatus);
            this.Controls.Add(this.btnProcess);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PopProcessTemplate";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Processing Form";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PopProcessTemplate_FormClosing);
            this.grpBoxStatus.ResumeLayout(false);
            this.grpLog.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Button btnProcess;
        private System.Windows.Forms.RichTextBox richTxtBoxLog;
        private System.Windows.Forms.GroupBox grpBoxStatus;
        private System.Windows.Forms.GroupBox grpLog;
        private System.Windows.Forms.Timer timer;
    }
}