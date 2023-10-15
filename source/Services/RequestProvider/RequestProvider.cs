using DrasatHealthMobile.Helpers;
using DrasatHealthMobile.Models;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;

namespace DrasatHealthMobile.Services.RequestProvider;

public class RequestProvider : IRequestProvider
{

    private readonly Lazy<HttpClient> _httpClient =
        new(() =>
        {
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            return httpClient;
        }, LazyThreadSafetyMode.ExecutionAndPublication);

    public async Task<List<TResult>> GetAsync<TResult>(string uri, string token = "")
    {
        try
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get, uri);
            request.Headers.Add("Authorization", $"Bearer {token}");
            var response = await client.SendAsync(request);
            List<TResult> result = await response.Content.ReadFromJsonAsync<List<TResult>>();
            return result;
        }
        catch (Exception ex)
        {
            await Alerts.DisplayAlert(nameof(RequestProvider), nameof(GetAsync), ex.Message);
            return null;
        }
    }

    public async Task<PagedResponse<TResult>> GetPagedResponseAsync<TResult>(string uri, string token = "")
    {
        try
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get, uri);
            request.Headers.Add("Authorization", $"Bearer {token}");
            var response = await client.SendAsync(request);
            PagedResponse<TResult> result = await response.Content.ReadFromJsonAsync<PagedResponse<TResult>>();
            return result;
        }
        catch (Exception ex)
        {
            await Alerts.DisplayAlert(nameof(RequestProvider), nameof(GetPagedResponseAsync), ex.Message);
            return null;
        }
    }

    public async Task<List<TResult>> GetListAsync<TResult>(string uri, string token = "")
    {
        try
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get, uri);
            var response = await client.SendAsync(request);
            if (response != null)
            {
                List<TResult> result = await response.Content.ReadFromJsonAsync<List<TResult>>();
                return result;
            }
            else
                return null;
        }
        catch (Exception ex)
        {
            await Alerts.DisplayAlert(nameof(RequestProvider), nameof(GetListAsync), ex.Message);
            return null;
        }
    }

    public async Task<TResult> GetSingleAsync<TResult>(string uri, string token = "")
    {
        try
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get, uri);
            var response = await client.SendAsync(request);

            TResult result = await response.Content.ReadFromJsonAsync<TResult>();
            return result;
        }
        catch (Exception ex)
        {
            await Alerts.DisplayAlert(nameof(RequestProvider), nameof(GetSingleAsync), ex.Message);
            return default;
        }
    }

    public async Task<string> GetStringAsync(string uri, string token = "")
    {
        try
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get, uri);
            request.Headers.Add("Authorization", $"Bearer {token}");
            var response = await client.SendAsync(request);
            string result = await response.Content.ReadAsStringAsync();
            return result;
        }
        catch (Exception ex)
        {
            await Alerts.DisplayAlert(nameof(RequestProvider), nameof(GetPagedResponseAsync), ex.Message);
            return null;
        }
    }

    public async Task<TResult> PostSingleAsync<TResult, TTake>(string uri, TTake data, string token = "", string header = "")
    {
        try
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Post, uri);
            var content = new StringContent(JsonSerializer.Serialize(data), null, "application/json");
            request.Content = content;
            var response = await client.SendAsync(request);

            TResult result = await response.Content.ReadFromJsonAsync<TResult>();
            return result;
        }
        catch (Exception ex)
        {
            await Alerts.DisplayAlert(nameof(RequestProvider), nameof(PostSingleAsync), ex.Message);
            return default;
        }
    }

    public async Task<TResult> PutByQueryParamsAsync<TResult>(string uri, string token = "", string header = "")
    {
        try
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Put, uri);
            var response = await client.SendAsync(request);
            TResult result = await response.Content.ReadFromJsonAsync<TResult>();
            return result;
        }
        catch (Exception ex)
        {
            await Alerts.DisplayAlert(nameof(RequestProvider), nameof(PutByQueryParamsAsync), ex.Message);
            return default;
        }
    }













    public async Task<TResult> PostAsync<TResult>(string uri, TResult data, string token = "", string header = "")
    {
        HttpClient httpClient = GetOrCreateHttpClient(token);

        if (!string.IsNullOrEmpty(header))
        {
            RequestProvider.AddHeaderParameter(httpClient, header);
        }

        var content = new StringContent(JsonSerializer.Serialize(data));
        content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
        HttpResponseMessage response = await httpClient.PostAsync(uri, content).ConfigureAwait(false);

        //await RequestProvider.HandleResponse(response).ConfigureAwait(false);
        TResult result = await response.Content.ReadFromJsonAsync<TResult>();

        return result;

    }

    public async Task<TResult> PostAsync<TResult>(string uri, string data, string clientId, string clientSecret)
    {
        HttpClient httpClient = GetOrCreateHttpClient(string.Empty);

        if (!string.IsNullOrWhiteSpace(clientId) && !string.IsNullOrWhiteSpace(clientSecret))
        {
            //RequestProvider.AddBasicAuthenticationHeader(httpClient, clientId, clientSecret);
        }

        var content = new StringContent(data);
        content.Headers.ContentType = new MediaTypeHeaderValue("application/x-www-form-urlencoded");
        HttpResponseMessage response = await httpClient.PostAsync(uri, content).ConfigureAwait(false);

        //await RequestProvider.HandleResponse(response).ConfigureAwait(false);
        TResult result = await response.Content.ReadFromJsonAsync<TResult>();

        return result;
    }

    public async Task<TResult> PutAsync<TResult>(string uri, TResult data, string token = "", string header = "")
    {
        HttpClient httpClient = GetOrCreateHttpClient(token);

        if (!string.IsNullOrEmpty(header))
        {
            RequestProvider.AddHeaderParameter(httpClient, header);
        }

        var content = new StringContent(JsonSerializer.Serialize(data));
        content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
        HttpResponseMessage response = await httpClient.PutAsync(uri, content).ConfigureAwait(false);

        //await RequestProvider.HandleResponse(response).ConfigureAwait(false);
        TResult result = await response.Content.ReadFromJsonAsync<TResult>();

        return result;
    }

    public async Task DeleteAsync(string uri, string token = "")
    {
        HttpClient httpClient = GetOrCreateHttpClient(token);
        await httpClient.DeleteAsync(uri).ConfigureAwait(false);
    }

    private HttpClient GetOrCreateHttpClient(string token = "")
    {
        var httpClient = _httpClient.Value;

        httpClient.DefaultRequestHeaders.Authorization =
            !string.IsNullOrEmpty(token)
                ? new AuthenticationHeaderValue("Bearer", token)
                : null;

        return httpClient;
    }

    private static void AddHeaderParameter(HttpClient httpClient, string parameter)
    {
        if (httpClient == null)
            return;

        if (string.IsNullOrEmpty(parameter))
            return;

        httpClient.DefaultRequestHeaders.Add(parameter, Guid.NewGuid().ToString());
    }

    //private static void AddBasicAuthenticationHeader(HttpClient httpClient, string clientId, string clientSecret)
    //{
    //    if (httpClient == null)
    //        return;

    //    if (string.IsNullOrWhiteSpace(clientId) || string.IsNullOrWhiteSpace(clientSecret))
    //        return;

    //    //httpClient.DefaultRequestHeaders.Authorization = new BasicAuthenticationHeaderValue(clientId, clientSecret);
    //}

    //private static async Task HandleResponse(HttpResponseMessage response)
    //{
    //    if (!response.IsSuccessStatusCode)
    //    {
    //        var content = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

    //        if (response.StatusCode == HttpStatusCode.Forbidden ||
    //                response.StatusCode == HttpStatusCode.Unauthorized)
    //        {
    //            //throw new ServiceAuthenticationException(content);
    //        }

    //       // throw new HttpRequestExceptionEx(response.StatusCode, content);
    //    }
    //}
}