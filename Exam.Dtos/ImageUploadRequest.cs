using Exam.Validation;
using Microsoft.AspNetCore.Http;

namespace Exam.Dtos
{
    public class ImageUploadRequest
    {
        [MaxFileSize(5 * 1024 * 1024)]
        [AllowedExtensions(new[] { ".png", ".jpg" })]

        public IFormFile Image { get; set; }
    }
}
