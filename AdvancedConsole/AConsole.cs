using System;
using System.Linq;
using System.Text;

namespace AdvancedConsole
{
    public static class AConsole
    {
        private static object hexViewLock = new object();

        public static void WriteHexView(byte[] data, bool displayOffset = true, bool displayAscii = true, int bytesPerRow = 16)
        {
            lock(hexViewLock)
            {
                for (int i = 0; i < data.Length; i += bytesPerRow)
                {
                    var remainingBytes = data.Length - i;
                    var amtbytesThisRow = 0;

                    if (remainingBytes >= bytesPerRow)
                        amtbytesThisRow = bytesPerRow;
                    else
                        amtbytesThisRow = remainingBytes % bytesPerRow;

                    var bytesThisRow = data.Skip(i).Take(amtbytesThisRow).ToArray();

                    if (displayOffset)
                        Console.Write("{0:X8}  ", i);

                    for (int j = 0; j < bytesThisRow.Length; j++)
                        Console.Write(j == bytesThisRow.Length - 1 ? "{0:X2}" : "{0:X2} ", bytesThisRow[j]);
                    for (int j = 0; j < bytesPerRow - amtbytesThisRow; j++)
                        Console.Write("   ");

                    if (displayAscii)
                        Console.Write("  " + GetStringRepresentation(bytesThisRow));

                    Console.WriteLine();
                }
            }
        }

        private static string GetStringRepresentation(byte[] row)
        {
            var s = string.Empty;
            foreach (var b in row)
                s += b < 32 ? "." : Encoding.GetEncoding("UTF-8", new EncoderReplacementFallback(string.Empty), new DecoderReplacementFallback(".")).GetString(new[] { b });
            return s;
        }
    }
}