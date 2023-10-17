using Core.Application.DTOs;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.Services.FakeAPI
{
    public class FakeAPIService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public FakeAPIService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<GenericApiResponse<List<InfoBookDTO>>> GetBooks()
        {
            var client = _httpClientFactory.CreateClient("FakeAPI");
            var call = await client.GetAsync("/api/v1/Books");
            var response = await HttpMessages<List<InfoBookDTO>>(call);

            var jsonContent = await call.Content.ReadAsStringAsync();
            List<InfoBookDTO> booksList = JsonConvert.DeserializeObject<List<InfoBookDTO>>(jsonContent);
            response.Data = booksList;
            return response;
        }

        public async Task<GenericApiResponse<InfoBookDTO>> GetBookById(int Id)
        {
            var client = _httpClientFactory.CreateClient("FakeAPI");
            var call = await client.GetAsync($"/api/v1/Books/{Id}");
            var response = await HttpMessages<InfoBookDTO>(call);

            var jsonContent = await call.Content.ReadAsStringAsync();
            InfoBookDTO book = JsonConvert.DeserializeObject<InfoBookDTO>(jsonContent);
            response.Data = book;
            return response;
        }

        public async Task<GenericApiResponse<InfoBookDTO>> AddBook(BookDTO request)
        {
            var client = _httpClientFactory.CreateClient("FakeAPI");
            var bookJson = JsonConvert.SerializeObject(request);
            var content = new StringContent(bookJson, Encoding.UTF8, "application/json");
            var call = await client.PostAsync("/api/v1/Books", content);
            var response = await HttpMessages<InfoBookDTO>(call);

            var jsonContent = await call.Content.ReadAsStringAsync();
            InfoBookDTO book = JsonConvert.DeserializeObject<InfoBookDTO>(jsonContent);
            response.Data = book;
            return response;
        }

        public async Task<GenericApiResponse<InfoBookDTO>> UpdateBook(int Id, BookDTO request)
        {
            var client = _httpClientFactory.CreateClient("FakeAPI");
            var bookJson = JsonConvert.SerializeObject(request);
            var content = new StringContent(bookJson, Encoding.UTF8, "application/json");
            var call = await client.PutAsync($"/api/v1/Books/{Id}", content);
            var response = await HttpMessages<InfoBookDTO>(call);

            var jsonContent = await call.Content.ReadAsStringAsync();
            InfoBookDTO book = JsonConvert.DeserializeObject<InfoBookDTO>(jsonContent);
            response.Data = book;
            return response;
        }

        public async Task<GenericApiResponse<int>> DeleteBook(int Id)
        {
            var client = _httpClientFactory.CreateClient("FakeAPI");
            var call = await client.DeleteAsync($"/api/v1/Books/{Id}");
            var response = await HttpMessages<int>(call);
            return response;
        }


        private async Task<GenericApiResponse<T>> HttpMessages<T>(HttpResponseMessage call) where T : new()
        {
            var response = new GenericApiResponse<T>();
            response.StatusCode = call.StatusCode;
            response.Message = call.StatusCode.ToString();
            response.Data = new T();
            return response;
        }

    }
}
