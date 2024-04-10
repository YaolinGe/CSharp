//using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace WebCam.Components.WebCam.Models
{
    public class WebCamDatabase : DbContext
    {
        public DbSet<WebCam> WebCams { get; set; }
        public string DbPath { get; }

        public WebCamDatabase(DbContextOptions<WebCamDatabase> options = null)
        {
            DbPath = "./WebCams.db";
            CheckDatabaseExists();
        }

        private void CheckDatabaseExists()
        {
            if (!File.Exists(DbPath))
            {
                Database.EnsureCreated();
            }
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite($"Data Source={DbPath}");
        }

        public async Task AddWebCamAsync(WebCam webCam)
        {
            var existingWebCam = await WebCams.FirstOrDefaultAsync(r => r.IPAddress == webCam.IPAddress || r.PortNumber == webCam.PortNumber || r.Name == webCam.Name);
            if (existingWebCam != null)
            {
                webCam.Id = GetUniqueWebCamId();
            }
            WebCams.Add(webCam);
            await SaveChangesAsync();
            Console.WriteLine("Added remote microscope to the database");
        }

        private int GetUniqueWebCamId()
        {
            int maxId = WebCams.Max(r => r.Id);
            return maxId + 1;
        }

        public async Task DeleteWebCamAsync(int id)
        {
            var remoteWebCam = await WebCams.FirstOrDefaultAsync(r => r.Id == id);
            if (remoteWebCam != null)
            {
                WebCams.Remove(remoteWebCam);
                await SaveChangesAsync();
                Console.WriteLine("Deleted remote microscope");
            }
        }

        public async Task<List<WebCam>> GetAllWebCamsAsync()
        {
            return await WebCams.ToListAsync();
        }
    }
}


