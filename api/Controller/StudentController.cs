using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.Student;
using api.Interfaces;
using api.Mappers;
using api.Models;
using Microsoft.AspNetCore.Mvc;

namespace api.Controller
{
    [Route("api/v{v}/Student")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        private readonly IStudentRepository _studentRepo;
        public StudentController(ApplicationDBContext context, IStudentRepository studentRepo)
        {
            _context = context;
            _studentRepo = studentRepo;
        }

        [HttpGet("get-all")]
        public async Task<IActionResult> GetAll()
        {
            var students = await _studentRepo.GetAllAsync();
            var studentDto = students.Select(s => s.ToStudentDto()).ToList();
            var response = new ApiResponse<List<StudentDto>>()
            {
                Success = true,
                HttpStatusCode = 200,
                Message = "Thêm mới sinh viên thành công",
                Data = studentDto,
                TotalCount = studentDto.Count,
                Errors = new Dictionary<string, string[]>()
            };
            return Ok(response);
        }

        // [HttpGet("get-list")]
        // public async Task<IActionResult> GetList([FromQuery] StudentQueryObject query)
        // {
        //     var students = await _studentRepo.GetListAsync(query);
        //     var studentDto = students.Select(s => s.ToStudentDto()).ToList();
        //     return Ok(studentDto);
        // }

        [HttpGet("get-student-by-id/{id:int}")]
        public async Task<IActionResult> GetStudentById([FromRoute] int id)
        {
            var student = await _studentRepo.GetByIdAsync(id);

            if (student == null)
            {
                return NotFound();
            }

            return Ok(student.ToStudentDto());
        }

        [HttpPost("create-student")]
        public async Task<IActionResult> Create([FromBody] CreateStudentRequestDto studentDto)
        {
            var studentModel = studentDto.ToStudentFromCreateDto();
            await _studentRepo.CreateAsync(studentModel);
            return CreatedAtAction(nameof(GetStudentById), new {v = 1, id = studentModel.StudentId}, studentModel.ToStudentDto());
        }

        [HttpPut("update-student/{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateStudentRequestDto updateDto)
        {
            var studentModel = await _studentRepo.UpdateAsync(id, updateDto);

            if (studentModel == null)
            {
                return NotFound();
            }

           
            return Ok(studentModel.ToStudentDto());
        }

        [HttpDelete("delete/{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var studentModel = await _studentRepo.DeleteAsync(id);

            if (studentModel == null)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}