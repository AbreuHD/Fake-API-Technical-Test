using Core.Application.DTOs;
using Newtonsoft.Json;
using System.Globalization;
using System.Net;
using System.Text;

namespace UnitTest
{
    [TestClass]
    public class UjnitTest1
    {
        BookDTO defaultBook = new BookDTO
        {
            Title = "Harry Potter y la piedra filosofal",
            Description = "Harry Potter y la piedra filosofal es el primer volumen de la ya clásica serie de novelas fantásticas de la autora británica J.K. Rowling.",
            Excerpt = "Con las manos temblorosas, Harry le dio la vuelta al sobre y vio un  sello de lacre púrpura con un escudo de armas: un león, un águila, un tejón y una serpiente, que rodeaban una gran letra H.",
            PageCount = 264,
            PublishDate = DateTime.ParseExact("01-03-1999", "dd-MM-yyyy", CultureInfo.InvariantCulture)
        };


        [TestMethod]
        public async Task DeleteBook()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage();

            request.RequestUri = new Uri("https://localhost:7251/api/Books/1");
            request.Method = HttpMethod.Delete;
            request.Headers.Add("Accept", "*/*");

            var call = await client.SendAsync(request);
            var result = await call.Content.ReadAsStringAsync();
            var response = JsonConvert.DeserializeObject<GenericApiResponse<int>>(result);
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

        [TestMethod]
        public async Task UpdateBook()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage();

            request.RequestUri = new Uri("https://localhost:7251/api/Books/1");
            request.Method = HttpMethod.Put;
            request.Headers.Add("Accept", "application/json");

            var jsonContent = JsonConvert.SerializeObject(defaultBook);
            request.Content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            var call = await client.SendAsync(request);
            var result = await call.Content.ReadAsStringAsync();
            var response = JsonConvert.DeserializeObject<GenericApiResponse<InfoBookDTO>>(result);

            Assert.AreEqual(response.Data.Description, defaultBook.Description);
        }

        [TestMethod]
        public async Task GetNegativeId()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage();
            request.RequestUri = new Uri("https://localhost:7251/api/Books/-1");
            request.Method = HttpMethod.Get;
            request.Headers.Add("Accept", "*/*");

            var call = await client.SendAsync(request);
            Assert.AreEqual(HttpStatusCode.OK, call.StatusCode);
        }
    }
}