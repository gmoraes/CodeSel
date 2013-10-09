using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Data;
using QuickCodeSel.Data.Enumerators;
using System.Text.RegularExpressions;
using System.Xml.Serialization;

namespace QuickCodeSel.Data.Entities
{
    [Serializable]
    public class Column
    {
        public string Name { get; set; }
        public string DbType { get; set; }
        public bool IsNullAble { get; set; }
        public bool IsPK { get; set; }
        public bool IsFK { get; set; }
        public bool IsAI { get; set; }
        public Table Table { get; set; }
        public bool IsUN { get; set; }

        public string CSharpType
        {
            get
            {
                string csharpType = Util.StringHelper.GetCSValue(DbType, Regex.Match(DbType, "[^a-zA-Z]").Success);
                return csharpType;
            }
        }

        public string CSharpName
        {
            get
            {
                string csharpType = Util.StringHelper.ToCamelCase(Name);
                return csharpType;
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

        public bool HasSizeLimit
        {
            get
            {
                try
                {
                    return Regex.Match(DbType, "[^a-zA-Z]").Success;
                }
                catch
                {
                    return false;
                }
            }
        }

        public int GetSizeLimitOrDefault(int Valor)
        {
            if (HasSizeLimit) return GetSizeLimit;
            return Valor;
        }

        public int GetSizeLimit
        {
            get
            {
                try
                {
                    string str = Regex.Replace(DbType, "[^0-9.,]", "", RegexOptions.Singleline);
                    string[] matches = str.Split(new char[] { '.', ',' }, StringSplitOptions.RemoveEmptyEntries);
                    int baseReference = 0;
                    int total = 0;

                    foreach (string match in matches)
                    {
                        total += int.TryParse(match, out baseReference) ? baseReference : 0;
                    }

                    return total;
                }
                catch
                {
                    return 0;
                }
            }
        }

        public static List<Column> ListColumnsByTableNameAndDbKey(string TableName, string Database, DbKey DbKey = DbKey.None)
        {
            DB.Column DB = new DB.Column();
            return DB.ListColumns(TableName, Database, DbKey);
        }
    }
}
