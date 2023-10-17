using Core.Application.Services.API;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Http;


namespace Core.Application.Services
{
    public static class APIServiceRegistration
    {
        public static void ConfigureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHttpClient("BackEnd", client =>
            {
                client.BaseAddress = new Uri(configuration.GetSection("ApiSettings")["BaseUrl"]);
            });
            services.AddTransient<APIService>();
        }
    }
}
