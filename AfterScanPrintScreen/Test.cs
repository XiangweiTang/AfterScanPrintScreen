using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace AfterScanPrintScreen
{
    public class Test
    {
        public Test() { }
        public void Run()
        {
            var bytes = File.ReadAllBytes(@"D:\Tmp\1.bmp");
            Bmp b = new Bmp();
            b.Load(bytes);
        }
    }
}
