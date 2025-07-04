using App.Web.Models;
using App.Web.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace App.Web.Pages
{
    public class ArticlesModel : PageModel
    {
        private readonly IBlogApiService _blogApiService;

        public ArticlesModel(IBlogApiService blogApiService)
        {
            _blogApiService = blogApiService;
        }

        public List<ArticleViewModel> Articles { get; set; } = new();

        public async Task OnGetAsync()
        {
            try
            {
                Articles = await _blogApiService.GetArticlesAsync(1, 10);
            }
            catch (Exception ex)
            {
                // Handle error appropriately
                Articles = new List<ArticleViewModel>();
            }
        }
    }
}

