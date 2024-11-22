using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Unicode;
using System.Threading.Tasks;
using api.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace api.Data
{
    public class ApplicationDBContext : IdentityDbContext<AppUser>
    {
        public ApplicationDBContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
            
        }

        public DbSet<AppUser> Users { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Major> Majors { get; set; }
        public DbSet<Faculty> Faculties { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<GradeType> GradeTypes { get; set; }
        public DbSet<Grade> Grades { get; set; }
        public DbSet<Semester> Semesters { get; set; }
        public DbSet<AcademicYear> AcademicYears { get; set; }
        public DbSet<Timetable> Timetables { get; set; }
        public DbSet<Attendance> Attendances { get; set; }
        // protected override void OnModelCreating(ModelBuilder builder)
        // {
        //     base.OnModelCreating(builder);
        //
        //     //builder.Entity<User>(x => x.HasKey(p => new {p.StudentId}));
        //
        //     // Cấu hình mối quan hệ giữa AppUser và Student
        //     builder.Entity<AppUser>()
        //         .HasOne(a => a.Student)
        //         .WithOne(s => s.User) 
        //         .HasForeignKey<AppUser>(p => p.StudentId);       
        //     List<IdentityRole> roles = new List<IdentityRole>
        //     {
        //         new IdentityRole
        //         {
        //             Name = "Admin",
        //             NormalizedName = "ADMIN"
        //         },
        //         new IdentityRole
        //         {
        //             Name = "User",
        //             NormalizedName = "USER"
        //         }
        //     };
        //     builder.Entity<IdentityRole>().HasData(roles);
        // }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            //builder.Entity<User>(x => x.HasKey(p => new {p.StudentId}));
            
            modelBuilder.Entity<Student>()
                .HasOne(s => s.AppUser)
                .WithOne(u => u.Student)
                .HasForeignKey<AppUser>(u => u.StudentId);
            // List<IdentityRole> roles = new List<IdentityRole>
            // {
            //     new IdentityRole
            //     {
            //         Name = "Admin",
            //         NormalizedName = "ADMIN"
            //     },
            //     new IdentityRole
            //     {
            //         Name = "User",
            //         NormalizedName = "USER"
            //     }
            // };
            // builder.Entity<IdentityRole>().HasData(roles);
        }
    }
}