using CourseApp.Entity;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CourseApp.Data.Concrete
{
    public static class SeedData
    {
        public static void Seed(IApplicationBuilder app)
        {


            CourseContext context = app.ApplicationServices.GetRequiredService<CourseContext>();
            context.Database.Migrate();

            if (!context.Branchs.Any())
            {
                context.Branchs.AddRange(
                    new Branch { BranchName="Şirinevler Şubesi",Address="Şirinevler Meydan" },
                    new Branch { BranchName = "Bağcılar Şubesi", Address = "Bağcılar Meydan" }
                    );
                context.SaveChanges();
            }
            if (!context.Courses.Any())
            {
                context.Courses.AddRange(
                    new Course { CourseName="İngilizce"},
                    new Course { CourseName="Almanca"},
                    new Course { CourseName="Fransızca"}
                    );
                context.SaveChanges();
            }
            if (!context.Teachers.Any())
            {
                context.Teachers.AddRange(
                    new Teacher { TeacherName="ELif Beyza Toprak",Phone="123456789"},
                    new Teacher { TeacherName = "Ümit Çelebi", Phone = "789456123" },
                    new Teacher { TeacherName = "İrem Çelebi", Phone = "741852963" }
                    );
                context.SaveChanges();
            }
            if (!context.Students.Any())
            {
                context.Students.AddRange(
                    new Student { StudentName="Ali",StudentSurname="Çelebi",Phone="852741963"},
                    new Student { StudentName = "Naime", StudentSurname = "Çelebi", Phone = "963741852" },
                    new Student { StudentName = "Özlem", StudentSurname = "Çelebi", Phone = "32541584212" }
                    );
                context.SaveChanges();
            }
            if (!context.CoursePrograms.Any())
            {
                context.CoursePrograms.AddRange(
                    new CoursePrograms { 
                        BranchId=1,
                        CourseId=1,
                        TeacherId=1
                    },
                    new CoursePrograms
                    {
                        BranchId = 2,
                        CourseId = 1,
                        TeacherId = 1
                    },
                    new CoursePrograms
                    {
                        BranchId = 1,
                        CourseId = 2,
                        TeacherId = 3
                    },
                    new CoursePrograms
                    {
                        BranchId = 1,
                        CourseId = 3,
                        TeacherId = 2
                    },
                    new CoursePrograms
                    {
                        BranchId = 2,
                        CourseId = 3,
                        TeacherId = 2
                    }
                    );
                context.SaveChanges();
            }

        }
    }
}
