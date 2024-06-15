using NUnit.Framework.Internal.Execution;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheHandymanOfCapeCod.Core.Contracts;
using TheHandymanOfCapeCod.Core.Services;

namespace TheHandymanOfCapeCod.Tests.UnitTests
{
    public class ProjectServiceUnitTests : UnitTestsBase
    {
        private IProjectService projectService;

        [SetUp]
        public void SetUp() => projectService = new ProjectService(testRepository);

        [Test]
        public async Task ProjectExistsAsyncShouldReturnAnExistingProject()
        {
            // Arrange


            //Act

            // Assert
        }
    }
}
