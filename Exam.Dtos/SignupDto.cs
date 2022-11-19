using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Dtos
{
    public class SignupDto
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public PersonalInfoDto PersonalInfo { get; set; }

    }
}
