using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace QuickCodeSel.Data.DB
{
    public class Database : MySqlBase
    {
        public Database(string ConnectionString) : base(ConnectionString) { }

        public Database() : base() { }

        public Entities.Database FillEntity(MySqlDataReader lDataReader) 
        {
            Entities.Database Database = new Entities.Database();
            Database.Name = FillAtribute<string>(lDataReader, "CONSTRAINT_SCHEMA");
            return Database;
        }

        public List<Entities.Database> ListDatabases() 
        {
            List<Entities.Database> Collection = new List<Entities.Database>();

            StringBuilder SQL = new StringBuilder();
            SQL.AppendLine("    SELECT DISTINCT CONSTRAINT_SCHEMA");
            SQL.AppendLine("      FROM information_schema.KEY_COLUMN_USAGE");

            MySqlCommand Command = GetSqlStringCommand(SQL.ToString());

            using (MySqlDataReader DataReader = ExecuteReader(Command))
            {
                while (DataReader.Read())
                {
                    Collection.Add(this.FillEntity(DataReader));
                }
            }
            return Collection;
        }
    }
}
