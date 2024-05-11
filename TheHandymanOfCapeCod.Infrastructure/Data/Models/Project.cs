using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static TheHandymanOfCapeCod.Infrastructure.Constants.DataConstants;

namespace TheHandymanOfCapeCod.Infrastructure.Data.Models
{
    [Comment("Project info")]
    public class Project
    {
        [Key]
        [Comment("Project Identifier")]
        public int Id { get; set; }

        [Required]
        [MaxLength(TitleMaxLength)]
        [Comment("Project Title")]
        public string Title { get; set; } = string.Empty;

        [Required]
        public DateTime DateCreated { get; set; } = DateTime.Now;

        [Comment("List of project's photos")]
        public List<Photo> Photos { get; set; } = new List<Photo>();

    }
}
