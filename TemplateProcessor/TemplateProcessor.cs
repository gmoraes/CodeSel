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
            (string TemplateContent, string TemplatePath, string OutputPath, Dictionary<string, object> Parameter, Configuration Configuration)
        {
            QuickCodeSelHost host = new QuickCodeSelHost();
            host.Parameters = Parameter;
            Engine engine = new Engine();
            host.GeneratedFilePathValue = OutputPath;
            host.TemplateFileValue = TemplatePath;
            string output = engine.ProcessTemplate(TemplateContent, host);
            if (host.Errors == null)
            {
                File.WriteAllText(host.GeneratedFilePathValue.ToString() + "." + host.FileExtension, output, host.FileEncoding);
            }
        }
    }
}
