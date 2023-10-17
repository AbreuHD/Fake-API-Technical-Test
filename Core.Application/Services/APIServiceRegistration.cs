using Core.Application.Services.API;
using Core.Application.Services.FakeAPI;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Http;


namespace Core.Application.Services
{
    public static class APIServiceRegistration
    {
        public static void ConfigureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHttpClient("FakeAPI", client =>
            {
                client.BaseAddress = new Uri(configuration.GetSection("ApiSettings")["FakeAPIUrl"]);
            });
            services.AddHttpClient("BackEnd", client =>
            {
                client.BaseAddress = new Uri(configuration.GetSection("ApiSettings")["APIBackUrl"]);
            });

            services.AddTransient<FakeAPIService>();
            services.AddTransient<APICallService>();
        }
    }
}
