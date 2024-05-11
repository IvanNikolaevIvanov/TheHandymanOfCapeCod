using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheHandymanOfCapeCod.Core.Models.Photo;
using TheHandymanOfCapeCod.Infrastructure.Data.Models;

namespace TheHandymanOfCapeCod.Core.Models.Project
{
    public class ProjectViewModel
    {

        public int Id { get; set; }


        public string Title { get; set; } = string.Empty;


        //public IEnumerable<PhotoViewModel> Photos { get; set; } = new List<PhotoViewModel>();
    }
}
