using Exam.DAL;
using Exam.Domain;
using Exam.Dtos;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats.Png;
using SixLabors.ImageSharp.Processing;
using System.Security.Cryptography;
using System.Text;

namespace Exam.BL
{
    public class UserAccountsService  : IUserAccountsService
    {
        private readonly IDbRepository _dbRepository;
        public UserAccountsService(IDbRepository dbRepository)
        {
            _dbRepository = dbRepository;
        }

        public async Task<bool> CreateUserAccountAsync(SignupDto signupDto, byte[] imageBytes)
        {
            var existingUser = await _dbRepository.GetAccountByUserNameAsync(signupDto.UserName);
            if (existingUser != null)
            {
                return false;
            }

            var (hash, salt) = CreatePasswordHash(signupDto.Password);

            var newUser = new UserAccount
            {
                UserName = signupDto.UserName,
                PasswordHash = hash,
                PasswordSalt = salt,
                Role = "User",
                PersonalInfo = new PersonalInfo
                {
                    FirstName = signupDto.PersonalInfo.FirstName,
                    LastName = signupDto.PersonalInfo.LastName,
                    PersonalNumber = signupDto.PersonalInfo.PersonalNumber,
                    PhoneNumber = signupDto.PersonalInfo.PhoneNumber,
                    Email = signupDto.PersonalInfo.Email,
                    Image = ReduceImage(imageBytes),
                    ResidentialInfo = new ResidentialInfo
                    {
                        City = signupDto.PersonalInfo.ResidentialInfo.City,
                        StreetName = signupDto.PersonalInfo.ResidentialInfo.Street,
                        HouseNumber = signupDto.PersonalInfo.ResidentialInfo.HouseNo,
                        ApartmentNumber = signupDto.PersonalInfo.ResidentialInfo.ApartmentNo
                    }
                }
            };
            await _dbRepository.InsertAccountAsync(newUser);
            await _dbRepository.SaveChangesAsync();

            return true;
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
        public async Task<(bool authenticationSuccessful, UserAccount? userAccount)> LoginAsync(string userName, string password)
        {
            var account = await _dbRepository.GetAccountByUserNameAsync(userName);
            if (account == null)
            {
                return (false, null);
            }
            if (VerifyPasswordHash(password, account.PasswordHash, account.PasswordSalt))
            {
                return (true, account);
            }
            else
            {
                return (false, null);
            }
        }
        private (byte[] hash, byte[] salt) CreatePasswordHash(string password)
        {
            using var hmac = new HMACSHA512();
            var salt = hmac.Key;
            var hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));

            return (hash, salt);
        }
        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using var hmac = new HMACSHA512(passwordSalt);
            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            return computedHash.SequenceEqual(passwordHash);
        }
    }
}
