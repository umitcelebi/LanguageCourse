using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CourseApp.Entity
{
    public class Teacher
    {
        public int TeacherId { get; set; }
        [Required(ErrorMessage = "You must enter teacher name")]
        public string TeacherName { get; set; }
        [Required(ErrorMessage = "You must enter phone number")]
        [StringLength(maximumLength: 13, MinimumLength = 10, ErrorMessage = "Phone number must be true")]
        public string Phone { get; set; }
        public List<CoursePrograms> CoursePrograms { get; set; }
    }
}
