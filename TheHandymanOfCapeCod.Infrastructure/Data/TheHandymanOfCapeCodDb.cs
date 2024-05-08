using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TheHandymanOfCapeCod.Infrastructure.Data.Models;
using TheHandymanOfCapeCod.Infrastructure.Data.SeedDb;

namespace The_Handyman_Of_Cape_Cod.Infrastructure.Data
{
    public class TheHandymanOfCapeCodDb : IdentityDbContext
    {
        public TheHandymanOfCapeCodDb(DbContextOptions<TheHandymanOfCapeCodDb> options)
            : base(options)
        {
        }

        public DbSet<Photo> Photos { get; set; } = null!;

        public DbSet<Project> Projects { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new UserConfiguration());
            builder.ApplyConfiguration(new ProjectConfiguration());

            base.OnModelCreating(builder);
        }
    }
}
