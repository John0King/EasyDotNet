using EasyDotNet.TypeSelector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace EasyDotNet.CoreMVC
{
    public class HttpUrlBuilder : PlainUrlBuilder
    {
        public HttpUrlBuilder(IHttpContextAccessor contextAccessor):this(contextAccessor.HttpContext)
        {
        }
        public HttpUrlBuilder(HttpContext context)
        {
            var RequestContext = new RequestContext();
            RequestContext.Schema = context.Request.Scheme;
            RequestContext.Host = context.Request.Host.ToString();
            RequestContext.PathBase = context.Request.PathBase;
            RequestContext.Path = context.Request.Path;
            RequestContext.Query = context.Request.Query.ToDictionary(c => c.Key, c => c.Value.ToString(), StringComparer.OrdinalIgnoreCase);

            SetContext(RequestContext);
        }
    }
}
