using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyDotNet.TypeSelector
{
    /// <summary>
    /// this UrlBuilder is design for any version of dotnet, No httpContext required
    /// </summary>
    public class DefautlUrlBuilder : IUrlBuider
    {
        public RequestContext Context { get; private set; }
        

        public List<string> Exclued { get; private set; } = new List<string>();
        public void SetExclude(IEnumerable<string> ExcludeParams)
        {
            Exclued.AddRange(ExcludeParams);
        }
        public Dictionary<string, string> Included { get; private set; } = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
        public void SetInclude(IEnumerable<KeyValuePair<string, string>> Includes)
        {
            foreach(var item in Includes)
            {
                this.Included[item.Key] = item.Value; // this way do not throw error when add same key
            }
        }

        public Dictionary<string, string> QueryString { get; private set; } = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
        public void SetQueryData(Dictionary<string, string> querys)
        {
            if( querys.Comparer== StringComparer.OrdinalIgnoreCase|| querys.Comparer == StringComparer.CurrentCultureIgnoreCase)
            {
                this.QueryString = querys;
            }
            else
            {
                foreach(var item in querys)
                {
                    querys[item.Key] = item.Value;
                }
            }
        }

        public void SetContext(RequestContext context)
        {
            this.Context = context;
        }
        public UrlData BuildUrl(string Param, string Text)
        {
            if (this.Context == null || this.Context.Check() == false)
            {
                throw new NullReferenceException($"{nameof(Context)} is null, probably you may forget call \"{nameof(SetContext)}()\" method");
            }
            var data = new UrlData();
            data.Text = Text;


            return data;
        }
    }
}
