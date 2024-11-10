using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Student;
using api.Helper;
using api.Models;

namespace api.Interfaces
{
    public interface IStudentRepository
    {
        Task<List<Student>> GetAllAsync();
        Task<List<Student>> GetListAsync(QueryObject query);
        Task<Student?> GetByIdAsync(int id);
        Task<Student> CreateAsync(Student studentModel);
        Task<Student?> UpdateAsync(int id, UpdateStudentRequestDto studentDto);
        Task<Student?> DeleteAsync(int id);
        Task<bool> StudentExists(int id);
    }
}