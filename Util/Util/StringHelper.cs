using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml.Serialization;
using System.IO;
using System.Xml;

namespace QuickCodeSel.Util
{
    public static class StringHelper
    {
        public static Dictionary<string, string> BlackList = new Dictionary<string, string> { { "db", "" }, { "tb", "" }, { "cd", "Codigo" }, { "ic", "Eh" }, { "nu", "Numero" }, { "vl", "Valor" }, { "nm", "Nome" }, { "dt", "Data" }, { "ds", "Descricao" } };

        public static Dictionary<string, string> CSharpValues = new Dictionary<string, string> { { "int", "int" }, { "varchar", "string" }, { "decimal", "decimal" }, { "datetime", "DateTime" }, { "bit", "bool" }, { "tinyint", "short" }, { "char", "char" } };

        public static string ToCamelCase(string Name, string Separator = "")
        {
            string CamelCasedName = string.Empty;

            string[] parts = Name.Split('_');

            for(int i = 0 ; i<parts.Length;i++)
            {
                CamelCasedName += FirstToUpper(parts[i]) + (parts.Length -1 == i ? "" : Separator);
            }

            return CamelCasedName;
        }

        private static string FirstToUpper(string Value)
        {
            if (BlackList.Keys.Contains(Value))return BlackList[Value];
            return Value.Substring(0, 1).ToUpper() + Value.Substring(1);
        }

        #region Obsolete

        //public static string GetCommand(string Line)
        //{
        //    int start = Line.IndexOf('(') + 1
        //        , end = Line.IndexOf(')') - start;

        //    Line = Line.Substring(start, end);

        //    return Line;
        //}

        //public static string GetUnformatedLine(string Line)
        //{
        //    int start = Line.IndexOf(')') + 1
        //        , end = Line.Length - start
        //        , padCount = Line.Substring(0, Line.IndexOf("@")).Length;

        //    Line = "".PadLeft(padCount) + Line.Substring(start, end);
        //    return Line;
        //}

        //public static string AddParamSyntax(string Param)
        //{
        //    return "<%" + Param.Trim() + "%>";
        //}

        //public static string[] GetParams(string Line)
        //{
        //    Line = Line.Remove(0, Line.IndexOf("<%"));
        //    string[] Params = Line.Split(new string[] { "<%" }, StringSplitOptions.RemoveEmptyEntries);
        //    int end = 0;
        //    if (Params.Length >= 1)
        //    {
        //        for (int i = 0; i < Params.Length; i++)
        //        {
        //            end = Params[i].IndexOf("%>");
        //            Params[i] = Params[i].Substring(0, end);
        //        }
        //    }
        //    return Params;
        //}

        //public static bool IsQuickCodeSelCommand(string Line)
        //{
        //    return Line.TrimStart().StartsWith("@#");
        //}

        //public static string FormatLine(string Line, Dictionary<string, string> Dictionary, bool FirstLine, bool LastLine)
        //{
        //    string line = Line;

        //    if (!FirstLine)
        //    {
        //        line = line.Replace("f!:", "").Replace(":!f", "");
        //        line = Regex.Replace(line, @"f\:[^\:]*\:f", "");
        //    }
        //    else
        //    {
        //        line = Regex.Replace(line, @"f!\:[^\:]*\:!f", "");
        //        line = line.Replace("f:", "").Replace(":f", "");
        //    }

        //    if (!LastLine)
        //    {
        //        line = line.Replace("l!:", "").Replace(":!l", "");
        //        line = Regex.Replace(line, @"l\:[^\:]*\:l", "");
        //    }
        //    else
        //    {
        //        line = Regex.Replace(line, @"l\!\:[^\:]*\:\!l", "");
        //        line = line.Replace("l:", "").Replace(":l", "");
        //    }

        //    MatchCollection Matches = Regex.Matches(line, "{S=[0-9]}");

        //    foreach (Match Match in Matches)
        //    {
        //        int padValue = 0;
        //        int.TryParse(Regex.Replace(Match.ToString(), "[^0-9]", ""), out padValue);
        //        line = line.Replace(Match.ToString(), String.Empty.PadLeft(padValue));
        //    }

        //    Matches = Regex.Matches(line, "{T=[0-9]}");

        //    foreach (Match Match in Matches)
        //    {
        //        int padValue = 0;
        //        int.TryParse(Regex.Replace(Match.ToString(), "[^0-9]", ""), out padValue);
        //        line = line.Replace(Match.ToString(), String.Empty.PadLeft(padValue * 4));
        //    }

        //    line = line.Replace("\\n", "\n");

        //    foreach (KeyValuePair<string, string> param in Dictionary)
        //    {
        //        line = line.Replace(Util.StringHelper.AddParamSyntax(param.Key), param.Value);
        //    }

        //    return line;
        //}

        #endregion

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
