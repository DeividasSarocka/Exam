﻿using System.ComponentModel.DataAnnotations.Schema;

namespace Exam.Domain
{
    public class ResidentialInfo
    {
        public int Id { get; set; }
        public string City { get; set; }
        public string StreetName { get; set; }
        public string HouseNumber { get; set; }
        public string ApartmentNumber { get; set; }
    }
}
