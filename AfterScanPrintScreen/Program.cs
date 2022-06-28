using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AfterScanPrintScreen
{
    internal class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            //MainWorkflow wf = new MainWorkflow();
            //wf.Run();
            new Test().Run();
        }
    }
}
