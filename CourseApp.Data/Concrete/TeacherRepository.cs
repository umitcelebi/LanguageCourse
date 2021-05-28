using CourseApp.Data.Abstract;
using CourseApp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CourseApp.Data.Concrete
{
    public class TeacherRepository : ITeacherRepository
    {
        private CourseContext context;
        public TeacherRepository(CourseContext _context)
        {
            context = _context;
        }
        public void Add(Teacher entity)
        {
            context.Teachers.Add(entity);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            var result = context.Teachers.SingleOrDefault(t=>t.TeacherId==id);
            if (result != null)
            {
                context.Teachers.Remove(result);
                context.SaveChanges();
            }
        }

        public IQueryable<Teacher> GetAll() => context.Teachers;

        public Teacher GetById(int id) => context.Teachers.SingleOrDefault(t=>t.TeacherId==id);

        public void Update(Teacher entity)
        {
            var result = context.Teachers.SingleOrDefault(t => t.TeacherId == entity.TeacherId);
            if (result != null)
            {
                result.TeacherName = entity.TeacherName;
                result.Phone = entity.Phone;
                context.SaveChanges();
            }
        }
    }
}
