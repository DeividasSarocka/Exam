﻿using Exam.Domain;

namespace Exam.BL
{
    public interface IJwtService
    {
        string GetJwtToken(UserAccount userAccount);
    }
}
