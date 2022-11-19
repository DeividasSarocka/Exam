using Exam.DAL;
using Exam.Domain;
using Exam.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

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
                    Image = ProcessImage(imageBytes),
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

        private byte[] ProcessImage(byte[] imageBytes)
        {
            throw new NotImplementedException();               // TVARKYTI
        }

        private (byte[] hash, byte[] salt) CreatePasswordHash(string password)
        {
            using var hmac = new HMACSHA512();
            var salt = hmac.Key;
            var hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));

            return (hash, salt);
        }
        public Task<(bool authenticationSuccessful, UserAccount? userAccount)> LoginAsync(string userName, string password)
        {
            throw new NotImplementedException();              // TVARKYTI
        }
    }
}
