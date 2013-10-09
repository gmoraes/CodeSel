using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DB = QuickCodeSel.Data.DB;
using System.Xml.Serialization;

namespace QuickCodeSel.Data.Entities
{
    [Serializable]
    public class Database
    {
        public static string ConnectionString { get; set; }
        public string Name { get; set; }
        public List<Table> Tables { get; set; }

        public static Entities.Database XmlToDatabase(string xml)
        {
            using (var textReader = new System.IO.StringReader(xml))
            {
                return (Entities.Database)new XmlSerializer(typeof(Entities.Database)).Deserialize(textReader);
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

        public static List<Database> ListDatabases(string Connection)
        {
            DB.Database DB = new DB.Database(Connection);
            var Collection = DB.ListDatabases();
            Entities.Database.ConnectionString = Connection;
            return Collection;
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
    }
}