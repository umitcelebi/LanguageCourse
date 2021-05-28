using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CourseApp.Entity
{
    public class Course
    {
        public int CourseId { get; set; }
        [Required(ErrorMessage = "You must enter a Course Name.")]
        public string CourseName { get; set; }

        public List<CoursePrograms> CoursePrograms { get; set; }
    }
}
