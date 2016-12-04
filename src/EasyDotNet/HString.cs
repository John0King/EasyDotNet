using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyDotNet
{
    /// <summary>
    /// Html String 帮助类
    /// </summary>
    public static class HString
    {
        /// <summary>
        /// 删除html ，
        /// </summary>
        /// <remarks>
        ///  删除html 标签，并将 &***; 变成一个字符，删除script 和代码
        /// </remarks>
        public static string DelHtml(string html)
        {
            if (string.IsNullOrWhiteSpace(html))
            {
                return string.Empty;
            }
            throw new NotImplementedException();
        }
        /// <summary>
        /// 在 Html中寻找 某个标签
        /// </summary>
        /// <param name="html">html代码</param>
        /// <param name="isSingle">是否是单标签，默认为true, 因为此方法大部分情况下寻找img等但标签</param>
        public static List<string> FindTags(string html,string tagName,bool isSingle =true)
        {
            var tagset = new List<string>();
            if (string.IsNullOrWhiteSpace(html))
            {
                return tagset;
            }
            throw new NotImplementedException();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Tag">单个标签</param>
        /// <param name="attrName">特性名称</param>
        /// <param name="isBoolean">特性是否是布尔值</param>
        /// <returns></returns>
        public static string FindAttribute(string Tag,string attrName,bool isBoolean = false)
        {
            if (string.IsNullOrWhiteSpace(Tag))
            {
                return string.Empty;
            }
            throw new NotImplementedException();
        }
        public static string SubString(string text,int lenght,bool ellipsis=true,string after = "...")
        {
            throw new NotImplementedException();
        }
    }
}
