using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using Moq;
using TheHandymanOfCapeCod.Core.Contracts;
using TheHandymanOfCapeCod.Core.Services;

namespace TheHandymanOfCapeCod.Tests.UnitTests
{
    public class PhotoServiceUnitTests : UnitTestsBase
    {
        private IPhotoService photoService;
        private IList<IFormFile> files;

       [SetUp]
        public void SetUp() 
        {
            photoService = new PhotoService(testRepository);
            
        } 

        [Test]
        public async Task UploadPhotosAsyncShouldUploadPhotos()
        {
            // Arrange
            var files = new List<IFormFile>();

            string directoryPath = "../../../../The Handyman Of Cape Cod/wwwroot/img";
            var filesPaths = Directory.GetFiles(directoryPath).ToList();
            

            foreach (var file in filesPaths)
            {
                var stream = new FileStream(file, FileMode.Open);
                
                   
                    var fileName = "file.txt";
                    string contentType = stream.GetType().Name;

                    var currentFile = new FormFile(stream, 0, stream.Length, null, fileName)
                    {
                        Headers = new HeaderDictionary(),
                        ContentType = contentType
                    };

                    files.Add(currentFile);
                
            }
            // Act

            await photoService.UploadPhotosAsync(1, files);

            // Assert

            Assert.That(FirstProject.Photos.Count > 0);
        }
    }
}
