using CourseApp.Data.Abstract;
using CourseApp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CourseApp.Data.Concrete
{
    public class CourseRepository:ICourseRepository
    {
        private CourseContext context;
        public CourseRepository(CourseContext _context)
        {
            context = _context;
        }

        public void Add(Course entity)
        {
            context.Courses.Add(entity);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            var result = context.Courses.SingleOrDefault(c => c.CourseId == id);
            if (result != null)
            {
                context.Courses.Remove(result);
                context.SaveChanges();
            }
        }

        public IQueryable<Course> GetAll() => context.Courses;

        public Course GetById(int id)=> context.Courses.SingleOrDefault(c => c.CourseId == id);

        public void Update(Course entity)
        {
            var result = context.Courses.SingleOrDefault(c => c.CourseId == entity.CourseId);
            if (result != null)
            {
                result.CourseName = entity.CourseName;
                result.CoursePrograms = entity.CoursePrograms;
                context.SaveChanges();
            }
        }
    }
}
