using EasyDotNet.TypeSelector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyDotNet.CoreMVC
{
    public class RouteUrlBuilder:IUrlBuider
    {
        public RouteUrlBuilder()
        {
        }

        public UrlData BuildUrl(string Param, string Text)
        {
            throw new NotImplementedException();
        }

        public void SetContext(RequestContext context)
        {
            throw new NotImplementedException();
        }

        public void SetExclude(IEnumerable<string> ExcludeParams)
        {
            throw new NotImplementedException();
        }

        public void SetInclude(IEnumerable<KeyValuePair<string, string>> Includes)
        {
            throw new NotImplementedException();
        }

        public void SetQueryData(Dictionary<string, string> querys)
        {
            throw new NotImplementedException();
        }
    }
}
