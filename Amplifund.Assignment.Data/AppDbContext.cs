using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Amplifund.Assignment.Domain.Entities.Base;
using Amplifund.Assignment.Domain.Entities.Common;
using Amplifund.Assignment.Domain.Entities.Grant;

namespace Amplifund.Assignment.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            AddAuditInfo();
            return await base.SaveChangesAsync(cancellationToken);
        }

        #region Common tables

        public virtual DbSet<State> State { get; set; }

        #endregion

        #region Grant tables

        public virtual DbSet<Grant> Grant { get; set; }
        public virtual DbSet<StateGrant> StateGrant { get; set; }

        #endregion

        #region Model Builder

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Grant>()
                .Property(g => g.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<StateGrant>()
                .Property(g => g.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<StateGrant>()
                .HasOne(sg => sg.Grant)
                .WithMany()
                .HasForeignKey(sg => sg.GrantId);

            modelBuilder.Entity<StateGrant>()
                .HasOne(sg => sg.State)
                .WithMany()
                .HasForeignKey(sg => sg.StateId);

            modelBuilder.Entity<State>().HasData(
            new State { Id = 1, Name = "Alabama", Code = "AL" },
            new State { Id = 2, Name = "Alaska", Code = "AK" },
            new State { Id = 3, Name = "Arizona", Code = "AZ" },
            new State { Id = 4, Name = "Arkansas", Code = "AR" },
            new State { Id = 5, Name = "California", Code = "CA" },
            new State { Id = 6, Name = "Colorado", Code = "CO" },
            new State { Id = 7, Name = "Connecticut", Code = "CT" },
            new State { Id = 8, Name = "Delaware", Code = "DE" },
            new State { Id = 9, Name = "Florida", Code = "FL" },
            new State { Id = 10, Name = "Georgia", Code = "GA" },
            new State { Id = 11, Name = "Hawaii", Code = "HI" },
            new State { Id = 12, Name = "Idaho", Code = "ID" },
            new State { Id = 13, Name = "Illinois", Code = "IL" },
            new State { Id = 14, Name = "Indiana", Code = "IN" },
            new State { Id = 15, Name = "Iowa", Code = "IA" },
            new State { Id = 16, Name = "Kansas", Code = "KS" },
            new State { Id = 17, Name = "Kentucky", Code = "KY" },
            new State { Id = 18, Name = "Louisiana", Code = "LA" },
            new State { Id = 19, Name = "Maine", Code = "ME" },
            new State { Id = 20, Name = "Maryland", Code = "MD" },
            new State { Id = 21, Name = "Massachusetts", Code = "MA" },
            new State { Id = 22, Name = "Michigan", Code = "MI" },
            new State { Id = 23, Name = "Minnesota", Code = "MN" },
            new State { Id = 24, Name = "Mississippi", Code = "MS" },
            new State { Id = 25, Name = "Missouri", Code = "MO" },
            new State { Id = 26, Name = "Montana", Code = "MT" },
            new State { Id = 27, Name = "Nebraska", Code = "NE" },
            new State { Id = 28, Name = "Nevada", Code = "NV" },
            new State { Id = 29, Name = "New Hampshire", Code = "NH" },
            new State { Id = 30, Name = "New Jersey", Code = "NJ" },
            new State { Id = 31, Name = "New Mexico", Code = "NM" },
            new State { Id = 32, Name = "New York", Code = "NY" },
            new State { Id = 33, Name = "North Carolina", Code = "NC" },
            new State { Id = 34, Name = "North Dakota", Code = "ND" },
            new State { Id = 35, Name = "Ohio", Code = "OH" },
            new State { Id = 36, Name = "Oklahoma", Code = "OK" },
            new State { Id = 37, Name = "Oregon", Code = "OR" },
            new State { Id = 38, Name = "Pennsylvania", Code = "PA" },
            new State { Id = 39, Name = "Rhode Island", Code = "RI" },
            new State { Id = 40, Name = "South Carolina", Code = "SC" },
            new State { Id = 41, Name = "South Dakota", Code = "SD" },
            new State { Id = 42, Name = "Tennessee", Code = "TN" },
            new State { Id = 43, Name = "Texas", Code = "TX" },
            new State { Id = 44, Name = "Utah", Code = "UT" },
            new State { Id = 45, Name = "Vermont", Code = "VT" },
            new State { Id = 46, Name = "Virginia", Code = "VA" },
            new State { Id = 47, Name = "Washington", Code = "WA" },
            new State { Id = 48, Name = "West Virginia", Code = "WV" },
            new State { Id = 49, Name = "Wisconsin", Code = "WI" },
            new State { Id = 50, Name = "Wyoming", Code = "WY" }
        );
        }

        #endregion

        private void AddAuditInfo()
        {
            var entities = ChangeTracker.Entries<AuditEntity>().Where(e => e.State == EntityState.Added || e.State == EntityState.Modified);

            var utcNow = DateTime.Now;

            foreach (var entity in entities)
            {
                if (entity.State == EntityState.Added)
                {
                    entity.Entity.CreatedDate = utcNow;
                    entity.Entity.ModifiedDate = utcNow;
                }

                if (entity.State == EntityState.Modified)
                {
                    entity.Entity.ModifiedDate = utcNow;
                }
            }
        }
    }
}
