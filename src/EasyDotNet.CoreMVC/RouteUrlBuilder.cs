using EasyDotNet.TypeSelector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyDotNet.CoreMVC
{
    public class RouteUrlBuilder : IUrlBuider
    {
        public List<string> Excludes
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public Dictionary<string, string> Includes
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public UrlData BuildUrl(string Param, KeyValuePair<string, string> handerValue)
        {
            throw new NotImplementedException();
        }
    }
}
