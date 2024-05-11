using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheHandymanOfCapeCod.Core.Models.Photo
{
    public class PhotoViewModel
    {
        public int Id { get; set; }

        public byte[] ImageData { get; set; } = Array.Empty<byte>();

        public int ProjectId { get; set; }
    }
}
