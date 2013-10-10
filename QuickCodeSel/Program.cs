using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace QuickCodeSel.Debug
{
    class Program
    {
        static void Main(string[] args)
        {
            Process process = new Process();
            int i = process.ProcessTeste(args);
        }
    }
}
