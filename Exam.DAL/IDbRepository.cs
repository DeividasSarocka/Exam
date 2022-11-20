using Exam.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.DAL
{
    public interface IDbRepository
    {
        Task<UserAccount?> GetAccountByUserNameAsync(string username); 
        Task InsertAccountAsync(UserAccount userAccount); 
        Task SaveChangesAsync();
        Task<UserAccount> GetUserAccountAsync(int id);
        Task DeleteUserAccountAsync(int id);
        Task UpdateFirstNameAsync(string firstName, int id);
        Task UpdateLastNameAsync(string lastName, int id);
        Task UpdatePersonalNumberAsync(string number, int id);
        Task UpdatePhoneNumberAsync (string phoneNumber, int id);
        Task UpdateEmailAsync(string email, int id);
        Task UpdateImageAsync(byte[] imageBytes, int id);
        Task UpdateCityAsync(string city, int id);
        Task UpdateStreetNameAsync(string streetName, int id);
        Task UpdateHouseNumberAsync(string houseNumber, int id);
        Task UpdateApartmentNumberAsync(string apartmentNumber, int id);
    }
}

