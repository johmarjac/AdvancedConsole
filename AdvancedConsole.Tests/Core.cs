using System;
using Xunit;

namespace AdvancedConsole.Tests
{
    public class Core
    {
        [Fact]
        public void HexView()
        {
            var rnd = new Random();
            var data = new byte[rnd.Next(1, 999)];
            rnd.NextBytes(data);
            AConsole.WriteHexView(data);
        }
    }
}