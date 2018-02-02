using System;
using NUnit.Framework;

namespace AdvancedConsole.Tests
{
    public class Core
    {
        [Test]
        public void HexView()
        {
            var rnd = new Random();
            var data = new byte[rnd.Next(1, 999)];
            rnd.NextBytes(data);
            AConsole.WriteHexView(data);
        }
    }
}