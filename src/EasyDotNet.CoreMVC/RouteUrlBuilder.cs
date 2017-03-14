using EasyDotNet.TypeSelector;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyDotNet.CoreMVC
{
    public class RouteUrlBuilder : IUrlBuider
    {
        public RouteUrlBuilder(HttpContext context)
        {

        }
        public RouteUrlBuilder(IHttpContextAccessor contextAccessor ):this(contextAccessor.HttpContext)
        {

        }
        public List<string> Excludes { get; private set; } = new List<string>();

        public Dictionary<string, string> Includes { get; private set; } = new Dictionary<string, string>();

        public UrlData BuildUrl(string Param, KeyValuePair<string, string> handerValue)
        {
            throw new NotImplementedException();
        }

        public string BuildUrlInRouteModel()
        {
            //1. check repeat for [action],[controller],[area] in queryString
            //2. Trim repeat and log repate querystring
            //3. build in route
            //4. add repeated querystring
            throw new NotImplementedException();
        }
    }
}
