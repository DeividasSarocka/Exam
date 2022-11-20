using Exam.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
  
    }
}
