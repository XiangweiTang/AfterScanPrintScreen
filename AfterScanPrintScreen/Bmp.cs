using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AfterScanPrintScreen
{
    public class Bmp
    {
        #region Parameters

        /// <summary>
        /// Type of the file. Should be 0x42, 0x4d, or 'B', 'M'
        /// Offset 0
        /// </summary>
        public string Type { get; private set; }
        /// <summary>
        /// Size of the file.
        /// Offset 2
        /// </summary>
        public uint Size { get; set; }
        /// <summary>
        /// Unused.
        /// Offset 6
        /// </summary>
        public ushort Unused1 => 0;
        /// <summary>
        /// Unused.
        /// Offset 8
        /// </summary>
        public ushort Unused2 => 0;
        /// <summary>
        /// Offset of the file. Typically 54.
        /// Offset 10
        /// </summary>
        public uint Offset { get; set; }
        /// <summary>
        /// DIB header size. Typically 40
        /// Offset 14
        /// </summary>
        public uint DibHeaderSize { get; set; }
        /// <summary>
        /// Width of the picture.
        /// Offset 18
        /// </summary>
        public int Width { get; set; }
        /// <summary>
        /// Height of the picture.
        /// Offset 22
        /// </summary>
        public int Height { get; set; }
        /// <summary>
        /// Number of color planes.
        /// Offset 26
        /// </summary>
        public ushort NumPlanes { get; set; }
        /// <summary>
        /// Bits per pixel.
        /// Offset 28
        /// </summary>
        public ushort BitsPerPixel { get; set; } 
        /// <summary>
        /// Compression type.
        /// Offset 30
        /// </summary>
        public uint Compression { get; set; }
        /// <summary>
        /// Size of the image.
        /// Offset 34
        /// </summary>
        public uint ImageSizeBytes { get; set; }
        /// <summary>
        /// Pixels per meter, x direction.
        /// Offset 38
        /// </summary>
        public int XResolutionPpm { get; set; }
        /// <summary>
        /// Pixels per meter, y direction.
        /// Offset 42
        /// </summary>
        public int YResolutionPpm { get; set; }
        /// <summary>
        /// Number of colors.
        /// Offset 46
        /// </summary>
        public uint NumColors { get; set; }
        /// <summary>
        /// Important colors.
        /// Offset 50
        /// </summary>
        public uint ImportantColors { get; set; }
        #endregion
        private byte[] Bytes;
        public Bmp() { }
        public void Load(byte[] bytes)
        {
            Sanity.Requres(bytes.Length >= 54, "Header broken.");
            Type = Encoding.ASCII.GetString(bytes, 0, 2);
            Sanity.Requres(Type == "BM", $"Invalid type.");
            Size = BitConverter.ToUInt32(bytes, 2);
            Offset = BitConverter.ToUInt32(bytes, 10);
            DibHeaderSize = BitConverter.ToUInt32(bytes, 14);
            Width = BitConverter.ToInt32(bytes, 18);
            Height = BitConverter.ToInt32(bytes, 22);
            NumPlanes = BitConverter.ToUInt16(bytes, 26);
            BitsPerPixel = BitConverter.ToUInt16(bytes, 28);
            Compression = BitConverter.ToUInt32(bytes, 30);
            ImageSizeBytes = BitConverter.ToUInt32(bytes, 34);
            XResolutionPpm = BitConverter.ToInt32(bytes, 38);
            YResolutionPpm = BitConverter.ToInt32(bytes, 42);
            NumColors = BitConverter.ToUInt32(bytes, 46);
            ImportantColors = BitConverter.ToUInt32(bytes, 50);
            Bytes = bytes;
        }

        public byte[] CompressToBlackWhite()
        {
            int bytesPerPixel = BitsPerPixel / 8;
            byte[] newBytes = new byte[Size];
            Array.Copy(Bytes, 0, newBytes, 0, Offset);
            int length = (int)((Size - Offset) / bytesPerPixel);
            for(int i = 0; i < length; i++)
            {
                byte value = (byte)((Bytes[Offset + i * bytesPerPixel] + Bytes[Offset + i * bytesPerPixel + 1] + Bytes[Offset + i * bytesPerPixel + 2]) / 3);
                newBytes[Offset + i * bytesPerPixel] = value;
                newBytes[Offset + i * bytesPerPixel + 1] = value;
                newBytes[Offset + i * bytesPerPixel + 2] = value;
            }
            return newBytes;
        }
    }
}
