using TheHandymanOfCapeCod.Core.Models.Project;

namespace TheHandymanOfCapeCod.Core.Contracts
{
    public interface IProjectService
    {
        Task<IEnumerable<ProjectViewModel>> AllProjectsAsync();

    }
}
