﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AfterScanPrintScreen.EdgeDetector
{
    public static class Convolution
    {
        private static int[,] MaskMatrix =
        {
            { 2,4,5,4,2 },
            { 4,9,12,9,4 },
            { 5,12,15,12,5 },
            { 4,9,12,9,4 },
            { 2,4,5,4,2 }
        };
    }
}
