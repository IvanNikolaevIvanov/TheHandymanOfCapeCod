using Microsoft.AspNetCore.Http;
using TheHandymanOfCapeCod.Core.Models.Project;

namespace TheHandymanOfCapeCod.Core.Contracts
{
    public interface IProjectService
    {
        Task<IEnumerable<ProjectViewModel>> AllProjectsAsync(
            string sortOrder,
            string currentFilter,
            string searchString,
            int? pageNumber);

        Task<ProjectDetailsViewModel> ProjectDetailsByIdAsync(int id);

        Task<bool> ProjectExistsAsync(int id);

        Task AddProjectAsync(string title, DateTime dateTime);

        Task<int> GetLastProjectIdAsync();
    }
}
