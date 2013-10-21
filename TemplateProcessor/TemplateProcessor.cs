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
        object Data { get; set; }
        Dictionary<string, string> Parameter { get; set; }
        Configuration Configuration { get; set; }

        public TemplateProcessor(string TemplateContent, string TemplatePath, string OutputPath, Dictionary<string, string> Parameter, object Data, Configuration Configuration)
        {
            this.TemplateContent = TemplateContent;
            this.OutputPath = OutputPath;
            this.Parameter = Parameter;
            this.Data = Data;
            this.Configuration = Configuration;
            this.TemplatePath = TemplatePath;
        }

        public static string DebugTemplate(string TemplateContent, string TemplatePath, Dictionary<string, string> Parameter, object Data) 
        {
            StringBuilder Builder = new StringBuilder();
            QuickCodeSelHost host = new QuickCodeSelHost();
            host.Parameters = Parameter;
            host.Data = Data;
            Engine engine = new Engine();
            try
            {
                host.TemplateFileValue = TemplatePath;
                string output = engine.ProcessTemplate(TemplateContent, host);

                if (host.Errors == null)
                {
                    if (string.IsNullOrEmpty(output)) throw new Exception("[ERROR]The result for the template was empty. It means the error occured while excecuting the users code.");

                    else
                    {
                        Builder.AppendLine("[OK]No Errors found.");
                    }
                }
                else
                {
                    if (!host.Errors.HasErrors && host.Errors.HasWarnings)
                    {
                        Builder.AppendLine("[WARN]This template may be executed! These are the warnings: ");
                    }
                    else 
                    {
                        Builder.AppendLine("[ERROR]This template can't be executed! These are the reasons: ");
                    }

                    foreach (var error in host.Errors)
                    {
                        Builder.AppendLine("---------------------------------------------------------");
                        Builder.AppendLine(error.ToString());
                        Builder.AppendLine("---------------------------------------------------------");
                    }
                }
            }
            catch (Exception ex)
            {
                //Do something.
                Builder.AppendLine(ex.Message);
            }
            finally
            {
                host.UnloadAppDomain();
                engine = null;
                GC.Collect();
            }

            return Builder.ToString();
        }

        public string ProcessTemplate(string EntityName = "")
        {
            StringBuilder Builder = new StringBuilder();
            QuickCodeSelHost host = new QuickCodeSelHost();
            host.Parameters = Parameter;
            host.Data = this.Data;
            Engine engine = new Engine();
            try
            {
                host.TemplateFileValue = TemplatePath;
                string output = engine.ProcessTemplate(TemplateContent, host);
                string generatedFilePath = OutputPath + "." + host.FileExtension;

                if (host.Errors == null)
                {
                    if (string.IsNullOrEmpty(output)) throw new Exception("[ERROR]Error while processing template " + OutputPath + " for Entity: " + EntityName + ". Please debug the template.");
                    if (!Directory.Exists(Path.GetDirectoryName(generatedFilePath)))
                    {
                        if (Configuration.CreateDirectory)
                        {
                            Directory.CreateDirectory(Path.GetDirectoryName(generatedFilePath));
                        }
                        else
                        {
                            throw new Exception("The directory " + Path.GetDirectoryName(generatedFilePath) + " does not exist and QuickCodeSel is not configured to create a directory!");
                        }
                    }

                    if (File.Exists(generatedFilePath))
                    {
                        if (!Configuration.OnExistingOverwrite)
                        {
                            throw new Exception("The file " + generatedFilePath + " processed by " + Path.GetFileName(TemplatePath) + " exists and QuickCodeSel is not configured to overwrite! File will be not generated for the " + EntityName + " entity.");
                        }
                        else
                        {
                            if (Configuration.WarnOnExisting) Builder.AppendLine("[WARN] " + EntityName + " processed by " + Path.GetFileName(TemplatePath) + " already existed and was replaced.");
                            else Builder.AppendLine("[OK]File generated for " + EntityName + ". Processed by " + Path.GetFileName(TemplatePath) + ".");
                        }
                    }
                    else
                    {
                        Builder.AppendLine("[OK]File generated for " + EntityName + ". Processed by " + Path.GetFileName(TemplatePath) + ".");
                    }
                    File.WriteAllText(generatedFilePath, output, host.FileEncoding);
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
