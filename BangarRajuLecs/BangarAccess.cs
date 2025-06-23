using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BangarRajuLecs
{
     class BangarAccess : Program
    {
        static void Main(string[] args)
        {
            BangarAccess acc = new BangarAccess();
            acc.protectedAccessSpecifiers();
            acc.privateprotectedAccessSpecifiers();
            acc.protectedinternalAccessSpecifiers();
            acc.pubAccessSpecifiers();
        }
    }
}
