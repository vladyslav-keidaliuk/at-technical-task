using System.Net;
using Business.Models;
using Newtonsoft.Json;
using RestSharp;

namespace Business;

public class FailedLoginHistoryService
{
    private readonly RestClient _client;

    public FailedLoginHistoryService(string baseUrl)
    {
        _client = new RestClient(baseUrl);
    }

    public async Task<List<UserLoginFailTotal>> GetLoginFailTotal(LoginFailTotalParams parameters)
    {
        // Creating a request
        RestRequest request = new RestRequest("/loginfailtotal", Method.Get);

        // Adding query parameters
        if (!string.IsNullOrEmpty(parameters.UserName))
            request.AddParameter("user_name", parameters.UserName);

        if (parameters.FailCount.HasValue)
            request.AddParameter("fail_count", parameters.FailCount.Value);

        if (parameters.FetchLimit.HasValue)
            request.AddParameter("fetch_limit", parameters.FetchLimit.Value);

        // Query execution and get response
        RestResponse response = await _client.ExecuteAsync(request);
        

        if (response.IsSuccessful)
        {
            // Deserialization of the response
            List<UserLoginFailTotal> result = JsonConvert.DeserializeObject<List<UserLoginFailTotal>>(response.Content);
            
            return result;
        }
        else
        {
            throw new Exception($"Request failed with status code {response.StatusCode}: {response.ErrorMessage}");
        }
    }

    public async Task<HttpStatusCode> ResetLoginFailTotal(string username)
    {
        // Create a query to reset the number of failed login attempts.
        RestRequest request = new RestRequest("/resetloginfailtotal", Method.Put);

        // Add JSON request body with username
        request.AddJsonBody(new { Username = username });

        RestResponse response = await _client.ExecuteAsync(request);

        return response.StatusCode;
    }
}