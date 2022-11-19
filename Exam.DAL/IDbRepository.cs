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
    }
}

