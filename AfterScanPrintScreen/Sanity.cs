using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AfterScanPrintScreen
{
    public static class Sanity
    {
        public static void Requres(bool valid, string message)
        {
            if (!valid)
                throw new Exception(message);
        }
    }
}
