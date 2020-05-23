using AcademiaDemo.Domain.Comum;
using System;
using System.Threading.Tasks;

namespace AcademiaDemo.Infrastructure.Repository.Gateway.Interfaces
{
    public interface IHttpClientGateway<TInput, TOutput>
    {
        Task<ClientRest<TOutput>> PostAsync(string url, TInput obj);
        Task<ClientRest<TOutput>> PutAsync(string url, Guid id);
    }
}