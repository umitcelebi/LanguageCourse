using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CourseApp.Entity
{
    public class Branch
    {
        public int BranchId { get; set; }
        [Required(ErrorMessage = "You must enter a Branch Name")]
        public string BranchName { get; set; }
        public string Address { get; set; }
        public List<CoursePrograms> CoursePrograms { get; set; }
    }
}
