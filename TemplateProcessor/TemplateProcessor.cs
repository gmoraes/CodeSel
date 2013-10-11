using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Microsoft.VisualStudio.TextTemplating;

namespace QuickCodeSel.TemplateProcessor
{
    public static class TemplateProcessor
    {
        public static void ProcessTemplate
            (string TemplateContent, string OutputPath, Dictionary<string, object> Parameter, Configuration Configuration)
        {
            QuickCodeSelHost host = new QuickCodeSelHost();
            host.Parameters = Parameter;
            Engine engine = new Engine();
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
    }
}
