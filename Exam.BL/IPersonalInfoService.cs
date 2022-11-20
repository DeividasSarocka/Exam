using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.BL
{
    public interface IPersonalInfoService
    {
        Task UpdateFirstNameAsync(string firstName, int id);
        Task UpdateLastNameAsync(string lastName, int id);
        Task UpdatePersonalNumberAsync(string number, int id);
        Task UpdatePhoneNumberAsync(string phoneNumber, int id);
        Task UpdateEmailAsync(string email, int id);
        Task UpdateImageAsync(byte[] imageBytes, int id);
    }
}
