using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AfterScanPrintScreen
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MainWorkflow wf = new MainWorkflow();
            wf.Run();
        }
    }
}
