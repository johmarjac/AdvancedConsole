using System;
using System.Linq;

namespace AdvancedConsole.Tests
{
    class Program
    {
        static void Main(string[] args)
        {
            //int bpr = 16;
            //int bla = 9 % bpr;

            //Console.WriteLine(bla);

            while(true)
            {
                var buf = new byte[new Random().Next(10, 10000)];
                new Random().NextBytes(buf);
                AConsole.WriteHexView(buf);
                Console.ReadLine();
            }
        }
    }
}