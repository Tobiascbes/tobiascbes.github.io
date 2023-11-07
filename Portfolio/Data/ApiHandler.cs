using System;
using RestSharp;
namespace Portfolio.Data;

public class ApiHandler
{
    private IConfiguration _configuration;
    public List<GithubInfo> githubInfos()
	{
		RestClient restClient = new("https://api.github.com/user/repos");
		RestRequest restRequest = new();
        restRequest.AddHeader("Authorization", $"Bearer {_configuration["BearerToken:GithubApi"]}");
        return restClient.Get<List<GithubInfo>>(restRequest);
    }
    public ApiHandler(IConfiguration configuration)
    {
        _configuration = configuration;
    }

}
public class GithubInfo
{
    public int ID { get; set; }
    public string? Name { get; set; }
    public string? Login { get; set; }
    public string? Html_Url { get; set; }
    public DateTime Created_At { get; set; }
    public DateTime Updated_At { get; set; }
   

    public GithubInfo(int id, string name, string login, string html_url, DateTime created_at, DateTime updated_at)
    {
        ID = id;
        Name = name;
        Login = login;
        Html_Url = html_url;
        Created_At = created_at;
        Updated_At = updated_at;
    }
}

