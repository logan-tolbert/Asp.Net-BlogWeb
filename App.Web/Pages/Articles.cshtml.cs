using App.Web.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Http;
using System.Text.Json;

namespace App.Web.Pages
{
    public class ArticlesModel : PageModel
    {
        private readonly HttpClient _httpClient;

        public ArticlesModel(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public List<ArticleViewModel> Articles { get; set; } = new();

        public async Task OnGetAsync()
        {
            // Adjust the API endpoint as needed
            var response = await _httpClient.GetAsync("https://webapp-dev-web-eua-blogapi-c8d8a8exghf8bpg9.eastus2-01.azurewebsites.net/api/v0/articles?page=1&pageSize=10");
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();

            // Adjust deserialization as needed to match your API response
            Articles = JsonSerializer.Deserialize<List<ArticleViewModel>>(json, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            }) ?? new List<ArticleViewModel>();
           
        }
    }
}

