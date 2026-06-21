namespace PersonalBlog.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string Content { get; set; } = string.Empty;
        public string AuthorName { get; set; } = string.Empty;
        public DateTime CreateAt { get; set; } = DateTime.UtcNow;


        //Foreign key references to Post
        public int PostId { get; set; }
        public Post post { get; set; } = default!;
    }
}
