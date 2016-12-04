using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyDotNet.TypeSelector
{
    /// <summary>
    /// 代表了TypeSelector 的 “按钮” 构造器
    /// </summary>
    public interface IItemBuilder
    {
        string BuildItem(UrlData data);
    }
}
