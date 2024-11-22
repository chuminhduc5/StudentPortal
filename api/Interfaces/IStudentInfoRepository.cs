using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Student;

namespace api.Interfaces
{
    public interface IStudentInfoRepository
    {
        Task<StudentInfoDto> GetStudentInfoAsync(string userId);
    }
}