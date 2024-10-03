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
            var solutionDir = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName; 
            var relativePath = Path.Combine(solutionDir, "Amplifund.Assignment.Data", "app_database.db");

            builder.UseSqlite($"Data Source={relativePath};");
            return new AppDbContext(builder.Options);
        }
    }
}
