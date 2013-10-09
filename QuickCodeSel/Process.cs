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
        public string FilePath { get { return Path.GetDirectoryName(Environment.GetCommandLineArgs()[0]) + @"\Files"; } }

        public Process()
        {
            if (!Directory.Exists(FilePath))
            {
                Directory.CreateDirectory(FilePath);
                throw new Exception("Ponha Templates!");
            }
        }

        public int ProcessTeste()
        {
            ConfigurationSettings.AppSettings["TargetFilesUrl"] = @"C:\";
            List<Entities.Table> Tables = Entities.Table.ListTables("db_brasvalor");

            foreach (Entities.Table Table in Tables)
            {
                Table.ToOneTables = Entities.Table.ListOneToOneTables(Table.Name);
                Table.ToManyTables = Entities.Table.ListOneToManyTables(Table.Name);
                Table.Columns = Entities.Column.ListColumnsByTableNameAndDbKey(Table.Name, "db_brasvalor");

                Dictionary<string, object> Parameters = new Dictionary<string, object>();

                Parameters.Add("Table", Table);
                Parameters.Add("Namespace", "Brasvalor");

                var host = (Host.QuickCodeSelHost)Host.TemplateProcessor.ProcessTemplate(@"C:\Users\Augusto\Desktop\AmbienteT4\Dados.tt", String.Format(@"C:\Users\Augusto\Desktop\AmbienteT4\Gerados\{0}", Table.CSName), Parameters);
            }

            return 1;
        }
    }
}