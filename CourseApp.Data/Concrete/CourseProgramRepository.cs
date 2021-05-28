using CourseApp.Data.Abstract;
using CourseApp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CourseApp.Data.Concrete
{
    public class CourseProgramRepository : ICourseProgramRepository
    {
        private CourseContext context;
        public CourseProgramRepository(CourseContext _context)
        {
            context = _context;
        }
        public void Add(CoursePrograms entity)
        {
            
            context.CoursePrograms.Add(entity);
            context.SaveChanges();
        }

        public void AddStudent(int programId, int studentId)
        {
            var result = context.CoursePrograms.SingleOrDefault(p => p.CourseProgramsId == programId);
            if (result != null)
            {
                Student s = context.Students.SingleOrDefault(s => s.StudentId == studentId);
                result.Students.Add((s));
                context.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            var result = context.CoursePrograms.SingleOrDefault(p=>p.CourseProgramsId==id);
            if (result != null)
            {
                context.CoursePrograms.Remove(result);
                context.SaveChanges();
            }
        }

        public IQueryable<CoursePrograms> GetAll() {

            var Track = (from o in context.CoursePrograms
                         join i in context.Branchs on o.BranchId equals i.BranchId
                         join c in context.Courses on o.CourseId equals c.CourseId
                         join x in context.Teachers on o.TeacherId equals x.TeacherId
                         select new CoursePrograms()
                         {
                             CourseProgramsId=o.CourseProgramsId,
                             BranchId=o.BranchId,
                             CourseId=o.CourseId,
                             TeacherId=o.TeacherId,
                             Course=c,
                             Teacher=x,
                             Branch = i,

                         });
            return Track;
        }

        public CoursePrograms GetById(int id) 
        {
            var result = (from cp in context.CoursePrograms
                          join b in context.Branchs on cp.BranchId equals b.BranchId
                          join c in context.Courses on cp.CourseId equals c.CourseId
                          join t in context.Teachers on cp.TeacherId equals t.TeacherId
                          where cp.CourseProgramsId == id
                          select new CoursePrograms
                          {
                              CourseProgramsId = cp.CourseProgramsId,
                              BranchId = cp.BranchId,
                              CourseId = cp.CourseId,
                              TeacherId = cp.TeacherId,
                              Course = c,
                              Branch = b,
                              Teacher = t
                          }).SingleOrDefault(r=>r.CourseProgramsId==id);
            return result;
        } 

        public IQueryable<CoursePrograms> searchByBranch(int branchId)
        {
            var result = (from cp in context.CoursePrograms
                          join b in context.Branchs on cp.BranchId equals b.BranchId
                          join c in context.Courses on cp.CourseId equals c.CourseId
                          join t in context.Teachers on cp.TeacherId equals t.TeacherId
                          where cp.BranchId == branchId
                          select new CoursePrograms
                          {
                              CourseProgramsId = cp.CourseProgramsId,
                              BranchId = cp.BranchId,
                              CourseId = cp.CourseId,
                              TeacherId = cp.TeacherId,
                              Course = c,
                              Branch = b,
                              Teacher = t
                          });
            return result;
        }

        public IQueryable<CoursePrograms> searchByCourse(int courseId)
        {
            var result = (from cp in context.CoursePrograms
                          join b in context.Branchs on cp.BranchId equals b.BranchId
                          join c in context.Courses on cp.CourseId equals c.CourseId
                          join t in context.Teachers on cp.TeacherId equals t.TeacherId
                          where cp.CourseId == courseId
                          select new CoursePrograms
                          {
                              CourseProgramsId = cp.CourseProgramsId,
                              BranchId = cp.BranchId,
                              CourseId = cp.CourseId,
                              TeacherId = cp.TeacherId,
                              Course = c,
                              Branch = b,
                              Teacher = t
                          });
            return result;
        }

        public IQueryable<CoursePrograms> searchByTeacher(int teacherId)
        {
            var result = (from cp in context.CoursePrograms
                          join b in context.Branchs on cp.BranchId equals b.BranchId
                          join c in context.Courses on cp.CourseId equals c.CourseId
                          join t in context.Teachers on cp.TeacherId equals t.TeacherId
                          where cp.TeacherId == teacherId
                          select new CoursePrograms
                          {
                              CourseProgramsId = cp.CourseProgramsId,
                              BranchId = cp.BranchId,
                              CourseId = cp.CourseId,
                              TeacherId = cp.TeacherId,
                              Course = c,
                              Branch = b,
                              Teacher = t
                          });
            return result;
        }

        public void Update(CoursePrograms entity)
        {
            var result = context.CoursePrograms.SingleOrDefault(p => p.CourseProgramsId == entity.CourseProgramsId);
            if (result != null)
            {
                result.BranchId = entity.BranchId;
                result.CourseId = entity.CourseId;
                result.TeacherId = entity.TeacherId;
                result.Students = entity.Students;
                context.SaveChanges();
            }
        }
    }
}
