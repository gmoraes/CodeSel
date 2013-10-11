using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entities = QuickCodeSel.Data.Entities;
using Host = QuickCodeSel.TemplateProcessor;
using System.IO;

namespace QuickCodeSel.Interface.InterfaceEntities
{
    public class TableTemplate
    {
        public static Dictionary<string, string> Parameters = new Dictionary<string, string>();
        public Host.Configuration Configuration { get; set; }

        public bool Selected { get; set; }
        public string TemplateName { get; set; }
        public string TemplatePath { get; set; }
        public string TemplateOutput { get; set; }

        public static Dictionary<string, object> ParameterFullSet(Entities.Table Table)
        {
            Dictionary<string, object> Parameters = new Dictionary<string, object>();
            Parameters.Add("Table", Table);
            foreach (var item in TableTemplate.Parameters)
            {
                Parameters.Add(item.Key, item.Value);
            }
            return Parameters;
        }

        public List<Entities.Table> Tables { get; set; }
        public List<Entities.Table> SelectedTables
        {
            get
            {
                try
                {
                    return Tables.Where(table => table.Selected).ToList();
                }
                catch
                {
                    return new List<Entities.Table>();
                }
            }
        }
    }
}
