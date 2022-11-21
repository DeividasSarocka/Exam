using Exam.Domain;

namespace Exam.BL
{
    public interface IUsersService
    {
        Task<UserAccount> GetUserAccountAsync(int id);
        Task DeleteUserAccountAsync(int id);
        Task<UserAccount> GetImageAsync(int id);

    }
}
