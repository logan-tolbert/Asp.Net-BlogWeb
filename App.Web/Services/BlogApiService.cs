using App.Web.Models;
using System.Text.Json;

namespace App.Web.Services;

public class BlogApiService : IBlogApiService
{
    private readonly HttpClient _httpClient;
    private readonly IConfiguration _configuration;
    private readonly ILogger<BlogApiService> _logger;

    public BlogApiService(HttpClient httpClient, IConfiguration configuration, ILogger<BlogApiService> logger)
    {
        _httpClient = httpClient;
        _configuration = configuration;
        _logger = logger;
    }

    public async Task<List<ArticleViewModel>> GetArticlesAsync(int page = 1, int pageSize = 10)
    {
        try
        {
            var apiBaseUrl = _configuration["BlogApi:BaseUrl"];
            var response = await _httpClient.GetAsync($"{apiBaseUrl}/api/v0/articles?page={page}&pageSize={pageSize}");
            response.EnsureSuccessStatusCode();
            
            var json = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<List<ArticleViewModel>>(json, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            }) ?? new List<ArticleViewModel>();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to fetch articles from API");
            throw;
        }
    }

    public async Task<ArticleViewModel?> GetArticleByIdAsync(int id)
    {
        try
        {
            var apiBaseUrl = _configuration["BlogApi:BaseUrl"];
            var response = await _httpClient.GetAsync($"{apiBaseUrl}/api/v0/articles/{id}");
            
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<ArticleViewModel>(json, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
            }
            
            return null;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to fetch article {ArticleId} from API", id);
            throw;
        }
    }

    public async Task<List<string>> GetTagsAsync()
    {
        try
        {
            var apiBaseUrl = _configuration["BlogApi:BaseUrl"];
            var response = await _httpClient.GetAsync($"{apiBaseUrl}/api/v0/articles/tags");
            
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<List<string>>(json, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                }) ?? new List<string>();
            }
            
            return new List<string>();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to fetch tags from API");
            throw;
        }
    }
} 