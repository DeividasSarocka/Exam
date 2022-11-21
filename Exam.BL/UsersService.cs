using Exam.DAL;
using Exam.Domain;

namespace Exam.BL
{
    public class UsersService : IUsersService
    {
        private readonly IDbRepository _dbRepository;
        public UsersService(IDbRepository dbRepository)
        {
            _dbRepository = dbRepository;
        }

        public async Task<UserAccount> GetUserAccountAsync(int id)
        {
            return await _dbRepository.GetUserAccountAsync(id);
        }

        public async Task DeleteUserAccountAsync(int id)
        {
            var userToDelete = await _dbRepository.GetUserAccountAsync(id);
            await _dbRepository.DeleteUserAccountAsync(id);
            await _dbRepository.SaveChangesAsync();
        }

        public async Task<UserAccount> GetImageAsync(int id)
        {
            return await _dbRepository.GetImageAsync(id);
        }
    }
}
