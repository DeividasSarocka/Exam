using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Domain
{
    public class PersonalInfo
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int PersonalCode { get; set; }
        public int PhoneNumber { get; set; }
        public string Email { get; set; }
        public byte[] Image { get; set; }
        public ResidentialInfo ResidentialInfo { get; set; }
    }
}
