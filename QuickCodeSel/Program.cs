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
            try
            {
                Process process = new Process();
                int i = process.Debug(args);
            }
            catch(Exception ex)
            {
                Console.WriteLine("ERROR: " + ex.Message);
                Console.ReadLine();
            }
            finally 
            {
                GC.Collect();
            }
        }
    }
}
