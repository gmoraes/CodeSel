using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Configuration;

namespace QuickCodeSel.Util
{
    public static class StringHelper
    {
        public static Dictionary<string, string> BlackList = ConfigurationSettings.AppSettings["BlackListedPrefix"].Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries).Select(part => part.Split('=')).ToDictionary(split => split[0].Trim(), split => split[1] == null ? string.Empty : split[1].Trim());//new Dictionary<string, string> { { "db", "" }, { "tb", "" }, { "cd", "Codigo" }, { "ic", "Eh" }, { "nu", "Numero" }, { "vl", "Valor" }, { "nm", "Nome" }, { "dt", "Data" }, { "ds", "Descricao" } };
        public static string[] CamelCaseSpliter = string.IsNullOrEmpty(ConfigurationSettings.AppSettings["CamelCaseSpliterArray"]) ? new string[] { "_" } : ConfigurationSettings.AppSettings["CamelCaseSpliterArray"].Split(',');
        public static Dictionary<string, string> CSharpValues = ConfigurationSettings.AppSettings["TypeReplaceList"].Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries).Select(part => part.Split('=')).ToDictionary(split => split[0].Trim(), split => split[1] == null ? string.Empty : split[1].Trim());//new Dictionary<string, string> { { "int", "int" }, { "varchar", "string" }, { "decimal", "decimal" }, { "datetime", "DateTime" }, { "bit", "bool" }, { "tinyint", "short" }, { "char", "char" } };

        public static string ToCamelCase(string Name, string Separator = "") 
        {
            if (string.IsNullOrEmpty(Name)) return string.Empty;
            string CamelCasedName = string.Empty;
            
            string[] parts = Name.Split(CamelCaseSpliter, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < parts.Length; i++)
            {
                CamelCasedName += FirstToUpper(parts[i]) + (parts.Length - 1 == i ? "" : Separator);
            }

            return String.IsNullOrEmpty(CamelCasedName) ? Name.ToUpper() : CamelCasedName;
        }

        private static string FirstToUpper(string Value)
        {
            if (BlackList.Keys.Contains(Value)) return BlackList[Value];
            return Value.Substring(0, 1).ToUpper() + Value.Substring(1);
        }

        public static string GetCSValue(string DBValue, bool ApplyCharacterOnlyRegex = false)
        {
            try
            {
                DBValue = ApplyCharacterOnlyRegex ? Regex.Replace(DBValue, "[^a-zA-Z]", "") : DBValue;
                return CSharpValues.First(dic => dic.Key.Equals(DBValue)).Value;
            }
            catch (InvalidOperationException)
            {
                return DBValue;
            }
        }
    }
}
