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
        public static ITextTemplatingEngineHost ProcessTemplate(string TemplatePath, string OutputPath, Dictionary<string, object> Parameter)
        {
            QuickCodeSelHost host = new QuickCodeSelHost();
            host.Parameters = Parameter;
            Engine engine = new Engine();
            host.TemplateFileValue = TemplatePath;
            string input = File.ReadAllText(TemplatePath);
            string output = engine.ProcessTemplate(input, host);
            string outputFileName = Path.GetFileNameWithoutExtension(TemplatePath);
            if (host.Errors == null)
            {
                File.WriteAllText(OutputPath + "." + host.FileExtension, output, host.FileEncoding);
            }
            return host;
        }
    }
}
