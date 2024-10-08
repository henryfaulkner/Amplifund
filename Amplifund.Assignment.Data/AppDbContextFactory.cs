using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace Amplifund.Assignment.Data
{
    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args = null)
        {
            var builder = new DbContextOptionsBuilder<AppDbContext>();

            // I am going to just hard-code the connection string :P
            builder.UseSqlite($"Data Source=app_database.db;");
            return new AppDbContext(builder.Options);
        }
    }
}
