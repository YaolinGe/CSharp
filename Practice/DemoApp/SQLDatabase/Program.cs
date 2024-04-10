using SQLDatabase;

class Program
{
    static void Main(string[] args)
    {
        // Create an instance of BloggingContext
        var context = new BloggingContext();

        // Add a blog
        var blog = new Blog { BlogId = 1, Url = "https://example.com" };
        context.AddBlog(blog);
        context.ViewBlogs();

        // Add another blog
        blog = new Blog { BlogId = 2, Url = "https://example2.com" };
        context.AddBlog(blog);
        context.ViewBlogs();

        blog = new Blog { BlogId = 3, Url = "https://example3.com" };
        context.AddBlog(blog);
        context.ViewBlogs();

        // Delete a blog
        //context.DeleteBlog(1);
        //context.ViewBlogs();

        //// Delete another blog
        //context.DeleteBlog(2);
        //context.ViewBlogs();

        // View all blogs
        context.ViewBlogs();

        Console.ReadLine();
    }
}
