// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Threading.Tasks;
// using api.Dtos.Account;
// using api.Interfaces;
// using Microsoft.AspNetCore.Mvc;
//
// namespace api.Controller
// {
//     [ApiController]
//     [Route("api/v{v}/account")]
//     public class AccountController : ControllerBase
//     {
//         private readonly IAuthRepository _authRepo;
//         public AccountController(IAuthRepository authRepo)
//         {
//             _authRepo = authRepo;
//         }
//
//         // [HttpPost("register")]
//         // public async Task<IActionResult> Register(RegisterDto registerDto)
//         // {
//         //     var user = await _authRepo.RegisterAsync(registerDto);
//         //
//         //     if (user == "Sinh viên không tồn tại" || user == "Đăng ký thất bại")
//         //         return BadRequest(user);
//         //
//         //     return Ok(new { token = user });
//         // }
//         //
//         // [HttpPost("login")]
//         // public async Task<IActionResult> login(LoginDto loginDto)
//         // {
//         //     var result = await _authRepo.LoginAsync(loginDto);
//         //
//         //     if (result == "Tài khoản không tồn tại" || result == "Sai mật khẩu")
//         //         return Unauthorized(result);
//         //
//         //     return Ok(new { token = result });
//         // }
//         
//         [HttpPost("register")]
//         public async Task<IActionResult> Register(RegisterDto registerDto)
//         {
//             var result = await _authRepo.RegisterAsync(registerDto);
//
//             if (result.StartsWith("Sinh viên không tồn tại") || result.StartsWith("Đăng ký thất bại"))
//                 return BadRequest(result);
//
//             return Ok(new { token = result });
//         }
//
//         [HttpPost("login")]
//         public async Task<IActionResult> Login(LoginDto loginDto)
//         {
//             var result = await _authRepo.LoginAsync(loginDto);
//
//             if (result == "Tài khoản không tồn tại" || result == "Sai mật khẩu")
//                 return Unauthorized(result);
//
//             return Ok(new { token = result });
//         }
//     }
// }

using api.Dtos.Account;
using api.Interfaces;
using api.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using api.Data;

namespace api.Controller
{
    [Route("api/v{v}/account")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly ITokenService _tokenService;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly ApplicationDBContext _context;  // DbContext to access Student table

        public AccountController(UserManager<AppUser> userManager, ITokenService tokenService, SignInManager<AppUser> signInManager, ApplicationDBContext context)
        {
            _userManager = userManager;
            _tokenService = tokenService;
            _signInManager = signInManager;
            _context = context;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var student = await _context.Students.SingleOrDefaultAsync(s => s.StudentCode == registerDto.StudentCode);
            if (student == null)
                return BadRequest("Student does not exist!");

            var appUser = new AppUser
            {
                UserName = registerDto.StudentCode,
                StudentId = student.StudentId  // Linking with Student foreign key
            };

            var result = await _userManager.CreateAsync(appUser, registerDto.Password);
            if (!result.Succeeded)
                return BadRequest("User registration failed!");

            await _userManager.AddToRoleAsync(appUser, "User");

            return Ok(new { token = _tokenService.CreateToken(appUser) });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            var user = await _userManager.Users.SingleOrDefaultAsync(u => u.UserName == loginDto.StudentCode);
            if (user == null)
                return Unauthorized("Invalid StudentCode");

            var result = await _signInManager.CheckPasswordSignInAsync(user, loginDto.Password, false);
            if (!result.Succeeded)
                return Unauthorized("Incorrect password");

            return Ok(new { token = _tokenService.CreateToken(user) });
        }
    }
}
