using EasyDotNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace EasyDotNetTest
{
    public class CharpConvertTest
    {
        [Theory]
        [InlineData(2)]
        [InlineData(-2)]
        [InlineData(null)]
        [InlineData("2")]
        [InlineData("abc")]
        public void In32Test(object val)
        {
            int returnval = SharpConvert.ToInt32(val);
        }
        [Theory]
        [InlineData("12")]
        [InlineData("abc")]
        [InlineData(typeof(int))]
        public void To_int_Test(object val)
        {
            int returnvalue = SharpConvert.To<int>(() => int.Parse(val.ToString()), 32);
            if (object.Equals(val, "12"))
            {
                Assert.Equal(returnvalue, 12);
            }
            else
            {
                Assert.Equal(returnvalue, 32);
            }
            
        }
    }
}
