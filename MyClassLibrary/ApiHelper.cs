using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace MyClassLibrary
{
    public static class ApiHelper
    {
        public static HttpClient ApiClient { get; set; }
        //Initialiazing new api client
        public static void InitClient()
        {
            ApiClient = new HttpClient();
            ApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            ApiClient.BaseAddress = new Uri("https://exchangeratesapi.io");
            
        }
    }
}
