using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using static TheHandymanOfCapeCod.Core.Constants.MessageConstants;
using static TheHandymanOfCapeCod.Infrastructure.Constants.DataConstants;

namespace TheHandymanOfCapeCod.Core.Models.Project
{
    public class AddProjectFormModel
    {
        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(TitleMaxLength,
            MinimumLength = TitleMinLength,
            ErrorMessage = LengthMessage)]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredMessage)]
        public string ProjectStartDate { get; set; } = string.Empty;

        //public List<IFormFile> Files = new List<IFormFile>();
    }
}
