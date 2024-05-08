using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheHandymanOfCapeCod.Infrastructure.Data.Models;

namespace TheHandymanOfCapeCod.Infrastructure.Data.SeedDb
{
    internal class SeedData
    {
        public IdentityUser AdminUser { get; set; } = null!;
        public Project FirstProject { get; set; } = null!;
        public Project SecondProject { get; set; } = null!;
        public Project ThirdProject { get; set; } = null!;
        public Project FourthProject { get; set; } = null!;
        public Project FifthProject { get; set; } = null!;
        public Project SixthProject { get; set; } = null!;

        public SeedData()
        {
            SeedUsers();
            SeedProjects();
        }

        private void SeedUsers()
        {
            var hasher = new PasswordHasher<IdentityUser>();

            AdminUser = new IdentityUser()
            {
                Id = "1c6c8b9b-12fe-49d0-8ad4-8df4b1e38345",
                UserName = "admin@mail.com",
                NormalizedUserName = "ADMIN@MAIL.COM",
                Email = "admin@mail.com",
                NormalizedEmail = "ADMIN@MAIL.COM",
                EmailConfirmed = true
            };

            AdminUser.PasswordHash =
                hasher.HashPassword(AdminUser, "admin123");
        }

        private void SeedProjects()
        {
            FirstProject = new Project()
            {
                Id = 1,
                Title = "Clam door, best choice for your bulkhead replacement"
            };

            SecondProject = new Project()
            {
                Id = 2,
                Title = "Full house transformation"
            };

            ThirdProject = new Project()
            {
                Id = 3,
                Title = "New Andersen bay window"
            };

            FourthProject = new Project()
            {
                Id = 4,
                Title = "New decking"
            };

            FifthProject = new Project()
            {
                Id = 5,
                Title = "New mahogany lattice"
            };

            SixthProject = new Project()
            {
                Id = 6,
                Title = "New trash cans closure out of Cedar"
            };
        }

    }
}
