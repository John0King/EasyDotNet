using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyDotNet.TypeSelector
{
    public sealed class TypeSelector
    {
        public TypeSelector() : this(null, null)
        {

        }
        public TypeSelector(IUrlBuider urlBuilder,IItemBuilder itemBuilder)
        {
            if (urlBuilder != null)
            {
                this.UrlBuilder = urlBuilder;
            }
            else
            {
                this.UrlBuilder = new PlainUrlBuilder();
            }
            if (itemBuilder != null)
            {
                this.ItemBuilder = itemBuilder;
            }
            else
            {
            }
        }
        
        public IUrlBuider UrlBuilder { get; set; }
        public IItemBuilder ItemBuilder { get; set; }

        /// <summary>
        /// 写出Items
        /// </summary>
        /// <param name="Param">参数名称</param>
        /// <param name="items">项目值， &lt;a href=[Key]&gt; [Value] &lt;a&gt; </param>
        /// <returns></returns>
        public string Write(string Param,Dictionary<string,string> items)
        {
            StringBuilder html = new StringBuilder();
            foreach(var item in items)
            {
                var data = UrlBuilder.BuildUrl(Param,item);
                html.Append(ItemBuilder.BuildItem(data));
            }
            return html.ToString();
        }
        public Task<string> WriteAsync(string Param,Dictionary<string,string> items)
        {
            var task = new Task<string>(() => this.Write(Param, items));
            task.Start();
            return task;
        }
    }
}
