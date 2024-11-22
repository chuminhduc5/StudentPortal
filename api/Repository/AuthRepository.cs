// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Threading.Tasks;
// using api.Data;
// using api.Dtos.Account;
// using api.Interfaces;
// using api.Models;
// using Microsoft.AspNetCore.Identity;
// using Microsoft.AspNetCore.Mvc;
// using Microsoft.EntityFrameworkCore;
//
// namespace api.Repository
// {
//     public class AuthRepository : IAuthRepository
//     {
//         private readonly UserManager<AppUser> _userManager;
//         private readonly ITokenService _tokenService;
//         private readonly SignInManager<AppUser> _signInManager;
//         private readonly ApplicationDBContext _context;
//
//         public AuthRepository(UserManager<AppUser> userManger, ITokenService tokenService,
//             SignInManager<AppUser> signInManager, ApplicationDBContext context)
//         {
//             _userManager = userManger;
//             _tokenService = tokenService;
//             _signInManager = signInManager;
//             _context = context;
//         }
//
//         public async Task<string> LoginAsync([FromBody] LoginDto loginDto)
//         {
//             var user = await _userManager.Users.SingleOrDefaultAsync(s => s.UserName == loginDto.StudentCode);
//
//             if (user == null) return "Tài khoản không tồn tại";
//
//             var result = await _signInManager.CheckPasswordSignInAsync(user, loginDto.Password, false);
//
//             if (!result.Succeeded) return "Sai mật khẩu";
//
//             return _tokenService.CreateToken(user);
//         }
//
//         public async Task<string> RegisterAsync([FromBody] RegisterDto registerDto)
//         {
//             var student = await _context.Students.FirstOrDefaultAsync(x => x.StudentCode == registerDto.StudentCode);
//
//             if (student == null)
//             {
//                 return ("Sinh viên không tồn tại!");
//             }
//
//             var user = new AppUser
//             {
//                 UserName = registerDto.StudentCode,
//                 StudentId = student.StudentId,
//             };
//
//             var result = await _userManager.CreateAsync(user, registerDto.Password);
//
//             // if(!result.Succeeded)
//             // {
//             //     return "Đăng ký thất bại";
//             // }
//
//             if (!result.Succeeded)
//             {
//                 var errors = string.Join(", ", result.Errors.Select(e => e.Description));
//                 return $"Đăng ký thất bại: {errors}";
//             }
//
//
//             await _userManager.AddToRoleAsync(user, "User");
//             return _tokenService.CreateToken(user);
//         }
//     }
// }


using System.Threading.Tasks;
using api.Data;
using api.Dtos.Account;
using api.Interfaces;
using api.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class AuthRepository : IAuthRepository
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly ITokenService _tokenService;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly ApplicationDBContext _context;

        public AuthRepository(UserManager<AppUser> userManager, ITokenService tokenService, SignInManager<AppUser> signInManager, ApplicationDBContext context)
        {
            _userManager = userManager;
            _tokenService = tokenService;
            _signInManager = signInManager;
            _context = context;
        }

        public async Task<string> LoginAsync(LoginDto loginDto)
        {
            var user = await _userManager.Users
                .SingleOrDefaultAsync(s => s.NormalizedUserName == loginDto.StudentCode.ToUpper());

            if (user == null) return "Tài khoản không tồn tại";

            var result = await _signInManager.CheckPasswordSignInAsync(user, loginDto.Password, false);

            if (!result.Succeeded) return "Sai mật khẩu";

            return _tokenService.CreateToken(user);
        }

        public async Task<string> RegisterAsync(RegisterDto registerDto)
        {
            var student = await _context.Students
                .FirstOrDefaultAsync(x => x.StudentCode == registerDto.StudentCode);

            if (student == null) return "Student Not Found!";

            var user = new AppUser
            {
                UserName = registerDto.StudentCode,
                StudentId = student.StudentId
            };

            var createdUser = await _userManager.CreateAsync(user, registerDto.Password);

            if (!createdUser.Succeeded)
            {
                var errors = string.Join(", ", createdUser.Errors.Select(e => e.Description));
                return $"Đăng ký thất bại: {errors}";
            }

            await _userManager.AddToRoleAsync(user, "User");
            return _tokenService.CreateToken(user);
        }
    }
}
