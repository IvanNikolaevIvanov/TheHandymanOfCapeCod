using Microsoft.AspNetCore.Identity;
using TheHandymanOfCapeCod.Infrastructure.Data;
using TheHandymanOfCapeCod.Infrastructure.Data.Common;
using TheHandymanOfCapeCod.Infrastructure.Data.Models;
using TheHandymanOfCapeCod.Tests.Mocks;

namespace TheHandymanOfCapeCod.Tests.UnitTests
{
    public class UnitTestsBase
    {
        protected TheHandymanOfCapeCodDb data;
        protected IRepository testRepository;
        protected IEnumerable<Project> projects;

        [OneTimeSetUp]
        public void SetUpBase()
        {
            data = DatabaseMock.Instance;
            SeedDatabase();
            testRepository = new Repository(data);
        }

        public Project FirstProject { get; set; } = null!;
        public Project SecondProject { get; set; } = null!;
        public Project ThirdProject { get; set; } = null!;

        private void SeedDatabase()
        {
            FirstProject = new Project()
            {
                Id = 1,
                Title = "Clam door, best choice for your bulkhead replacement",
                DateCreated = DateTime.Now
            };

            SecondProject = new Project()
            {
                Id = 2,
                Title = "Full house transformation",
                DateCreated = DateTime.Now
            };

            ThirdProject = new Project()
            {
                Id = 3,
                Title = "New Andersen bay window",
                DateCreated = DateTime.Now
            };

            projects = new List<Project>()
            {
                FirstProject, SecondProject, ThirdProject
            };

            data.AddRangeAsync(projects);
            data.SaveChangesAsync();

        }

        [OneTimeTearDown]
        public async Task TearDownBase()
        {
            await data.Database.EnsureCreatedAsync();
            await data.DisposeAsync();
        }
    }
}
