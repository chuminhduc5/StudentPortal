using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.Student
{
    public class StudentDto
    {
        public int StudentId { get; set; }
        public string StudentCode { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; } 
        public string Nationality { get; set; }
        public string Ethnicity { get; set; }
        public string Religion { get; set; }
        public string IdentityCard { get; set; }
        public string EducationSystem { get; set; }
        public string MajorName { get; set; }
        public string Course { get; set; }
        public int EnrollmentYear { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string ContactAddress { get; set; }
    }
}