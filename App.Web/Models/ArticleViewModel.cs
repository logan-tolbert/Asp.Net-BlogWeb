using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Web.Models
{
    public class ArticleViewModel
    {
      
        public int Id { get; set; }

        
        public string Title { get; set; } = string.Empty!;

      
        public string Content { get; set; } = string.Empty!;

      
        public string Author { get; set; } = string.Empty!;

        public string Tags { get; set; } = string.Empty!;

        public DateTime CreatedAt { get; set; }

       
        public DateTime UpdatedAt { get; set; }

    }
}
