using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Data;
using QuickCodeSel;

namespace QuickCodeSel.Entities
{
    class Column
    {
        public string Name { get; set; }
        public DbType DbType { get; set; }
        public DbKey IsPK { get; set; }
        public bool IsFK { get; set; }

    }
}
