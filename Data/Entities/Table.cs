using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DB = QuickCodeSel.Data.DB;
using System.Xml.Serialization;

namespace QuickCodeSel.Data.Entities
{
    [Serializable]
    public class Table : ICloneable
    {
        public bool Selected { get; set; }
        public string Name { get; set; }
        public string CSName { get { return Util.StringHelper.ToCamelCase(this.Name); } }
        public string DBName { get; set; }
        public List<Column> Columns { get; set; }

        public List<Table> ToOneTables { get; set; }
        public List<Table> ToManyTables { get; set; }

        public List<Column> CustomList(bool? FK, bool? PK, bool? AI, bool? NA, bool? UN)
        {
            try
            {
                List<Column> cusomList = Columns;
                if (FK.HasValue) cusomList = cusomList.Where(col => FK == col.IsFK).ToList();
                if (PK.HasValue) cusomList = cusomList.Where(col => PK == col.IsPK).ToList();
                if (AI.HasValue) cusomList = cusomList.Where(col => AI == col.IsAI).ToList();
                if (NA.HasValue) cusomList = cusomList.Where(col => NA == col.IsNullAble).ToList();
                if (UN.HasValue) cusomList = cusomList.Where(col => UN == col.IsUN).ToList();
                return cusomList;
            }
            catch
            {
                return new List<Column>();
            }
        }

        public List<Column> FKList
        {
            get
            {
                try
                {
                    return Columns.Where(i => i.IsFK).ToList();
                }
                catch
                {
                    return new List<Column>();
                }
            }
        }
        public List<Column> FKPKList
        {
            get
            {
                try
                {
                    return Columns.Where(i => i.IsFK && i.IsPK).ToList();
                }
                catch
                {
                    return new List<Column>();
                }
            }
        }
        public List<Column> AIList
        {
            get
            {
                try
                {
                    return Columns.Where(i => i.IsAI).ToList();
                }
                catch
                {
                    return new List<Column>();
                }
            }
        }
        public List<Column> PKAIList
        {
            get
            {
                try
                {
                    return Columns.Where(i => i.IsAI && i.IsPK).ToList();
                }
                catch
                {
                    return new List<Column>();
                }
            }
        }
        public List<Column> PKList
        {
            get
            {
                try
                {
                    return Columns.Where(i => i.IsPK).ToList();
                }
                catch
                {
                    return new List<Column>();
                }
            }
        }
        public List<Column> UNList
        {
            get
            {
                try
                {
                    return Columns.Where(i => i.IsUN).ToList();
                }
                catch
                {
                    return new List<Column>();
                }
            }
        }
        public List<Column> NonFKList
        {
            get
            {
                try
                {
                    return Columns.Where(i => !i.IsFK).ToList();
                }
                catch
                {
                    return new List<Column>();
                }
            }
        }
        public List<Column> NonNullAble
        {
            get
            {
                try
                {
                    return Columns.Where(i => !i.IsNullAble).ToList();
                }
                catch
                {
                    return new List<Column>();
                }
            }
        }
        public List<Column> NonPKList
        {
            get
            {
                try
                {
                    return Columns.Where(i => !i.IsPK).ToList();
                }
                catch
                {
                    return new List<Column>();
                }
            }
        }
        public List<Column> ByCSharpTypeList(string Type)
        {
            try
            {
                string[] matches = Type.Split(',').Count() > 0 ? Type.Split(',') : new string[] { Type };
                return Columns.Where(i => matches.Contains(i.CSharpType)).ToList();
            }
            catch
            {
                return new List<Column>();
            }
        }
        public List<Column> ByDBTypeList(string Type)
        {
            try
            {
                string[] matches = Type.Split(',').Count() > 0 ? Type.Split(',') : new string[] { Type };
                return Columns.Where(i => matches.Contains(i.DbType)).ToList();
            }
            catch
            {
                return new List<Column>();
            }
        }

        public static string MergeColumnCSharpName(List<Column> Collection, string JoinPattern = "{0} {1}")
        {
            string mergedString = String.Join(",", Collection.Select(item => String.Format(JoinPattern, item.CSharpType, item.CSharpName)));

            return mergedString;
        }

        public static Entities.Table XmlToTable(string xml)
        {
            using (var textReader = new System.IO.StringReader(xml))
            {
                return (Entities.Table)new XmlSerializer(typeof(Entities.Table)).Deserialize(textReader);
            }
        }

        public string DescriptiveName
        {
            get
            {
                string descriptiveName = Util.StringHelper.ToCamelCase(Name, " ");
                return descriptiveName;
            }
        }

        public static List<Table> ListTables(string Database)
        {
            DB.Table DB = new DB.Table();
            return DB.ListTables(Database);
        }

        public static List<Table> ListOneToOneTables(string TableName, string Database)
        {
            DB.Table DB = new DB.Table();
            return DB.ListOneToOneTables(TableName, Database);
        }

        public static List<Table> ListOneToManyTables(string TableName, string Database)
        {
            DB.Table DB = new DB.Table();
            return DB.ListOneToManyTables(TableName, Database);
        }

        public static Dictionary<string, List<string>> ListOneToOneTablesDictionary(string Database)
        {
            DB.Table DB = new DB.Table();
            return DB.ListOneToOneTableDictionary(Database);
        }

        public static Dictionary<string, List<string>> ListOneToManyTablesDictionary(string Database)
        {
            DB.Table DB = new DB.Table();
            return DB.ListOneToManyTableDictionary(Database);
        }

        public string ToXml()
        {
            try
            {
                string xmlText;
                Type objectType = this.GetType();
                XmlSerializer xmlSerializer = new XmlSerializer(objectType);
                System.IO.MemoryStream memoryStream = new System.IO.MemoryStream();
                using (System.Xml.XmlTextWriter xmlTextWriter =
                   new System.Xml.XmlTextWriter(memoryStream, Encoding.GetEncoding("iso-8859-1")) { Formatting = System.Xml.Formatting.Indented })
                {
                    xmlSerializer.Serialize(xmlTextWriter, this);
                    memoryStream = (System.IO.MemoryStream)xmlTextWriter.BaseStream;
                    xmlText = Encoding.GetEncoding("iso-8859-1").GetString(memoryStream.ToArray());
                    memoryStream.Dispose();
                    return xmlText;
                }
            }
            catch
            {
                return null;
            }
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}