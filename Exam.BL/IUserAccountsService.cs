using Exam.Domain;
using Exam.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.BL
{
    public interface IUserAccountsService
    {
        Task<bool> CreateUserAccountAsync(SignupDto signupDto, byte[] imageBytes);
        Task<(bool authenticationSuccessful, UserAccount? userAccount)> LoginAsync(string userName, string password);
    }
}
