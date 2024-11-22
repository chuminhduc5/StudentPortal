using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using api.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace api.Controller
{
    [Authorize]
    [ApiController]
    [Route("api/v{v}/student-information")]
    public class StudentInfoController : ControllerBase
    {
        private readonly IStudentInfoRepository _studentInfo;
        public StudentInfoController(IStudentInfoRepository studentInfo)
        {
            _studentInfo = studentInfo;
        }

        [HttpGet("student-info")]
        public async Task<IActionResult> GetStudentInfo()
        {
            // Lấy UserId từ token
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == null)
            {
                return Unauthorized("Không thể xác thực người dùng.");
            }

            // Lấy thông tin sinh viên
            var studentInfo = await _studentInfo.GetStudentInfoAsync(userId);
            if (studentInfo == null)
            {
                return NotFound("Không tìm thấy thông tin sinh viên.");
            }

            return Ok(studentInfo);
        }
    }
}