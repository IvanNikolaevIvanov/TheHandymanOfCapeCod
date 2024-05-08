using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TheHandymanOfCapeCod.Infrastructure.Data.Models;

namespace TheHandymanOfCapeCod.Infrastructure.Data.SeedDb
{
    internal class ProjectConfiguration : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            var data = new SeedData();

            builder
                .HasData(new Project[]
                {   data.FirstProject,
                    data.SecondProject,
                    data.ThirdProject,
                    data.FourthProject,
                    data.FifthProject,
                    data.SixthProject });
        }
    }
}
