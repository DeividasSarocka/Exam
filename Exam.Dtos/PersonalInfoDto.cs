namespace Exam.Dtos
{
    public class PersonalInfoDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PersonalNumber { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public ResidentialInfoDto ResidentialInfo { get; set; }

    }
}
