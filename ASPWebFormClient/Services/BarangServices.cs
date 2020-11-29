using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ASPWebFormClient.Models;
using RestSharp;

namespace ASPWebFormClient.Services
{
    public class BarangServices
    {
        //ObjectDataSource
        private RestClient _restClient;
        public BarangServices()
        {
            _restClient = new RestClient
            {
                BaseUrl = new Uri("https://myapipgsql.azurewebsites.net")
            };
        }

        public IEnumerable<Barang> GetAll()
        {
            var request = new RestRequest("api/BarangDb", Method.GET)
            {
                RequestFormat = DataFormat.Json
            };

            var response = _restClient.Execute<List<Barang>>(request);
            if(response.Data==null)
            {
                throw new Exception($"Error: {response.ErrorMessage}");
            }
            return response.Data;
        }
    }
}