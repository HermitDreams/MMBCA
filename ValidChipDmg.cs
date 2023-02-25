using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMBCA
{
    public enum ValidChipDmg: byte
    {
        Normal = 0,
        Last = 1,
        Rand = 2,
        All = 3,
        Delete = 4,
        Smash = 5,
        Disarm = 6,
        Return = 7
    }
}
