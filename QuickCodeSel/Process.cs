using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entities = QuickCodeSel.Data.Entities;
using Util = QuickCodeSel.Util;
using Host = QuickCodeSel.TemplateProcessor;
using System.IO;
using System.Configuration;
using Mono.TextTemplating;
using Microsoft.VisualStudio.TextTemplating;
using System.Xml.Serialization;
using System.Xml;

namespace QuickCodeSel.Debug
{
    class Process
    {
        public string DebugEntity { get { return File.ReadAllText(Path.GetDirectoryName(Environment.GetCommandLineArgs()[0]) + @"\DebugEntities\DebugEntity.xml"); } }
        public string DebugTemplates
        {
            get
            {
                if (!String.IsNullOrEmpty(ConfigurationSettings.AppSettings["TargetFilesUrl"])) return ConfigurationSettings.AppSettings["TargetFilesUrl"];
                else 
                {
                    throw new Exception("Set the template path in the app config in order to debug the them.");
                }
            }
        }

        public Process()
        {
            if (!File.Exists(Path.GetDirectoryName(Environment.GetCommandLineArgs()[0]) + @"\DebugEntities\DebugEntity.xml"))
            {
                throw new Exception("The file: " + Path.GetDirectoryName(Environment.GetCommandLineArgs()[0]) + @"\DebugEntities\DebugEntity.xml" + " was not found, please put it back so I can debug your templates.");
            }
            if (!Directory.Exists(DebugTemplates))
            {
                Directory.CreateDirectory(DebugTemplates);
                throw new Exception("The directory for template debuging is: " + DebugTemplates + " put your templates there");
            }
            if (Directory.EnumerateFiles(DebugTemplates).Count() == 0)
            {
                throw new Exception("There is no template to be debuged! Put files in: " + DebugTemplates);
            }
        }

        public int Debug(string[] args = null)
        {
            Object Data = Entities.Table.XmlToTable(DebugEntity);

            Dictionary<string, string> Parameters = new Dictionary<string, string>();
            Console.WriteLine("Will the templates need string parameters? yes/anything");
            if (Console.ReadLine().ToLower().Equals("yes"))
            {
                do
                {
                    Console.WriteLine("Type the Parameter Key: ");
                    var Key = Console.ReadLine();
                    Console.WriteLine("Type the Parameter Value: ");
                    var Value = Console.ReadLine();
                    if (Parameters.ContainsKey(Key)) 
                    {
                        Parameters[Key] = Value;
                        Console.WriteLine("There was a parameter with the given Key. It was replaced.");
                    }else Parameters.Add(Key, Value);
                    Console.WriteLine("Do you want to keep adding? done/anything");
                } while (!Console.ReadLine().ToLower().Equals("done"));
            }
            do
            {
                Console.Clear();

                foreach (var item in Directory.EnumerateFiles(DebugTemplates, "*.tt").ToArray())
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("Debugging file: " + Path.GetFileName(item));

                    var message = Host.TemplateProcessor.DebugTemplate(File.ReadAllText(item), item, Parameters, Data);
                    if (message.StartsWith("[ERROR]")) Console.ForegroundColor = ConsoleColor.Red;
                    else if (message.StartsWith("[WARN]")) Console.ForegroundColor = ConsoleColor.Yellow;
                    else Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(message);
                }
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Write 'finish' to end debug session or anything to run the debug again.");
            } while (!Console.ReadLine().ToLower().Equals("finish"));

            return 1;
        }
    }
}