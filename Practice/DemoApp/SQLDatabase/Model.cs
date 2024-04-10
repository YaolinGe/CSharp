using Microsoft.EntityFrameworkCore;

namespace SQLDatabase
{
    public class BloggingContext : DbContext
    {
        public DbSet<Blog> Blogs { get; set; }
        public string DbPath { get; }

        public BloggingContext()
        {
            DbPath = "./blogs.db";
            CheckDatabaseExists();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite($"Data Source={DbPath}");
        }

        public void AddBlog(Blog blog)
        {
            var existingBlog = Blogs.FirstOrDefault(b => b.BlogId == blog.BlogId);
            if (existingBlog != null)
            {
                existingBlog.Url = blog.Url;
                SaveChanges();
                Console.WriteLine("Updated blog");
            }
            else
            {
                Blogs.Add(blog);
                SaveChanges();
                Console.WriteLine("Added blog");
            }
        }

        public void DeleteBlog(int blogId)
        {
            var blog = Blogs.FirstOrDefault(b => b.BlogId == blogId);
            if (blog != null)
            {
                Blogs.Remove(blog);
                SaveChanges();
                Console.WriteLine("Deleted blog");
            }

        }

        public void ViewBlogs()
        {
            foreach (var blog in Blogs)
            {
                Console.WriteLine($"BlogId: {blog.BlogId}, Url: {blog.Url}");
            }
        }

        private void CheckDatabaseExists()
        {
            if (!File.Exists(DbPath))
            {
                Database.EnsureCreated();
            }
        }
    }

    public class Blog
    {
        public int BlogId { get; set; }
        public string Url { get; set; }
    }
}
