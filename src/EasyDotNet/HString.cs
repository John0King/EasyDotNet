using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

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
            //先删除script标签才能在删除其他标签时不会发生问题
            html = Regex.Replace(html, "<script[\\s\\S]+</script>", string.Empty,RegexOptions.IgnoreCase|RegexOptions.Multiline);
            html = Regex.Replace(html, "<style[\\s\\S]+</style>", string.Empty, RegexOptions.IgnoreCase | RegexOptions.Multiline);
            // 这是再删除其他标签才不会有问题
            html = Regex.Replace(html, "<[^>]+>", string.Empty);
            // 将转义过的变成平常太
            html = Regex.Replace(html, "(&nbsp;?)+", " ",RegexOptions.IgnoreCase);
            // 合并空格
            html = Regex.Replace(html, "( )+", " ");
            // 合并换行
            html = Regex.Replace(html, "[\r\n]+", "\r\n");// 故意不使用Environment.NewLine
            return html;
        }
        /// <summary>
        /// 在 Html中寻找 某个标签
        /// </summary>
        /// <param name="html">html代码</param>
        /// <param name="tagName">需要的标签名</param>
        /// <param name="isSingle">是否是单标签，默认为true, 因为此方法大部分情况下寻找img等单标签</param>
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
        /// <summary>
        /// <see cref="string.Substring(int, int)"/> 的 安全版本
        /// </summary>
        /// <param name="text">文本</param>
        /// <param name="start">开始索引</param>
        /// <param name="length">长度</param>
        /// <returns></returns>
        public static string SubString(string text,int start,int? length = null)
        {
            if (string.IsNullOrEmpty(text))
            {
                return "";
            }
            if (start < 0)
            {
                start = 0;
            }
            if (start > text.Length)
            {
                start = text.Length;
            }
            if(length == null)
            {
                return text.Substring(start);
            }
            if(length < 0)
            {
                length = 0;
            }
            if(length + start > text.Length)
            {
                length = text.Length - start;
            }
            return text.Substring(start, length.Value);
        }
        /// <summary>
        /// 先删除标签再执行截取和文本溢出
        /// </summary>
        /// <param name="html"></param>
        /// <param name="length"></param>
        /// <param name="ellipsis"></param>
        /// <param name="after"></param>
        /// <returns></returns>
        public static string Elipsis(string html, int length, bool ellipsis = true, string after = "...")
        {
            html = DelHtml(html);
            if (length <= 0)
            {
                return string.Empty;
            }
            if (ellipsis)
            {
                var afterlen = TextLen(after);
                var textlen = TextLen(html);
                if(textlen <= length)
                {
                    return html;
                }
                else
                {
                    return TextSubStr(html, length - afterlen);
                }
            }
            else
            {
                return TextSubStr(html, length);
            }
        }
        /// <summary>
        /// 获取 “文字长度”
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        private static int TextLen(string text)
        {
            throw new NotImplementedException();
        }

        private static string TextSubStr(string text, int len)
        {
            throw new NotImplementedException();
        }
    }
}
