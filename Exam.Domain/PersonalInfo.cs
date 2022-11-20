﻿namespace Exam.Domain
{
    public class PersonalInfo
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PersonalNumber { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public byte[] Image { get; set; }
        public ResidentialInfo ResidentialInfo { get; set; }

    }
}
