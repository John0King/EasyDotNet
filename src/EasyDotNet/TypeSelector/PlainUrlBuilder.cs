using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Threading.Tasks;

namespace EasyDotNet.TypeSelector
{
    /// <summary>
    /// this UrlBuilder is design for any version of dotnet, No httpContext required
    /// </summary>
    public class PlainUrlBuilder : IUrlBuider
    {
        public virtual bool UseFullUrlMode { get; set; } = false;
        public virtual RequestContext Context { get; private set; }
        public virtual List<string> Excludes { get; private set; } = new List<string>();
        public virtual Dictionary<string, string> Includes { get; private set; } = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
        public virtual Dictionary<string, string> QueryString
        {
            get
            {
                return Context.Query;
            }
        } 
        public virtual void SetExclude(params string[] ExcludeParams)
        {
            Excludes.AddRange(ExcludeParams);
        }
        public virtual void SetInclude(IEnumerable<KeyValuePair<string, string>> IncludeParams)
        {
            foreach(var item in IncludeParams)
            {
                Includes[item.Key] = item.Value; // this way do not throw error when add same key
            }
        }

        

        public virtual void SetContext(RequestContext context)
        {
            this.Context = context;
        }
        public virtual UrlData BuildUrl(string Param, KeyValuePair<string,string> handerValue)
        {
            if (this.Context == null || this.Context.Check() == false)
            {
                throw new NullReferenceException($"{nameof(Context)} is null, probably you may forget call \"{nameof(SetContext)}()\" method");
            }
            var data = new UrlData();
            data.Value = handerValue.Key;
            data.Text = handerValue.Value;
            
            data.Url = BuilderUrlInternal(Param,handerValue.Key);
            data.IsSelected = IsSelected(Param, data.Value);
            return data;
        }
        private string BuilderUrlInternal(string Param,string val)
        {
            var StrB = new StringBuilder();
            var CurrentVal = GetCurrentVal(Param);
            if (UseFullUrlMode)
            {
                StrB.Append(this.Context.Schema);
                StrB.Append("://");
                StrB.Append(this.Context.Host);
            }
            StrB.Append(this.Context.PathBase);
            StrB.Append(this.Context.Path);
            StrB.Append(GetQueryString(Param,val));
            return StrB.ToString();
        }
        private bool IsSelected(string Param,string v)
        {
            if (v == null)
            {
                v = string.Empty;
            }
            bool isSelected = false;
            
            if (string.Equals(GetCurrentVal(Param), v, StringComparison.OrdinalIgnoreCase))
            {
                isSelected = true;
            }
            return isSelected;
        }
        private string GetCurrentVal(string Param)
        {
            string val = string.Empty;
            if (QueryString.ContainsKey(Param))
            {
                val = QueryString[Param];
            }
            return val;
        }

        private string GetQueryString(string key,string value)
        {
            
            var Dic = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
            // check Exclude
            foreach(var item in QueryString)
            {
                if (!Excludes.Contains(item.Key, StringComparer.OrdinalIgnoreCase))
                {
                    Dic[item.Key] = item.Value;
                }
            }
            // check Include
            foreach(var item in Includes)
            {
                Dic[item.Key] = item.Value;
            }
            // add self
            if (Dic.ContainsKey(key))
            {
                Dic.Remove(key); // if already a value , we need remote it first otherwise you do not know it was uppercase or lowercase
            }
            if (!string.IsNullOrEmpty(value))
            {
                Dic[key] = value;
            }
            
            bool isFirst = true;
            var StrB = new StringBuilder();
            foreach (var item in Dic)
            {
                if (isFirst)
                {
                    isFirst = false;
                    StrB.Append("?");
                }
                else
                {
                    StrB.Append("&");
                }
                StrB.Append($"{WebUtility.UrlEncode(item.Key)}={WebUtility.UrlEncode(item.Value)}");
            }

            return StrB.ToString();
        }
    }
}
