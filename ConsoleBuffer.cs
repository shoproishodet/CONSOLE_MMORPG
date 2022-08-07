using System;
using System.IO;
using System.Runtime.InteropServices;
using Microsoft.Win32.SafeHandles;

namespace RPG
{
    internal class ConsoleBuffer
    {
        #region Iterop Code

        [DllImport("Kernel32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        private static extern SafeFileHandle CreateFile(
            string fileName,
            [MarshalAs(UnmanagedType.U4)] uint fileAccess,
            [MarshalAs(UnmanagedType.U4)] uint fileShare,
            IntPtr securityAttributes,
            [MarshalAs(UnmanagedType.U4)] FileMode creationDisposition,
            [MarshalAs(UnmanagedType.U4)] int flags,
            IntPtr template);

        [DllImport("Kernel32.dll", SetLastError = true)]
        private static extern bool WriteConsoleOutputW(
            SafeFileHandle hConsoleOutput,
            CharInfo[] lpBuffer,
            Coord dwBufferSize,
            Coord dwBufferCoord,
            ref SmallRect lpWriteRegion);

        [StructLayout(LayoutKind.Sequential)]
        private struct Coord
        {
            public short X;
            public short Y;
        }

        [StructLayout(LayoutKind.Explicit)]
        private struct CharUnion
        {
            [FieldOffset(0)] public ushort UnicodeChar;
            [FieldOffset(0)] public byte AsciiChar;
        }

        [StructLayout(LayoutKind.Explicit)]
        private struct CharInfo
        {
            [FieldOffset(0)] public CharUnion Char;
            [FieldOffset(2)] public short Attributes;
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct SmallRect
        {
            public short Left;
            public short Top;
            public short Right;
            public short Bottom;
        }

        #endregion

        private readonly SafeFileHandle _consoleHandle =
            CreateFile("CONOUT$", 0x40000000, 2, IntPtr.Zero, FileMode.Open, 0, IntPtr.Zero);


        private const ConsoleColor BACKGROUND_DEFAULT_COLOR = ConsoleColor.Black;
        private const ConsoleColor FOREGROUND_DEFAULT_COLOR = ConsoleColor.Gray;
        private const char DEFAULT_CHARACTER = '-';

        public static readonly short Width = Convert.ToInt16(Console.LargestWindowWidth);
        public static readonly short Height = Convert.ToInt16(Console.LargestWindowHeight);

        private readonly CharInfo[] _buffer = new CharInfo[Width * Height];

        public ConsoleBuffer()
        {
            if (_consoleHandle.IsInvalid)
            {
                throw new Exception("Couldn't get console handler");
            }

            Clear();
        }

        public void Clear()
        {
            for (var row = 0; row < Height; row++)
            for (var column = 0; column < Width; column++)
            {
                _buffer[GetIndex(column, row)] = BuildCharInfo(DEFAULT_CHARACTER);
            }
        }

        public void Write(int x, int y,
            char symbol,
            ConsoleColor? foregroundColor,
            ConsoleColor? backgroundColor)
        {
            if (x < 0 || x >= Width)
                throw new ArgumentOutOfRangeException(nameof(x));
            if (y < 0 || y >= Height)
                throw new ArgumentOutOfRangeException(nameof(y));

            _buffer[GetIndex(x, y)] = BuildCharInfo(symbol,
                foregroundColor ?? FOREGROUND_DEFAULT_COLOR,
                backgroundColor ?? BACKGROUND_DEFAULT_COLOR);
        }

        private static CharInfo BuildCharInfo(char character,
            ConsoleColor foregroundColor = FOREGROUND_DEFAULT_COLOR,
            ConsoleColor backgroundColor = BACKGROUND_DEFAULT_COLOR)
        {
            return new CharInfo
            {
                Char = new CharUnion
                {
                    AsciiChar = (byte) character,
                    UnicodeChar = character
                },
                Attributes = BuildCharAttributes(foregroundColor, backgroundColor)
            };
        }

        private static short BuildCharAttributes(ConsoleColor foregroundColor, ConsoleColor backgroundColor)
        {
            return (short) (((short) backgroundColor << 4) + foregroundColor);
        }

        public void Print()
        {
            var rect = new SmallRect {Left = 0, Top = 0, Right = Width, Bottom = Height};

            WriteConsoleOutputW(_consoleHandle, _buffer,
                new Coord {X = Width, Y = Height},
                new Coord {X = 0, Y = 0},
                ref rect);
        }

        private static int GetIndex(int x, int y)
        {
            return y * Width + x;
        }
    }
}