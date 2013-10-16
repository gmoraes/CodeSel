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
        List<InterfaceEntities.TableTemplate> Tables;

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
            ThreadStart thread = new ThreadStart(Process);
            Thread thrd = new Thread(thread);
            thrd.Start();
        }

        public void Process()
        {
            foreach (InterfaceEntities.TableTemplate template in Tables)
            {
                string TemplateContent = File.ReadAllText(template.TemplatePath);
                foreach (Entities.Table table in template.SelectedTables)
                {
                    using (var Processor = new TemplateProcessor.TemplateProcessor(TemplateContent, template.TemplatePath, template.TemplateOutput.Replace("{Entity}", table.CSName), InterfaceEntities.TableTemplate.ParameterFullSet(table), template.Configuration))
                    {
                        Invoke((MethodInvoker)delegate
                        {
                            richTxtBoxLog.AppendText(Processor.ProcessTemplate(table.CSName));
                            this.progressBar.PerformStep();
                        });
                    }
                }
            }
        }
    }
}
