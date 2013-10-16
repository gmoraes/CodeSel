using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Microsoft.VisualStudio.TextTemplating;

namespace QuickCodeSel.TemplateProcessor
{
    public class TemplateProcessor : IDisposable
    {
        string TemplateContent { get; set; }
        string TemplatePath { get; set; }
        string OutputPath { get; set; }
        Dictionary<string, object> Parameter { get; set; }
        Configuration Configuration { get; set; }

        public TemplateProcessor(string TemplateContent, string TemplatePath, string OutputPath, Dictionary<string, object> Parameter, Configuration Configuration)
        {
            this.TemplateContent = TemplateContent;
            this.OutputPath = OutputPath;
            this.Parameter = Parameter;
            this.Configuration = Configuration;
            this.TemplatePath = TemplatePath;
        }

        public string ProcessTemplate(string EntityName = "")
        {
            StringBuilder Builder = new StringBuilder();
            QuickCodeSelHost host = new QuickCodeSelHost();
            host.Parameters = Parameter;
            Engine engine = new Engine();
            try
            {
                host.TemplateFileValue = TemplatePath;
                string output = engine.ProcessTemplate(TemplateContent, host);
                string generatedFilePath = OutputPath + "." + host.FileExtension;

                if (host.Errors == null)
                {
                    if (!Directory.Exists(Path.GetDirectoryName(generatedFilePath)))
                    {
                        if (Configuration.CreateDirectory)
                        {
                            Directory.CreateDirectory(Path.GetDirectoryName(generatedFilePath));
                        }
                    }
                    else
                    {
                        if (File.Exists(generatedFilePath))
                        {
                            if (!Configuration.OnExistingOverwrite)
                            {
                                throw new Exception("The file " + generatedFilePath + " processed by " + Path.GetFileName(TemplatePath) + " exists and QuickCodeSel is not configured to overwrite! File will be not generated for the " + EntityName + " entity.");
                            }
                            else
                            {
                                if (Configuration.WarnOnExisting) Builder.AppendLine("[WARN] " + EntityName + " processed by " + Path.GetFileName(TemplatePath) + " already existed and was replaced.");
                            }
                        }
                    }
                    File.WriteAllText(generatedFilePath, output, host.FileEncoding);
                    Builder.AppendLine("[OK]File generated for " + EntityName + ". Processed by " + Path.GetFileName(TemplatePath) + ".");
                }
                else
                {
                    foreach (var error in host.Errors)
                    {
                        Builder.AppendLine(error.ToString());
                    }
                }
                return Builder.ToString();
            }
            catch (Exception ex)
            {
                //Do something.
                return ex.Message;
            }
            finally
            {
                host.UnloadAppDomain();
                engine = null;
                GC.Collect();
            }
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
