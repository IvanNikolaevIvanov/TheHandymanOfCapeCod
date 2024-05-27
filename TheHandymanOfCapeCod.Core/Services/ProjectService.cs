using Microsoft.EntityFrameworkCore;
using System.Net.NetworkInformation;
using System.Reflection.PortableExecutable;
using TheHandymanOfCapeCod.Core.Contracts;
using TheHandymanOfCapeCod.Core.Models.Project;
using TheHandymanOfCapeCod.Infrastructure.Constants;
using TheHandymanOfCapeCod.Infrastructure.Data.Common;
using TheHandymanOfCapeCod.Infrastructure.Data.Models;
using TheHandymanOfCapeCod.Core.Tools;


namespace TheHandymanOfCapeCod.Core.Services
{
    public class ProjectService : IProjectService
    {
        private readonly IRepository repository;


        public ProjectService(
            IRepository _repository)
        {
            repository = _repository;

        }

        public async Task AddProjectAsync(string title, DateTime dateTime)
        {
            var newProject = new Project()
            {
                Title = title,
                DateCreated = dateTime
            };

            await repository.AddAsync(newProject);
            await repository.SaveChangesAsync();

        }

        public async Task<IEnumerable<ProjectViewModel>> AllProjectsAsync(
            string sortOrder,
            string currentFilter,
            string searchString,
            int? pageNumber)
        {

            
            var projects = repository.AllReadOnly<Project>();

            if (!String.IsNullOrEmpty(searchString))
            {
                projects = projects
                    .Where(p => p.Title.ToUpper().Contains(searchString.ToUpper()));
            }

            switch (sortOrder)
            {
                case "title_desc":
                    projects = projects.OrderByDescending(p => p.Title);
                    break;
                case "Date":
                    projects = projects.OrderBy(p => p.DateCreated);
                    break;
                case "Title":
                    projects = projects.OrderBy(p => p.Title);
                    break;
                default:
                    projects = projects.OrderByDescending(p => p.DateCreated);
                    break;
            }

            int pageSize = 3;



            var projectsToReturn = await projects
                .Select(p => new ProjectViewModel()
                {
                    Id = p.Id,
                    Title = p.Title,
                    Date = p.DateCreated.ToString(DataConstants.DateFormat)
                })
                .ToListAsync();

            return PaginatedList<ProjectViewModel>.CreateAsync(projectsToReturn, pageNumber ?? 1, pageSize);

        }

        public async Task EditAsync(int id, string title, DateTime dateTime )
        {
            var projectToEdit = await repository.GetByIdAsync<Project>(id);
            if (projectToEdit != null)
            {
                projectToEdit.Title = title;
                projectToEdit.DateCreated = dateTime;

                await repository.SaveChangesAsync();
            }
        }

        public async Task<int> GetLastProjectIdAsync()
        {
            return await repository.AllReadOnly<Project>()
                .Select(p => p.Id)
                .OrderBy(x => x)
                .LastAsync();
        }

        public async Task<AddProjectFormModel> GetProjectFormByIdAsync(int id)
        {
            var projectToEdit = await repository.GetByIdAsync<Project>(id);
            var model = new AddProjectFormModel();
            if (projectToEdit != null)
            {
                model.Title = projectToEdit.Title;
                model.ProjectStartDate = projectToEdit.DateCreated.ToString();
            }
            
            return model;
        }

        public async Task<ProjectDetailsViewModel> ProjectDetailsByIdAsync(int id)
        {
            return await repository.AllReadOnly<Project>()
                .Where(p => p.Id == id)
                .Include(p => p.Photos)
                .Select(p => new ProjectDetailsViewModel()
                {
                    Id = p.Id,
                    Title = p.Title,
                    ProjectStartDate = p.DateCreated.ToString(DataConstants.DateFormat),
                    Photos = p.Photos.Select(p => new Models.Photo.PhotoViewModel()
                    {
                        Id = p.Id,
                        ImageData = p.ImageData,
                        ProjectId = p.Id
                    }).ToList()
                })
                .FirstAsync();
        }

        public async Task<bool> ProjectExistsAsync(int id)
        {
            return await repository.AllReadOnly<Project>()
                .AnyAsync(p => p.Id == id);
        }
    }
}
