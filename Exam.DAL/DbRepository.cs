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
    }
}
