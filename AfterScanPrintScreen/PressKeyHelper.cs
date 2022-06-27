using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Drawing;
using System.Diagnostics;
using System.Threading;

namespace AfterScanPrintScreen
{
    internal static class PressKeyHelper
    {
        ///
        /// The full key-code mapping table is in "Data\KeyCode.txt".
        ///

        /// <summary>
        /// Call the external functions.
        /// </summary>
        /// <param name="bVk"></param>
        /// <param name="bScan"></param>
        /// <param name="dwFlags"></param>
        /// <param name="dwExtraInfo"></param>
        [DllImport("user32.dll")]
        static extern void keybd_event(byte bVk, byte bScan, int dwFlags, int dwExtraInfo);
        [DllImport("user32.dll")]
        private static extern IntPtr FindWindow(string className, string windowName);

        [DllImport("user32.dll")]
        private static extern int GetWindowRect(IntPtr hwnd, out Rectangle rect);
        private const int KEY_DOWN_FLAG = 0x0001;
        private const int KEY_UP_FLAG = 0x0002;
        public static void PressSpecialKey(string key)
        {
            PressKey(SpecialKeyBytes[key]);
        }
        public static void PressKey(char letterChar)
        {
            if (('A' <= letterChar && letterChar <= 'Z') ||
                ('0' <= letterChar && letterChar <= '9'))
            {
                PressKey((byte)letterChar);
                return;
            }
            if ('a' <= letterChar && letterChar <= 'z')
            {
                PressKey((byte)(letterChar - 'a' + 'A'));
                return;
            }

            throw new Exception("Non-letter char.");
        }
        public static void PressKey(byte b)
        {
            KeyDown(b);
            KeyUp(b);
        }
        public static void KeyDown(byte b)
        {
            keybd_event(b, 0, KEY_DOWN_FLAG, 0);
        }
        public static void KeyUp(byte b)
        {
            keybd_event(b, 0, KEY_UP_FLAG, 0);
        }
        private static Dictionary<string, byte> SpecialKeyBytes = new Dictionary<string, byte>
        {
            {"left_win",0 },
            {"tab",9 },
            {"enter",13 },
            {"left",37 },
            {"up",38 },
            {"right",39 },
            {"down",40 },
            {"printscreen",44 },
        };
        public static Rectangle GetRect(string processName)
        {
            var p = Process.GetProcessesByName(processName).Single();
            var hwnd = p.MainWindowHandle;
            Rectangle rect;
            GetWindowRect(hwnd, out rect);
            return rect;
        }
    }
}
