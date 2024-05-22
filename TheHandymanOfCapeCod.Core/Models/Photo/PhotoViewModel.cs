namespace TheHandymanOfCapeCod.Core.Models.Photo
{
    public class PhotoViewModel
    {
        public int Id { get; set; }

        public byte[] ImageData { get; set; } = Array.Empty<byte>();

        public int ProjectId { get; set; }
    }
}
