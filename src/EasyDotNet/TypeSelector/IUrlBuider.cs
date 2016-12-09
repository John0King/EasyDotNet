using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyDotNet.TypeSelector
{
    /// <summary>
    /// 代表了用于TypeSelector 的 Url构造器
    /// </summary>
    /// <remarks>设置<see cref="IDictionary{string, TValue}"/> 时请使用stringCompare.ordiaIgoncase </remarks>
    public interface IUrlBuider
    {
        List<string> Excludes { get; }
        /// <summary>
        /// 要特殊包含的项目
        /// <para>注意此字典应该是忽略大小的字典</para>
        /// </summary>
        Dictionary<string,string> Includes { get; }
        UrlData BuildUrl(string Param,KeyValuePair<string,string> handerValue);
    }
}
