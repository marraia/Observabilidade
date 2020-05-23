using AcademiaDemo.Domain.Comum;
using AcademiaDemo.Infrastructure.Repository.Gateway.Interfaces;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AcademiaDemo.Infrastructure.Repository.Gateway
{
    public class HttpClientGateway<TInput, TOutput> : IHttpClientGateway<TInput, TOutput>
        where TInput : class
        where TOutput : class
    {
        private readonly IHttpClientFactory _clientFactory;
        public HttpClientGateway(
            IHttpClientFactory clientFactory
        )
        {
            _clientFactory = clientFactory;
        }

        public async Task<ClientRest<TOutput>> PostAsync(string url, TInput obj)
        {
            var client = _clientFactory.CreateClient();
            string json = System.Text.Json.JsonSerializer.Serialize(obj);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PostAsync(url, data);

            if (!response.IsSuccessStatusCode)
            {
                return new ClientRest<TOutput>()
                {
                    Success = false,
                    ErrorMessage = await response.Content.ReadAsStringAsync()
                };
            }

            var restSuccess = await response.Content.ReadAsStringAsync();

            return new ClientRest<TOutput>()
            {
                Success = true,
                ReadToObject = JsonConvert.DeserializeObject<TOutput>(restSuccess)
            };
        }

        public async Task<ClientRest<TOutput>> PutAsync(string url, Guid id)
        {
            var client = _clientFactory.CreateClient();
            var data = new StringContent("", Encoding.UTF8, "application/json");

            var response = await client.PutAsync($"{url}/{id}", data);

            if (!response.IsSuccessStatusCode)
            {
                return new ClientRest<TOutput>()
                {
                    Success = false,
                    ErrorMessage = await response.Content.ReadAsStringAsync()
                };
            }

            var restSuccess = await response.Content.ReadAsStringAsync();

            return new ClientRest<TOutput>()
            {
                Success = true,
                ReadToObject = JsonConvert.DeserializeObject<TOutput>(restSuccess)
            };
        }
    }
}
