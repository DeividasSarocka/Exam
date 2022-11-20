﻿using Exam.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.BL
{
    public interface IUsersService
    {
        Task<UserAccount> GetUserAccountAsync(int id);
        Task DeleteUserAccountAsync(int id);
    }
}
