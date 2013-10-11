using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuickCodeSel.TemplateProcessor
{
    public class Configuration
    {
        public bool OnExistingOverwrite { get; set; }
        public bool WarnOnExisting { get; set; }
        public bool CreateDirectory { get; set; }
    }
}
