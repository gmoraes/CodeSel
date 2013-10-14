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
        string OutputPath { get; set; }
        Dictionary<string, object> Parameter { get; set; }
        Configuration Configuration { get; set; }

        public TemplateProcessor(string TemplateContent, string OutputPath, Dictionary<string, object> Parameter, Configuration Configuration)
        {
            this.TemplateContent = TemplateContent;
            this.OutputPath = OutputPath;
            this.Parameter = Parameter;
            this.Configuration = Configuration;
        }

        public void ProcessTemplate()
        {
            QuickCodeSelHost host = new QuickCodeSelHost();
            host.Parameters = Parameter;
            Engine engine = new Engine();
            try
            {
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
                                throw new Exception("The file " + generatedFilePath + " exists and QuickCodeSel is not configured to overwrite!");
                            }
                        }
                    }
                    File.WriteAllText(generatedFilePath, output, host.FileEncoding);
                }
            }
            catch (Exception ex)
            {
                //Do something.
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
