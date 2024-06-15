using TheHandymanOfCapeCod.Core.Contracts;
using TheHandymanOfCapeCod.Core.Models.Project;
using TheHandymanOfCapeCod.Core.Services;
using TheHandymanOfCapeCod.Infrastructure.Data.Models;

namespace TheHandymanOfCapeCod.Tests.UnitTests
{
    public class ProjectServiceUnitTests : UnitTestsBase
    {
        private IProjectService projectService;

        [SetUp]
        public void SetUp() => projectService = new ProjectService(testRepository);

        [Test]
        public async Task ProjectExistsAsyncShouldReturnAnExistingProjectById()
        {
            // Arrange
            int id = 1;

            //Act
            var result = await projectService.ProjectExistsAsync(id);

            // Assert

            Assert.That(result, Is.True);
        }

        [Test]
        public async Task AddProjectAsyncShouldAddProject()
        {
            // Arrange 
            string projectTitle = "TestProject";
            var dateTime = DateTime.Now;


            // Act

            await projectService.AddProjectAsync(projectTitle, dateTime);
            bool newProjectExists = await projectService.ProjectExistsAsync(4);

            // Assert

            Assert.That(newProjectExists, Is.True);
        }

        [Test]
        public async Task GetRecentProjectsAsyncShouldReturnNumberOfProjects()
        {
            // Arrange
            int expNumberOfPrjects = 3;

            // Act
            var projects = await projectService.GetRecentProjectsAsync(3, 1);

            // Assert
            Assert.That(expNumberOfPrjects, Is.EqualTo(projects.Count()));
        }

        [Test]
        public async Task AllProjectsAsyncShouldReturnDefaultSortOrder()
        {
            // Arrange

            // Act
            var projects = await projectService.AllProjectsAsync("", "", "", null);
            // Assert
            Assert.That(projects.Count, Is.EqualTo(3));
        }

        [Test]
        public async Task AllProjectsAsyncShouldReturnCorrectSearchString()
        {
            // Arrange
            string searchString = "Clam door";
            // Act
            var projects = await projectService.AllProjectsAsync("", "", searchString, null);
            // Assert
            Assert.That(projects.Count, Is.EqualTo(1));
        }

        [Test]
        public async Task GetProjectByIdAsyncShouldReturnExistingProject()
        {
            // Arrange
            int expectedProjectId = 1;
            // Act
            var project = await projectService.GetProjectByIdAsync(1);
            // Assert
            Assert.That(project.Id, Is.EqualTo(expectedProjectId));
        }

        [Test]
        public async Task EditAsyncShouldEditAnExistingProject()
        {
            // Arrange

            string newTitle = "NewTitle";
            DateTime newDateTime = DateTime.Now;

            // Act

            await projectService.EditAsync(1, newTitle, newDateTime);

            var editedProject = await projectService.GetProjectByIdAsync(1);

            // Assert

            Assert.That(editedProject.Title, Is.EqualTo(newTitle));
            Assert.That(editedProject.Date, Is.EqualTo(newDateTime.ToString()));
        }

        [Test]
        public async Task GetLastProjectIdAsyncShouldReturnLastProject()
        {
            // Arrange

            int expectedProjectId = 3;

            // Act

            var lastProjectId = await projectService.GetLastProjectIdAsync();

            // Assert

            Assert.AreEqual(expectedProjectId, lastProjectId);
        }

        [Test]
        public async Task GetProjectFormByIdAsyncShouldReturnFormWithProjectInfo()
        {
            // Arrange
            string expectedProjectTitle = "Clam door, best choice for your bulkhead replacement";

            // Act
            var project = await projectService.GetProjectFormByIdAsync(1);

            // Assert
            Assert.That(expectedProjectTitle, Is.EqualTo(project.Title));
        }

        [Test]
        public async Task ProjectDetailsByIdAsyncReturnsExistingProjectDetails()
        {
            // Arrange
            string expectedProjectTitle = "Clam door, best choice for your bulkhead replacement";
            int expectedProjectId = 1;
            int expectedProjectPhotos = 0;
            var expectedProjectType = nameof(ProjectDetailsViewModel);
            // Act

            var project = await projectService.ProjectDetailsByIdAsync(1);

            var actualProjectTitle = project.Title;
            var actualProjectId = project.Id;
            var actualProjectPhotosCount = project.Photos.Count;
            var actualProjectType = project.GetType().Name;
            // Assert

            Assert.That(expectedProjectTitle, Is.EqualTo(actualProjectTitle));
            Assert.That(expectedProjectId, Is.EqualTo(actualProjectId));
            Assert.That(expectedProjectPhotos, Is.EqualTo(actualProjectPhotosCount));
            Assert.That(expectedProjectType, Is.EqualTo(actualProjectType));
        }

        [Test]
        public async Task DeleteProjectAsyncShouldDeleteProject()
        {
            // Arrange
            string projectTitle = "TestProject";
            var dateTime = DateTime.Now;

            await projectService.AddProjectAsync(projectTitle, dateTime);

            var expectedProjectsCount = 3;
            // Act

            await projectService.DeleteProjectAsync(4);

            var projects = await projectService.AllProjectsAsync("","","",null);
            int actualProjectsCountAfterDelete = projects.Count();
            // Assert

            Assert.That(expectedProjectsCount, Is.EqualTo(actualProjectsCountAfterDelete));
        }
    }
}
