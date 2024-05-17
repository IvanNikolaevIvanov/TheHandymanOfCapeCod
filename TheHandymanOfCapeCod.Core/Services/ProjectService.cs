using Microsoft.EntityFrameworkCore;
using TheHandymanOfCapeCod.Core.Contracts;
using TheHandymanOfCapeCod.Core.Models.Project;
using TheHandymanOfCapeCod.Infrastructure.Constants;
using TheHandymanOfCapeCod.Infrastructure.Data.Common;
using TheHandymanOfCapeCod.Infrastructure.Data.Models;

namespace TheHandymanOfCapeCod.Core.Services
{
    public class ProjectService : IProjectService
    {
        private readonly IRepository repository;

        public ProjectService(IRepository _repository)
        {
            repository = _repository;
        }

        public async Task<IEnumerable<ProjectViewModel>> AllProjectsAsync()
        {
            var projectsToShow = await repository.AllReadOnly<Project>()
                .OrderByDescending(p => p.DateCreated)
                .Select(p => new ProjectViewModel()
                {
                    Id = p.Id,
                    Title = p.Title,
                    ProjectStartDate = p.DateCreated.ToString(DataConstants.DateFormat)
                })
                .ToListAsync();
                

            return projectsToShow;
        }
    }
}
