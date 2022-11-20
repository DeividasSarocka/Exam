using Exam.Domain;
using Microsoft.EntityFrameworkCore;

namespace Exam.DAL
{
    public class DbRepository : IDbRepository
    {
        private readonly AppDbContext _context;
        public DbRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<UserAccount?> GetAccountByUserNameAsync(string username)
        {
            return await _context.UserAccounts.SingleOrDefaultAsync(u => u.UserName == username);
        }

        public async Task InsertAccountAsync(UserAccount userAccount) 
        {
            await _context.UserAccounts.AddAsync(userAccount);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<UserAccount> GetUserAccountAsync(int id)
        {
            var userAccount = await _context.UserAccounts.Include(u => u.PersonalInfo).Include(u => u.PersonalInfo.ResidentialInfo).SingleOrDefaultAsync(x => x.Id == id);
            return userAccount;
        }
        public async Task DeleteUserAccountAsync(int id)
        {
            var userAcount = await GetUserAccountAsync(id);
            _context.UserAccounts.Remove(userAcount);
        }
        public async Task UpdateFirstNameAsync(string firstName, int id)
        {
            var account = await GetUserAccountAsync(id);
            account.PersonalInfo.FirstName = firstName;
        }
        public async Task UpdateLastNameAsync(string lastName, int id)
        {
            var account = await GetUserAccountAsync(id);
            account.PersonalInfo.LastName = lastName;
        }
        public async Task UpdatePersonalNumberAsync(string personalNumber, int id)
        {
            var account = await GetUserAccountAsync(id);
            account.PersonalInfo.PersonalNumber = personalNumber;
        }
        public async Task UpdatePhoneNumberAsync(string phoneNumber, int id)
        {
            var account = await GetUserAccountAsync(id);
            account.PersonalInfo.PhoneNumber = phoneNumber;
        }
        public async Task UpdateEmailAsync(string email, int id)
        {
            var account = await GetUserAccountAsync(id);
            account.PersonalInfo.Email = email;
        }
        public async Task UpdateImageAsync(byte[] imageBytes, int id)
        {
            var account = await GetUserAccountAsync(id);
            account.PersonalInfo.Image = imageBytes;
        }
        public async Task UpdateCityAsync(string city, int id)
        {
            var account = await GetUserAccountAsync(id);
            account.PersonalInfo.ResidentialInfo.City = city;
        }
        public async Task UpdateStreetNameAsync(string streetName, int id)
        {
            var account = await GetUserAccountAsync(id);
            account.PersonalInfo.ResidentialInfo.StreetName = streetName;
        }
        public async Task UpdateHouseNumberAsync(string houseNumber, int id)
        {
            var account = await GetUserAccountAsync(id);
            account.PersonalInfo.ResidentialInfo.HouseNumber = houseNumber;
        }
        public async Task UpdateApartmentNumberAsync(string apartmentNumber, int id)
        {
            var account = await GetUserAccountAsync(id);
            account.PersonalInfo.ResidentialInfo.ApartmentNumber = apartmentNumber;
        }
            

  
    }
}
