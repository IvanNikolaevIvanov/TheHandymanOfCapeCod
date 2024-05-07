using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static TheHandymanOfCapeCod.Infrastructure.Constants.DataConstants;

namespace TheHandymanOfCapeCod.Infrastructure.Data.Models
{
    public class Photo
    {
        [Key]
        public int Id { get; set; }

        [Comment("Image URL")]
        [MaxLength(ImgMaxLength)]
        public string ImgURL { get; set; } = string.Empty;
    }
}
