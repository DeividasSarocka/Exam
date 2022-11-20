using Exam.DAL;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats.Png;
using SixLabors.ImageSharp.Processing;

namespace Exam.BL
{
    public class PersonalInfoService : IPersonalInfoService
    {
        private readonly IDbRepository _dbRepository;
        public PersonalInfoService(IDbRepository dbRepository)
        {
            _dbRepository = dbRepository;
        }

        public async Task UpdateFirstNameAsync(string firstName, int id)
        {
            await _dbRepository.UpdateFirstNameAsync(firstName, id);
            await _dbRepository.SaveChangesAsync();
        }

        public async Task UpdateLastNameAsync(string lastName, int id)
        {
            await _dbRepository.UpdateLastNameAsync(lastName, id);
            await _dbRepository.SaveChangesAsync();
        }

        public async Task UpdatePersonalNumberAsync(string number, int id)
        {
            await _dbRepository.UpdatePersonalNumberAsync(number, id);
            await _dbRepository.SaveChangesAsync();
        }

        public async Task UpdatePhoneNumberAsync(string phoneNumber, int id)
        {
            await _dbRepository.UpdatePhoneNumberAsync(phoneNumber, id);
            await _dbRepository.SaveChangesAsync();
        }

        public async Task UpdateEmailAsync(string email, int id)
        {
            await _dbRepository.UpdateEmailAsync(email, id);
            await _dbRepository.SaveChangesAsync();
        }

        public async Task UpdateImageAsync(byte[] imageBytes, int id)
        {
            await _dbRepository.UpdateImageAsync(ReduceImage(imageBytes), id);
            await _dbRepository.SaveChangesAsync();
        }

        private static byte[] ReduceImage(byte[] imageBytes)
        {
            using var memoryStream = new MemoryStream(imageBytes);
            using var image = Image.Load(memoryStream);
            image.Mutate(x => x.Resize(200, 200));
            using var outputStream = new MemoryStream();
            image.Save(outputStream, new PngEncoder());
            imageBytes = outputStream.ToArray();
            return imageBytes;
        }
    }




}
