using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyDotNet.TypeSelector
{
    public class SimpleItemBuilder : IItemBuilder
    {
        public string BuildItem(UrlData data)
        {
            var strB = new StringBuilder();
            strB.Append($"<a href=\"{data.Url}\"");
            if (data.IsSelected)
            {
                strB.Append(" class=\"on\"");
            }
            strB.Append(">");
            strB.Append(data.Text);
            strB.Append("</a>");
            return strB.ToString();
        }
    }
}
