using Exam.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.BL
{
    public class UserAccountsService // : IUserAccountsService
    {
        private readonly IDbRepository _dbRepository;
        public UserAccountsService(IDbRepository dbRepository)
        {
            _dbRepository = dbRepository;
        }
    }
}
