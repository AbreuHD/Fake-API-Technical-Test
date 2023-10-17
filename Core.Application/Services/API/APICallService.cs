using Core.Application.DTOs;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http.Json;
using System.Text;

namespace Core.Application.Services.API
{
    public class APICallService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public APICallService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<GenericApiResponse<List<InfoBookDTO>>> GetBooks()
        {
            var client = _httpClientFactory.CreateClient("BackEnd");
            var call = await client.GetAsync("/api/Books");
            var jsonContent = await call.Content.ReadAsStringAsync();
            JObject jsonObject = JObject.Parse(jsonContent);
            List<InfoBookDTO> booksList = JsonConvert.DeserializeObject<List<InfoBookDTO>>(jsonObject["data"].ToString());
            var response = await HttpMessages<List<InfoBookDTO>>(call);
            response.Data = booksList;
            return response;
        }

        public async Task<GenericApiResponse<InfoBookDTO>> GetBookById(int Id)
        {
            var client = _httpClientFactory.CreateClient("BackEnd");
            var call = await client.GetAsync($"/api/Books/{Id}");
            var response = await HttpMessages<InfoBookDTO>(call);

            var jsonContent = await call.Content.ReadAsStringAsync();
            JObject jsonObject = JObject.Parse(jsonContent);
            InfoBookDTO book = JsonConvert.DeserializeObject<InfoBookDTO>(jsonObject["data"].ToString());
            response.Data = book;
            return response;
        }

        public async Task<GenericApiResponse<InfoBookDTO>> AddBook(BookDTO request)
        {
            var client = _httpClientFactory.CreateClient("BackEnd");
            var bookJson = JsonConvert.SerializeObject(request);
            var content = new StringContent(bookJson, Encoding.UTF8, "application/json");
            var call = await client.PostAsync("/api/Books", content);
            var response = await HttpMessages<InfoBookDTO>(call);

            var jsonContent = await call.Content.ReadAsStringAsync();
            JObject jsonObject = JObject.Parse(jsonContent);
            InfoBookDTO book = JsonConvert.DeserializeObject<InfoBookDTO>(jsonObject["data"].ToString());
            response.Data = book;
            return response;
        }

        public async Task<GenericApiResponse<InfoBookDTO>> UpdateBook(int Id, BookDTO request)
        {
            var client = _httpClientFactory.CreateClient("BackEnd");
            var bookJson = JsonConvert.SerializeObject(request);
            var content = new StringContent(bookJson, Encoding.UTF8, "application/json");
            var call = await client.PutAsync($"/api/Books/{Id}", content);
            var response = await HttpMessages<InfoBookDTO>(call);

            var jsonContent = await call.Content.ReadAsStringAsync();
            JObject jsonObject = JObject.Parse(jsonContent);
            InfoBookDTO book = JsonConvert.DeserializeObject<InfoBookDTO>(jsonObject["data"].ToString());
            response.Data = book;
            return response;
        }

        public async Task<GenericApiResponse<int>> DeleteBook(int Id)
        {
            var client = _httpClientFactory.CreateClient("BackEnd");
            var call = await client.DeleteAsync($"/api/Books/{Id}");
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
