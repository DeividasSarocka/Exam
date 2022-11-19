using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Domain
{
    public class UserAccount
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public byte[] PasswordHash { get; set; }  
        public byte[] PasswordSalt { get; set; }  
        public string Role { get; set; } 
        public PersonalInfo PersonalInfo { get; set; }
    }
}
