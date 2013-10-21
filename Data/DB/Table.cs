using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace QuickCodeSel.Data.DB
{
    public class Table : MySqlBase
    {
        public Table(string ConnectionString) : base(ConnectionString) { }

        public Table() : base() { }

        public Entities.Table FillEntity(MySqlDataReader lDataReader) 
        {
            Entities.Table Table = new Entities.Table();
            Table.Name = FillAtribute<string>(lDataReader, "TABLE_NAME");
            Table.DBName = Connection.Database.ToString();
            return Table;
        }

        public List<Entities.Table> ListTables(string Database) 
        {
            List<Entities.Table> Collection = new List<Entities.Table>();

            StringBuilder SQL = new StringBuilder();
            SQL.AppendLine("SELECT DISTINCT TABLE_NAME ");
            SQL.AppendLine("  FROM information_schema.KEY_COLUMN_USAGE");
            SQL.AppendLine(" WHERE CONSTRAINT_SCHEMA = ?db_name");

            MySqlCommand Command = GetSqlStringCommand(SQL.ToString());

            AddInParameter(Command, "db_name", Database);

            using (MySqlDataReader DataReader = ExecuteReader(Command))
            {
                while (DataReader.Read())
                {
                    Collection.Add(this.FillEntity(DataReader));
                }
            }
            return Collection;
        }

        public List<Entities.Table> ListOneToOneTables(string TableName, string Database)
        {
            List<Entities.Table> Collection = new List<Entities.Table>();

            StringBuilder SQL = new StringBuilder();
            SQL.AppendLine(" SELECT REFERENCED_TABLE_NAME AS TABLE_NAME");
            SQL.AppendLine("   FROM information_schema.KEY_COLUMN_USAGE");
            SQL.AppendLine("  WHERE CONSTRAINT_SCHEMA = ?db_name");
            SQL.AppendLine("    AND TABLE_NAME = ?tb_name");
            SQL.AppendLine("    AND REFERENCED_TABLE_NAME IS NOT NULL;");

            MySqlCommand Command = GetSqlStringCommand(SQL.ToString());

            AddInParameter(Command, "db_name", Database);
            AddInParameter(Command, "tb_name", TableName);

            using (MySqlDataReader DataReader = ExecuteReader(Command))
            {
                while (DataReader.Read())
                {
                    Collection.Add(this.FillEntity(DataReader));
                    //return Collection;//TODO REMOVER AQUI APOS DEBUGS
                }
            }
            return Collection;
        }

        public List<Entities.Table> ListOneToManyTables(string TableName, string Database)
        {
            List<Entities.Table> Collection = new List<Entities.Table>();

            StringBuilder SQL = new StringBuilder();
            SQL.AppendLine(" SELECT TABLE_NAME");
            SQL.AppendLine("   FROM information_schema.KEY_COLUMN_USAGE");
            SQL.AppendLine("  WHERE CONSTRAINT_SCHEMA = ?db_name");
            SQL.AppendLine("    AND REFERENCED_TABLE_NAME = ?tb_name");

            MySqlCommand Command = GetSqlStringCommand(SQL.ToString());

            AddInParameter(Command, "db_name", Database);
            AddInParameter(Command, "tb_name", TableName);

            using (MySqlDataReader DataReader = ExecuteReader(Command))
            {
                while (DataReader.Read())
                {
                    Collection.Add(this.FillEntity(DataReader));
                }
            }
            return Collection;
        }

        public Dictionary<string, List<string>> ListOneToOneTableDictionary(string Database)
        {
            Dictionary<string, List<string>> Collection = new Dictionary<string, List<string>>();

            StringBuilder SQL = new StringBuilder();
            SQL.AppendLine(" SELECT TABLE_NAME,");
            SQL.AppendLine("        REFERENCED_TABLE_NAME");
            SQL.AppendLine("   FROM information_schema.KEY_COLUMN_USAGE");
            SQL.AppendLine("  WHERE CONSTRAINT_SCHEMA = ?db_name");
            SQL.AppendLine("    AND REFERENCED_TABLE_NAME IS NOT NULL;");

            MySqlCommand Command = GetSqlStringCommand(SQL.ToString());

            AddInParameter(Command, "db_name", Database);

            using (MySqlDataReader DataReader = ExecuteReader(Command))
            {
                while (DataReader.Read())
                {
                    var Key = FillAtribute<string>(DataReader, "TABLE_NAME");
                    if (!Collection.ContainsKey(Key)) 
                    {
                        Collection.Add(Key, new List<string>());
                    }
                    Collection[Key].Add(FillAtribute<string>(DataReader, "REFERENCED_TABLE_NAME"));
                }
            }
            return Collection;
        }

        public Dictionary<string, List<string>> ListOneToManyTableDictionary(string Database)
        {
            Dictionary<string, List<string>> Collection = new Dictionary<string, List<string>>();

            StringBuilder SQL = new StringBuilder();
            SQL.AppendLine(" SELECT TABLE_NAME,");
            SQL.AppendLine("        REFERENCED_TABLE_NAME");
            SQL.AppendLine("   FROM information_schema.KEY_COLUMN_USAGE");
            SQL.AppendLine("  WHERE CONSTRAINT_SCHEMA = ?db_name");
            SQL.AppendLine("    AND REFERENCED_TABLE_NAME IS NOT NULL");

            MySqlCommand Command = GetSqlStringCommand(SQL.ToString());

            AddInParameter(Command, "db_name", Database);

            using (MySqlDataReader DataReader = ExecuteReader(Command))
            {
                while (DataReader.Read())
                {
                    var Key = FillAtribute<string>(DataReader, "REFERENCED_TABLE_NAME");
                    if (!Collection.ContainsKey(Key))
                    {
                        Collection.Add(Key, new List<string>());
                    }
                    Collection[Key].Add(FillAtribute<string>(DataReader, "TABLE_NAME"));
                }
            }
            return Collection;
        }
    }
}
