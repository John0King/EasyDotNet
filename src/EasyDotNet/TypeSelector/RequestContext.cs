using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyDotNet.TypeSelector
{
    public class RequestContext
    {
        public RequestContext()
        {
            this.Query = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
        }
        public string Schema { get; set; }
        /// <summary>
        /// Domain and port
        /// </summary>
        public string Host { get; set; }
        public string PathBase { get; set; }
        public string Path { get; set; }
        public Dictionary<string,string> Query { get; set; }


        public bool Check()
        {
            if (PathBase == null)
            {
                return false;
            }
            if(Path == null)
            {
                return false;
            }
            if(Query == null)
            {
                return false;
            }
            return true;
        }

    }
}
