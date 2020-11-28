using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using RestSharp;

namespace ASPWebFormClient.Services
{
    public class BarangServices
    {
        private RestClient _restClient;
        public BarangServices()
        {
            _restClient = new RestClient
            {
                BaseUrl = new Uri("https://myapipgsql.azurewebsites.net/api/BarangDb")
            };
        }
    }
}