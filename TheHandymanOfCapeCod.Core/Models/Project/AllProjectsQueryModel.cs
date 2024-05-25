using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheHandymanOfCapeCod.Core.Models.Project
{
    public class AllProjectsQueryModel
    {
        public string sortOrder { get; set; }

        public int projectsPerPage { get; } = 10;

        public int currentPage { get; init; } = 1;

        public int totalProjectsCount { get; set; }

        public IEnumerable<ProjectViewModel> Projects { get; set; } = new List<ProjectViewModel>();
    }
}
