using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuickCodeSel.Interface.InterfaceEntities
{
    public static class Configuration
    {
        public static bool OnExistingOverwrite { get; set; }
        public static bool WarnOnExisting { get; set; }
        public static bool CreateDirectory { get; set; }
    }
}
