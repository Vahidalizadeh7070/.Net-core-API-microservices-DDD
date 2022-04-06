using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using PlatformService.DTO;

namespace PlaformServices.SyncDataServices.http
{
    public class HttpCommandDataClient : ICommandDataClient
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public HttpCommandDataClient(IConfiguration configuration,HttpClient httpClient)
        {
            _httpClient=httpClient;
            _configuration=configuration;
        }
        public async Task SendPlatformToCommand(PlatformReadDTO plat)
        {
            var httpContent=new StringContent(
                JsonSerializer.Serialize(plat),
                Encoding.UTF8,
                "application/json"
            );
            var response=await _httpClient.PostAsync($"{_configuration["CommandService"]}",httpContent);
            if(response.IsSuccessStatusCode)
            {
                Console.WriteLine("--> Sync POST to CommandService was OK");
            }
            else
            {
                Console.WriteLine("--> Sync POST to CommandService was NOT OK");
            }
        }
    }
}