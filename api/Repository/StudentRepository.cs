using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.Student;
using api.Helper;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly ApplicationDBContext _context;

        public StudentRepository(ApplicationDBContext context)
        {
            _context = context;
        }
        
        public async Task<List<Student>> GetAllAsync()
        {
            return await _context.Students.ToListAsync();
        }


        public async Task<List<Student>> GetListAsync(QueryObject query)
        {  
            var students = _context.Students.AsQueryable();

            var skipNumber = (query.Skip - 1) * query.Take;

            return await students.Skip(skipNumber).Take(query.Take).ToListAsync();
        }

        public async Task<Student?> GetByIdAsync(int id)
        {
            return await _context.Students.FirstOrDefaultAsync(x => x.StudentId == id);
        }

        public async Task<Student> CreateAsync(Student studentModel)
        {
            await _context.Students.AddAsync(studentModel);
            await _context.SaveChangesAsync();
            return studentModel;
        }

        public async Task<Student?> UpdateAsync(int id, UpdateStudentRequestDto studentDto)
        {
            var existingStudent = await _context.Students.FirstOrDefaultAsync(s => s.StudentId == id);

            if (existingStudent == null)
            {
                return null;
            }
            
            existingStudent.StudentCode = studentDto.StudentCode;
            existingStudent.StudentName = studentDto.StudentName;
            existingStudent.DateOfBirth = studentDto.DateOfBirth;
            existingStudent.Gender = studentDto.Gender;
            existingStudent.Nationality = studentDto.Nationality;
            existingStudent.Ethnicity = studentDto.Ethnicity;
            existingStudent.Religion = studentDto.Religion;
            existingStudent.IdentityCard = studentDto.IdentityCard;
            existingStudent.EducationSystem = studentDto.EducationSystem;
            existingStudent.Course = studentDto.Course;
            existingStudent.EnrollmentYear = studentDto.EnrollmentYear;
            existingStudent.PhoneNumber = studentDto.PhoneNumber;
            existingStudent.Email = studentDto.Email;
            existingStudent.ContactAddress = studentDto.ContactAddress;
            
            await _context.SaveChangesAsync();
            return existingStudent;
        }

        public async Task<Student?> DeleteAsync(int id)
        {
            // Kiểm tra id người dùng nhập vào
            var studentModel = await _context.Students.FirstOrDefaultAsync(x => x.StudentId == id);

            // Nếu id = null => Không trả về kết quả
            if(studentModel == null)
            {
                return null;
            }

            // Nếu id hợp lệ => tiến hành xóa
            _context.Students.Remove(studentModel);
            // Sau khi xóa => tiến hành lưu lại kết quả và câp nhật ở db
            await _context.SaveChangesAsync();
            // Trả lại kết quả sau khi xóa
            return studentModel;
        }

        public async Task<bool> StudentExists(int id)
        {
            return await _context.Students.AnyAsync(s => s.StudentId == id);
        }

    }
}