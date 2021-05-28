using CourseApp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CourseApp.Data.Abstract
{
    public interface ICourseProgramRepository:IRepository<CoursePrograms>
    {
        IQueryable<CoursePrograms> searchByBranch(int branchId);
        IQueryable<CoursePrograms> searchByCourse(int courseId);
        IQueryable<CoursePrograms> searchByTeacher(int teacherId);
        void AddStudent(int programId,int StudentId);
    }
}
