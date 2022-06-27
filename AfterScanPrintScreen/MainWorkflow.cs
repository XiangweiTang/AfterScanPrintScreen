using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Threading;
using System.Drawing;
using System.Windows;
using System.IO;
using System.Windows.Media.Imaging;

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
            string path = @"d:\tmp\1.bmp";
            Process.Start("cmd.exe", $"/Cstart ms-settings:windowsdefender");
            // Sleep 5 seconds for the delay of window display.
            Thread.Sleep(2000);
            PressKeyHelper.PressSpecialKey("tab");
            PressKeyHelper.PressSpecialKey("enter");
            //Thread.Sleep(2000);

            //PressKeyHelper.PressSpecialKey("printscreen");
            //var image = Clipboard.GetImage();
            //var r=BitmapFrame.Create(image);

            //using (FileStream fs=new FileStream(path, FileMode.Create))
            //{
            //    BmpBitmapEncoder encoder = new BmpBitmapEncoder();
            //    encoder.Frames.Add(BitmapFrame.Create(image));
            //    encoder.Save(fs);
            //}

        }
    }
}
