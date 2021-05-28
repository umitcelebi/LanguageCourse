using CourseApp.Data.Abstract;
using CourseApp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CourseApp.Data.Concrete
{
    public class StudentRepository : IStudentRepository
    {
        private CourseContext context;
        public StudentRepository(CourseContext _context)
        {
            context = _context;
        }
        public void Add(Student entity)
        {
            var result = context.Students.SingleOrDefault(s=>s.IdentityNumber==entity.IdentityNumber);
            if (result == null)
            {
                context.Students.Add(entity);
                context.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            var result = context.Students.SingleOrDefault(s=>s.StudentId==id);
            if (result != null)
            {
                context.Students.Remove(result);
                context.SaveChanges();
            }
        }

        public IQueryable<Student> GetAll() => context.Students;

        public Student GetById(int id)=>context.Students.SingleOrDefault(s=>s.StudentId==id);
        public Student GetByIdentity(int identity) => context.Students.SingleOrDefault(s => s.IdentityNumber==identity);

        public void Update(Student entity)
        {
            var result = context.Students.SingleOrDefault(s => s.StudentId == entity.StudentId);
            if (result != null)
            {
                result.StudentName = entity.StudentName;
                result.StudentSurname = entity.StudentSurname;
                result.Phone = entity.Phone;
                result.Adress = entity.Adress;
                result.CoursePrograms = entity.CoursePrograms;
                context.SaveChanges();
            }
        }
    }
}
