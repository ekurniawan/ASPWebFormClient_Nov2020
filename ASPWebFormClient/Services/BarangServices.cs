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

        public Barang GetByKode(string kodebarang)
        {
            var request = new RestRequest("api/BarangDb/{kodebarang}", Method.GET)
            {
                RequestFormat = DataFormat.Json
            };
            request.AddParameter("kodebarang", kodebarang, ParameterType.UrlSegment);

            var response = _restClient.Execute<Barang>(request);
            if (response.Data == null)
            {
                throw new Exception($"Error:{response.ErrorMessage}");
            }

            return response.Data;
        }

        public void InsertBarang(string kodebarang, string namabarang, int stok,
            decimal hargabeli, decimal hargajual)
        {
            var newBarang = new Barang
            {
                kodebarang = kodebarang,
                namabarang = namabarang,
                stok = stok,
                hargabeli = hargabeli,
                hargajual = hargajual
            };

            var request = new RestRequest("api/BarangDb", Method.POST)
            {
                RequestFormat = DataFormat.Json
            };
            //data yg akan dikirimkan ke api
            request.AddJsonBody(newBarang);

            try
            {
                var response = _restClient.Execute(request);
                if (response.StatusCode != System.Net.HttpStatusCode.OK)
                    throw new Exception($"Error: gagal menambah data - {response.ErrorMessage}");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void UpdateBarang(string namabarang, int stok,
            decimal hargabeli, decimal hargajual, string kodebarang)
        {
            var updateBarang = new Barang
            {
                namabarang = namabarang,
                stok = stok,
                hargabeli = hargabeli,
                hargajual = hargajual
            };

            var request = new RestRequest("api/BarangDb/{kodebarang}", Method.PUT)
            {
                RequestFormat = DataFormat.Json
            };
            request.AddParameter("kodebarang", kodebarang, ParameterType.UrlSegment);
            request.AddJsonBody(updateBarang);

            try
            {
                var response = _restClient.Execute(request);
                if (response.StatusCode != System.Net.HttpStatusCode.OK)
                    throw new Exception($"Error: gagal mengupdate data - {response.ErrorMessage}");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void DeleteBarang(string kodebarang)
        {
            var result = GetByKode(kodebarang);
            if (result == null)
                throw new Exception($"Data kode {kodebarang} tidak ditemukan");

            var request = new RestRequest("api/BarangDb/{kodebarang}", Method.DELETE)
            {
                RequestFormat = DataFormat.Json
            };
            request.AddParameter("kodebarang", kodebarang, ParameterType.UrlSegment);
            try
            {
                var response = _restClient.Execute(request);
                if (response.StatusCode != System.Net.HttpStatusCode.OK)
                    throw new Exception($"Error: {response.ErrorMessage}");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}