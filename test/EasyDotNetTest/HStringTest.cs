using System;
using System.Collections.Generic;
using System.Text;
using EasyDotNet;
using Xunit;

namespace EasyDotnetTest
{
    public class HStringTest
    {
        public HStringTest()
        {

        }
        [Theory]
        [InlineData("<p>hello word</p>")]
        [InlineData("<p>hello  word</p>")]
        [InlineData("<p>hello    word</p>")]
        [InlineData("<script>alert('hi');\r\n  window.history.go(-1)  </script><p>hello word</p>")]
        [InlineData("<p>hello  &nbsp;  word</p>")]
        [InlineData(@"<style type=""text/css"">
.p{ width:10px;}
img{
    width:100%;
    height:300%
}
</style><p>hello word</p>")]
        public void DelHtml_Test(string text)
        {
            var r = HString.DelHtml(text);
            Assert.Equal("hello word",r);
        }
    }

}
