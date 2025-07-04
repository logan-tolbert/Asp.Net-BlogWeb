using App.Web.Models;

namespace App.Web.Services;

public interface IBlogApiService
{
    Task<List<ArticleViewModel>> GetArticlesAsync(int page = 1, int pageSize = 10);
    Task<ArticleViewModel?> GetArticleByIdAsync(int id);
    Task<List<string>> GetTagsAsync();
} 