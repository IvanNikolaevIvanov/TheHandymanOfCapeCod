using TheHandymanOfCapeCod.Core.Models.Photo;

namespace TheHandymanOfCapeCod.Core.Models.Project
{
    public class ProjectDetailsViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public string ProjectStartDate { get; set; } = string.Empty;

        public List<PhotoViewModel> Photos { get; set; } = new List<PhotoViewModel>();
    }
}
