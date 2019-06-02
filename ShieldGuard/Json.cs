using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShieldGuard
{
    class Json
    {
        public class RequestArg
        {
            public string key { get; set; }
            public string value { get; set; }
        }

        public class RootObject
        {
            public string session_key { get; set; }
            public long uid { get; set; }
            public string secret { get; set; }
            public string access_token { get; set; }
            public string machine_id { get; set; }
            public bool confirmed { get; set; }
            public string identifier { get; set; }
            public string user_storage_key { get; set; }

            public int error_code { get; set; }
            public string error_msg { get; set; }
            public List<RequestArg> request_args { get; set; }
            public int error_subcode { get; set; }
        }
    }
}
