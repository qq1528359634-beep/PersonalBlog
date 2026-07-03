using System.ComponentModel.DataAnnotations;

namespace PersonalBlog.Models
{
    public class Post
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "The Title can not be null")]
        [MaxLength(100, ErrorMessage = "Title must not exceed 100 characters")]
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public string Slug { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool IsPublished { get; set; }
    }
}
