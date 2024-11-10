using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Student;
using api.Models;

namespace api.Mappers
{
    public static class StudentMapper
    {
        public static StudentDto ToStudentDto(this Student studentModel)
        {
            return new StudentDto 
            {
                StudentId = studentModel.StudentId,
                StudentCode = studentModel.StudentCode,
                DateOfBirth = studentModel.DateOfBirth,
                Gender = studentModel.Gender,
                Nationality = studentModel.Nationality,
                Ethnicity = studentModel.Ethnicity,
                Religion = studentModel.Religion,
                IdentityCard = studentModel.IdentityCard,
                EducationSystem = studentModel.EducationSystem,
                Course = studentModel.Course,
                EnrollmentYear = studentModel.EnrollmentYear,
                PhoneNumber = studentModel.PhoneNumber,
                Email = studentModel.Email,
                ContactAddress = studentModel.ContactAddress
            };
        }

        public static Student ToStudentFromCreateDto(this CreateStudentRequestDto studentDto)
        {
            return new Student 
            {
                StudentCode = studentDto.StudentCode,
                DateOfBirth = studentDto.DateOfBirth,
                Gender = studentDto.Gender,
                Nationality = studentDto.Nationality,
                Ethnicity = studentDto.Ethnicity,
                Religion = studentDto.Religion,
                IdentityCard = studentDto.IdentityCard,
                EducationSystem = studentDto.EducationSystem,
                Course = studentDto.Course,
                EnrollmentYear = studentDto.EnrollmentYear,
                PhoneNumber = studentDto.PhoneNumber,
                Email = studentDto.Email,
                ContactAddress = studentDto.ContactAddress
            };
        }
    }
}