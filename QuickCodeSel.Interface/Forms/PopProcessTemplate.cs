using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using InterfaceEntities = QuickCodeSel.Interface.InterfaceEntities;
using Entities = QuickCodeSel.Data.Entities;
using System.Threading;


namespace QuickCodeSel.Interface
{
    public partial class PopProcessTemplate : Form
    {
        ThreadStart thread;
        Thread thrd;

        List<InterfaceEntities.TableTemplate> Tables;
        public Queue<string> Messages = new Queue<string>();

        public PopProcessTemplate(List<InterfaceEntities.TableTemplate> Tables)
        {
            InitializeComponent();
            this.Tables = Tables;
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            progressBar.Maximum = Tables.Sum(item => item.SelectedTables.Count);
            progressBar.Step = 1;
            progressBar.Value = 0;
            timer.Enabled = true;
            thread = new ThreadStart(Process);
            thrd = new Thread(thread);
            richTxtBoxLog.Focus();
            thrd.Start();
        }

        public void Process()
        {
            foreach (InterfaceEntities.TableTemplate template in Tables)
            {
                string TemplateContent = File.ReadAllText(template.TemplatePath);
                foreach (Entities.Table table in template.SelectedTables)
                {
                    using (var Processor = new TemplateProcessor.TemplateProcessor(TemplateContent, template.TemplatePath, template.TemplateOutput.Replace("{Entity}", table.CSName), InterfaceEntities.TableTemplate.ParameterFullSet(table), table, template.Configuration))
                    {
                        Messages.Enqueue(Processor.ProcessTemplate(table.CSName));
                    }
                }
            }
            Invoke((MethodInvoker)delegate
            {
                timer.Enabled = false;
                progressBar.Value = progressBar.Maximum;
                richTxtBoxLog.AppendText("[INFO]Finished.");
            });
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            timer.Enabled = false;
            while (Messages.Count > 0) 
            {
                richTxtBoxLog.AppendText(Messages.Dequeue());
                progressBar.PerformStep();
            }
            timer.Enabled = true;
        }

        private void PopProcessTemplate_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (thrd.IsAlive) 
            {
                thrd.Abort();
            }
        }
    }
}
