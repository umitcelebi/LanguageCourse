using System;
using System.Collections.Generic;
using System.Text;

namespace CourseApp.Entity
{
    public class CoursePrograms
    {
        public CoursePrograms()
        {
            this.Students = new List<Student>();
        }
        public int CourseProgramsId { get; set; }
        public int BranchId { get; set; }
        public int CourseId { get; set; }
        public int TeacherId { get; set; }
        public Branch Branch { get; set; }
        public Course Course { get; set; }
        public Teacher Teacher { get; set; }
        public List<Student> Students { get; set; }

    }
}
