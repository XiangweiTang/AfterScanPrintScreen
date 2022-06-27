using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Threading;

namespace AfterScanPrintScreen
{
    internal class MainWorkflow
    {
        public MainWorkflow()
        {

        }
        public void Run()
        {
            CallScanWindow();
        }
        ///
        /// The full url document can be found here: https://docs.microsoft.com/en-us/windows/uwp/launch-resume/launch-settings-app#ms-settings-uri-scheme-reference
        /// 
        /// <summary>
        /// Call the virus and threat protection window.
        /// </summary>
        private void CallScanWindow()
        {
            Thread.Sleep(5000);
            Process.Start("cmd.exe", $"/Cstart ms-settings:windowsdefender");
            // Sleep 5 seconds for the delay of window display.
            Thread.Sleep(5000);
            PressKeyHelper.PressSpecialKey("tab");
            PressKeyHelper.PressSpecialKey("enter");
            PressKeyHelper.PressSpecialKey("printscreen");
        }
    }
}
