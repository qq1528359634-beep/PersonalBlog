using Microsoft.EntityFrameworkCore;
using PersonalBlog.Models;

namespace PersonalBlog.Data
{
    public class BlogDbCotext : DbContext
    {
        public BlogDbCotext(DbContextOptions<BlogDbCotext> options) : base(options)
        {
            
        }
        public DbSet<Post> Posts { get; set; }
    }

}
