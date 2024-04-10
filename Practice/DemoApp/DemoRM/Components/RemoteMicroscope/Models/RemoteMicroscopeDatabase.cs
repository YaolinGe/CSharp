//using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace DemoRM.Components.RemoteMicroscope.Models
{
    public class RemoteMicroscopeDatabase : DbContext
    {
        public DbSet<RemoteMicroscope> RemoteMicroscopes { get; set; }
        public string DbPath { get; }

        public RemoteMicroscopeDatabase(DbContextOptions<RemoteMicroscopeDatabase> options = null)
        {
            DbPath = "./RemoteMicroscopes.db";
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

        public async Task AddRemoteMicroscopeAsync(RemoteMicroscope remoteMicroscope)
        {
            var existingMicroscope = await RemoteMicroscopes.FirstOrDefaultAsync(r => r.IPAddress == remoteMicroscope.IPAddress || r.PortNumber == remoteMicroscope.PortNumber || r.Name == remoteMicroscope.Name);
            if (existingMicroscope != null)
            {
                remoteMicroscope.Id = GetUniqueMicroscopeId();
            }
            RemoteMicroscopes.Add(remoteMicroscope);
            await SaveChangesAsync();
            Console.WriteLine("Added remote microscope to the database");
        }

        private int GetUniqueMicroscopeId()
        {
            int maxId = RemoteMicroscopes.Max(r => r.Id);
            return maxId + 1;
        }

        public async Task DeleteRemoteMicroscopeAsync(int id)
        {
            var remoteMicroscope = await RemoteMicroscopes.FirstOrDefaultAsync(r => r.Id == id);
            if (remoteMicroscope != null)
            {
                RemoteMicroscopes.Remove(remoteMicroscope);
                await SaveChangesAsync();
                Console.WriteLine("Deleted remote microscope");
            }
        }

        public async Task<List<RemoteMicroscope>> GetAllRemoteMicroscopesAsync()
        {
            return await RemoteMicroscopes.ToListAsync();
        }
    }
}


