using Exam.Domain;
using Exam.Dtos;

namespace Exam.BL
{
    public interface IUserAccountsService
    {
        Task<bool> CreateUserAccountAsync(SignupDto signupDto, byte[] imageBytes);
        Task<(bool authenticationSuccessful, UserAccount? userAccount)> LoginAsync(string userName, string password);
    }
}
