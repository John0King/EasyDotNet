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
        void SetExclude(IEnumerable<string> ExcludeParams);
        /// <summary>
        /// 设置要包含的数据
        /// </summary>
        void SetInclude(IEnumerable<KeyValuePair<string, string>> Includes);
        /// <summary>
        /// 设置url数据
        /// </summary>
        void SetQueryData(Dictionary<string, string> querys);
        void SetContext(RequestContext context);
        UrlData BuildUrl(string Param,string Text);
    }
}
