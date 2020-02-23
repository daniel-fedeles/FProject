using StudentManager.DomainModels;
using System.Collections.Generic;

namespace StudentManager.web.ViewModels
{
    public class StudentDetailsViewModel : BaseViewModel
    {
        public int Year { get; set; }
        public ICollection<Course> Courses { get; set; }
        public ICollection<Grade> Grades { get; set; }
        public StudentClass StudentClass { get; set; }

    }
}