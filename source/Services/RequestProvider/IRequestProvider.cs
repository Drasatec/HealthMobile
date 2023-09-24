using DrasatHealthMobile.Models;

namespace DrasatHealthMobile.Services.RequestProvider;

public interface IRequestProvider
{
    Task<List<TResult>> GetAsync<TResult>(string uri, string token = "");

    Task<TResult> PostAsync<TResult>(string uri, TResult data, string token = "", string header = "");

    Task<TResult> PostAsync<TResult>(string uri, string data, string clientId, string clientSecret);

    Task<TResult> PutAsync<TResult>(string uri, TResult data, string token = "", string header = "");

    Task DeleteAsync(string uri, string token = "");
    Task<PagedResponse<TResult>> GetPagedResponseAsync<TResult>(string uri, string token = "");
    Task<List<TResult>> GetListAsync<TResult>(string uri, string token = "");
    Task<string> GetStringAsync(string uri, string token = "");
    Task<TResult> PostSingleAsync<TResult, TTake>(string uri, TTake data, string token = "", string header = "");
}
