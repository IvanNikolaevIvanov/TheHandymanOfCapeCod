using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TheHandymanOfCapeCod.Infrastructure.Data.Models;

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
    }
}
