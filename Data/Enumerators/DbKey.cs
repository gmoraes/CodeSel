using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QuickCodeSel.Util;

namespace QuickCodeSel.Data.Enumerators
{
    public enum DbKey : short
    {
        [AtributeSpecification("NONE")]
        None = 0,
        [AtributeSpecification("PRIMARY KEY")]
        Primary = 1,
        [AtributeSpecification("FOREIGN KEY")]
        Foreign = 2,
        [AtributeSpecification("MULTI KEY")]
        Multi = 3,
    }
}
