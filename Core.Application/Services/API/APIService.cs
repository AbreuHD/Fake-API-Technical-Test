using Core.Application.DTOs;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.Services.API
{
    public class APIService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public APIService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<List<InfoBookDTO>> GetBooks()
        {
            var client = _httpClientFactory.CreateClient("BackEnd");
            var response = await client.GetAsync("/api/v1/Books");

            if (response.IsSuccessStatusCode)
            {
                var jsonContent = await response.Content.ReadAsStringAsync();
                List<InfoBookDTO> booksList = JsonConvert.DeserializeObject<List<InfoBookDTO>>(jsonContent);
                return booksList;
            }
            else
            {
                throw new Exception($"Error al obtener la lista de libros. Código de estado: {response.StatusCode}");
            }
        }


        public async Task<InfoBookDTO> GetBookById(int Id)
        {
            var client = _httpClientFactory.CreateClient("BackEnd");
            var response = await client.GetAsync($"/api/v1/Books/{Id}");
            if (response.IsSuccessStatusCode)
            {
                var jsonContent = await response.Content.ReadAsStringAsync();
                InfoBookDTO book = JsonConvert.DeserializeObject<InfoBookDTO>(jsonContent);
                return book;
            }
            else
            {
                throw new Exception($"Error al obtener la lista de libros. Código de estado: {response.StatusCode}");
            }
        }

        public async Task<InfoBookDTO> AddBook(BookDTO request)
        {
            var client = _httpClientFactory.CreateClient("BackEnd");
            var bookJson = JsonConvert.SerializeObject(request);
            var content = new StringContent(bookJson, Encoding.UTF8, "application/json");
            var response = await client.PostAsync("/api/v1/Books", content);
            if (response.IsSuccessStatusCode)
            {
                var jsonContent = await response.Content.ReadAsStringAsync();
                InfoBookDTO book = JsonConvert.DeserializeObject<InfoBookDTO>(jsonContent);
                return book;
            }
            else
            {
                throw new Exception($"Error al obtener la lista de libros. Código de estado: {response.StatusCode}");
            }
        }

        public async Task<InfoBookDTO> UpdateBook(int Id, BookDTO request)
        {
            var client = _httpClientFactory.CreateClient("BackEnd");
            var bookJson = JsonConvert.SerializeObject(request);
            var content = new StringContent(bookJson, Encoding.UTF8, "application/json");
            var response = await client.PutAsync($"/api/v1/Books/{Id}", content);
            if (response.IsSuccessStatusCode)
            {
                var jsonContent = await response.Content.ReadAsStringAsync();
                InfoBookDTO book = JsonConvert.DeserializeObject<InfoBookDTO>(jsonContent);
                return book;
            }
            else
            {
                throw new Exception($"Error al obtener la lista de libros. Código de estado: {response.StatusCode}");
            }
        }

        public async Task<System.Net.HttpStatusCode> DeleteBook(int Id)
        {
            var client = _httpClientFactory.CreateClient("BackEnd");
            var response = await client.DeleteAsync($"/api/v1/Books/{Id}");
            return response.StatusCode;
        }

    }
}
