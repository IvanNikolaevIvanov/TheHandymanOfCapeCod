using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static TheHandymanOfCapeCod.Infrastructure.Constants.DataConstants;

namespace TheHandymanOfCapeCod.Infrastructure.Data.Models
{
    public class Photo
    {
        [Key]
        public int Id { get; set; }

        [Comment("Image as byte[]")]
        public byte[] ImageData { get; set; } = new byte[0];

        [Required]
        [Comment("Photo's project identifier")]
        public int ProjectId { get; set; }

        [ForeignKey(nameof(ProjectId))]
        public Project Project { get; set; } = null!;
    }
}
