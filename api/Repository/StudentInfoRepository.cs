using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.Student;
using api.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class StudentInfoRepository : IStudentInfoRepository
    {
        private readonly ApplicationDBContext _context;
        public StudentInfoRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<StudentInfoDto> GetStudentInfoAsync(string userId)
        {
            // var student = await _context.Students
            //     .Include(s => s.Major)
            //     .Where(s => s.User.Id == userId)
            //     .Select(s => new StudentInfoDto 
            //     {
            //         StudentId = s.StudentId,
            //         StudentName = s.StudentName,
            //         DateOfBirth = s.DateOfBirth,
            //         Gender = s.Gender,
            //         Nationality = s.Nationality,
            //         Ethnicity = s.Ethnicity,
            //         Religion = s.Religion,
            //         IdentityCard = s.IdentityCard,
            //         EducationSystem = s.EducationSystem,
            //         MajorName = s.Major.MajorName,
            //         Course = s.Course,
            //         EnrollmentYear = s.EnrollmentYear,
            //         PhoneNumber = s.PhoneNumber,
            //         Email = s.Email,
            //         ContactAddress = s.ContactAddress,
            //     }).FirstOrDefaultAsync();
            //
            return null;
        }
    }
}