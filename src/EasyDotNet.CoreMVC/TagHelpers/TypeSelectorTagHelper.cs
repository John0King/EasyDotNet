﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.TagHelpers;
using EasyDotNet.TypeSelector;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EasyDotNet.CoreMVC.TagHelpers
{
    [HtmlTargetElement(TagName, Attributes = nameof(Param))]
    public class TypeSelectorTagHelper:TagHelper
    {
        public TypeSelectorTagHelper()
        {

        }
        public const string TagName = "cs-typeselector";

        /// <summary>
        /// 在此属性里面，与普通的设置键值设置是反的，即： Key = text ; value = value
        /// </summary>
        [HtmlAttributeName(DictionaryAttributePrefix = "Items-")]
        public Dictionary<string, string> Items { get; } = new Dictionary<string, string>();
        [HtmlAttributeName(DictionaryAttributePrefix =null)]
        public Dictionary<string, string> MainItems { get; set; } = new Dictionary<string, string>();
        [HtmlAttributeName]
        public string Param { get; set; }
        [HtmlAttributeName]
        public IUrlBuider UrlBuilder { get; set; }
        [HtmlAttributeName]
        public IItemBuilder ItemBuilder { get; set; }

        [ViewContext]
        public ViewContext ViewContext { get; set; }

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            var ts = new TypeSelector.TypeSelector();
            if (this.ItemBuilder != null)
            {
                ts.ItemBuilder = this.ItemBuilder;
            }
            else
            {
                // from DI
                ts.ItemBuilder = ViewContext.HttpContext.RequestServices.GetService(typeof(IItemBuilder)) as IItemBuilder;
            }
            if(ts.UrlBuilder != null)
            {
                ts.UrlBuilder = this.UrlBuilder;
            }
            else
            {
                // from DI
                ts.UrlBuilder = ViewContext.HttpContext.RequestServices.GetService(typeof(IUrlBuider)) as IUrlBuider;
            }
            output.TagName = null;
            var items = new List<KeyValuePair<string, string>>();
            items.AddRange(Items.ToDictionary(x => x.Value, x => x.Key));
            items.AddRange(MainItems);
            output.PostContent.AppendHtml(await ts.WriteAsync(this.Param, items));
        }

    }
}
