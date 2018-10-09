using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace fp_stack.web.APIHelper
{
    public class ApiHelper
    {
        private readonly HttpClient _HttpClient;

        public ApiHelper()
        {
            _HttpClient = new HttpClient();
        }

        public HttpClient ObterHttClient()
        {
            return _HttpClient;
        }

        internal string ObterUrl(string controller )
        {

            return "https://localhost:7657/api/" + controller + "/";

        }
    }
}
