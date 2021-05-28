using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;


namespace CourseApp.Entity
{
    public class Student
    {
        public Student()
        {
            this.CoursePrograms = new List<CoursePrograms>();
        }
        public int? StudentId { get; set; }
        [Required(ErrorMessage = "You must enter Identity Number")]
        [Range(11111111111,99999999999,ErrorMessage = "Identity Number must be 11 characters")]
        public long IdentityNumber { get; set; }
        [Required(ErrorMessage = "You must enter student name")]
        public string StudentName { get; set; }
        public string StudentSurname { get; set; }
        [Required(ErrorMessage = "You must enter phone number")]
        [StringLength(maximumLength:13,MinimumLength = 10,ErrorMessage = "Phone number must be true")]
        public string Phone { get; set; }
        public string Adress { get; set; }
        public List<CoursePrograms> CoursePrograms { get; set; }
    }
}
