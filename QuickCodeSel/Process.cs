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
        public string FilePath { get { return Path.GetDirectoryName(Environment.GetCommandLineArgs()[0]) + @"\Debug"; } }
        public string DebugEntity { get { return File.ReadAllText(Path.GetDirectoryName(Environment.GetCommandLineArgs()[0]) + @"\DebugEntities\DebugEntity.xml"); } }

        public Process()
        {
            if (!Directory.Exists(FilePath))
            {
                Directory.CreateDirectory(FilePath);
                throw new Exception("Ponha Templates!");
            }
        }

        public int ProcessTeste(string[] args = null)
        {
            List<Entities.Table> Tables = new List<Entities.Table>();
            Tables.Add(Entities.Table.XmlToTable(DebugEntity));

            foreach (Entities.Table Table in Tables)
            {
                Dictionary<string, object> Parameters = new Dictionary<string, object>();

                Parameters.Add("Table", Table);
                Parameters.Add("Namespace", "DebugTester");

                //var host = (Host.QuickCodeSelHost)Host.TemplateProcessor.ProcessTemplate(@"C:\Users\Augusto\Desktop\AmbienteT4\Dados.tt", 
                //    String.Format(@"C:\Users\Augusto\Desktop\AmbienteT4\Gerados\{0}", Table.CSName), Parameters);
            }

            return 1;
        }
    }
}