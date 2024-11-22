using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class Student // Sinh viên
    {
        public int StudentId { get; set; }
        public string StudentCode { get; set; }
        public string StudentName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; } 
        public string Nationality { get; set; }
        public string Ethnicity { get; set; }
        public string Religion { get; set; }
        public string IdentityCard { get; set; }
        public string EducationSystem { get; set; }
        public int? MajorId { get; set; }
        public Major Major { get; set; }
        public string Course { get; set; }
        public int EnrollmentYear { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string ContactAddress { get; set; }
        public AppUser AppUser { get; set; }
    }
}