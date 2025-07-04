using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using App.Web.Models;
using App.Web.Services;

namespace App.Web.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    private readonly IBlogApiService _blogApiService;

    public IndexModel(ILogger<IndexModel> logger, IBlogApiService blogApiService)
    {
        _logger = logger;
        _blogApiService = blogApiService;
    }

    public List<ArticleViewModel> RecentArticles { get; set; } = new();
    public List<string> PopularTags { get; set; } = new();
    public int TotalArticles { get; set; }
    public bool HasArticles => RecentArticles.Any();

    public async Task OnGetAsync()
    {
        try
        {
            // Fetch recent articles (limit to 3 for homepage)
            RecentArticles = await _blogApiService.GetArticlesAsync(1, 3);

            // Fetch popular tags
            PopularTags = await _blogApiService.GetTagsAsync();
            
            // Limit to top 8 tags for homepage
            PopularTags = PopularTags.Take(8).ToList();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to fetch data for homepage");
            // Continue with empty collections - homepage will still display
        }
    }
}
