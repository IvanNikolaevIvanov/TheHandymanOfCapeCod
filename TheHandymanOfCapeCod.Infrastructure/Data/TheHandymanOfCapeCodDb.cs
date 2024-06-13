using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using TheHandymanOfCapeCod.Infrastructure.Data.Models;
using TheHandymanOfCapeCod.Infrastructure.Data.SeedDb;

namespace TheHandymanOfCapeCod.Infrastructure.Data
{
    public class TheHandymanOfCapeCodDb : IdentityDbContext
    {
        private bool _seedDb;

        public TheHandymanOfCapeCodDb(DbContextOptions<TheHandymanOfCapeCodDb> 
            options, bool seed = true)
            : base(options)
        {
            if (Database.IsRelational())
            {
                Database.Migrate();
            }
            else
            {
                Database.EnsureCreated();
            }

            _seedDb = seed;
        }

        public DbSet<Photo> Photos { get; set; } = null!;

        public DbSet<Project> Projects { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            if (_seedDb)
            {
                builder.ApplyConfiguration(new UserConfiguration());
                builder.ApplyConfiguration(new ProjectConfiguration());
            }
            
            base.OnModelCreating(builder);
        }
    }
}
