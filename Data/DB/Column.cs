using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace QuickCodeSel.Data.DB
{
    public class Column : MySqlBase
    {
        public Column(string ConnectionString) : base(ConnectionString) { }

        public Column() : base() { }

        public Entities.Column FillEntity(MySqlDataReader lDataReader)
        {
            Entities.Column Column = new Entities.Column();
            Column.Name = FillAtribute<string>(lDataReader, "TABLE_NAME");
            return Column;
        }

        public List<Entities.Column> ListColumns(string TableName, string DataBase, Enumerators.DbKey DbKey)
        {
            List<Entities.Column> Collection = new List<Entities.Column>();

            StringBuilder SQL = new StringBuilder();
            SQL.AppendLine("SELECT");
            SQL.AppendLine("      SCH.COLUMN_NAME,");
            SQL.AppendLine("      (SCH.IS_NULLABLE = 'YES')as IS_NULLABLE,");
            SQL.AppendLine("      SCH.COLUMN_TYPE,");
            SQL.AppendLine("      (SCH.COLUMN_KEY = 'PRI') as IS_PK,");
            SQL.AppendLine("      (SELECT COUNT(1)>0 FROM information_schema.KEY_COLUMN_USAGE");
            SQL.AppendLine("        WHERE CONSTRAINT_SCHEMA = ?db_name");
            SQL.AppendLine("          AND TABLE_NAME = ?tb_name");
            SQL.AppendLine("          AND COLUMN_NAME = SCH.COLUMN_NAME");
            SQL.AppendLine("          AND REFERENCED_TABLE_SCHEMA IS NOT NULL");
            SQL.AppendLine("          AND REFERENCED_TABLE_NAME IS NOT NULL");
            SQL.AppendLine("          AND REFERENCED_COLUMN_NAME IS NOT NULL) as IS_FK,");
            SQL.AppendLine("      (SCH.COLUMN_KEY = 'UN') as IS_UN,");
            SQL.AppendLine("      (SCH.EXTRA = 'auto_increment') as IS_AI");
            SQL.AppendLine("  FROM INFORMATION_SCHEMA.COLUMNS SCH");
            SQL.AppendLine(" WHERE TABLE_SCHEMA = ?db_name");
            SQL.AppendLine("   AND TABLE_NAME = ?tb_name");

            if (DbKey != Enumerators.DbKey.None)
            {
                if (DbKey != Enumerators.DbKey.Primary)
                {
                    SQL.AppendLine("   AND IS_PK = 1");
                }
                else if (DbKey != Enumerators.DbKey.Foreign)
                {
                    SQL.AppendLine("   AND IS_FK = 1");
                }
            }

            SQL.AppendLine(" ORDER BY SCH.ORDINAL_POSITION ASC");

            MySqlCommand Command = GetSqlStringCommand(SQL.ToString());

            AddInParameter(Command, "tb_name", TableName);
            AddInParameter(Command, "db_name", DataBase);

            using (MySqlDataReader DataReader = ExecuteReader(Command))
            {
                Entities.Column Column;
                while (DataReader.Read())
                {
                    Column = new Entities.Column();
                    Column.Name = this.FillAtribute<string>(DataReader, "COLUMN_NAME");
                    Column.IsNullAble = this.FillAtribute<bool>(DataReader, "IS_NULLABLE");
                    Column.DbType = this.FillAtribute<string>(DataReader, "COLUMN_TYPE");
                    Column.IsPK = this.FillAtribute<bool>(DataReader, "IS_PK");
                    Column.IsFK = this.FillAtribute<bool>(DataReader, "IS_FK");
                    Column.IsUN = this.FillAtribute<bool>(DataReader, "IS_UN");
                    Column.IsAI = this.FillAtribute<bool>(DataReader, "IS_AI");
                    Collection.Add(Column);
                }
            }
            return Collection;
        }
    }
}
