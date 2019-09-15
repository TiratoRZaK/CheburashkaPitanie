using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Tests
{
    public class Class1
    {
        [Fact]
        public void TestPlus()
        {
            float result = 1.0f + 2.0f;
            Assert.True(3 == result);
        }
    }
}
