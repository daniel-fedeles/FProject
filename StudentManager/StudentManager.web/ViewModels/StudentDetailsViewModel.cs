using StudentManager.DomainModels;
using System.Collections.Generic;
using System.ComponentModel;

namespace StudentManager.web.ViewModels
{
    public class StudentDetailsViewModel : BaseViewModel
    {
        public StudentDetailsViewModel()
        {
            StudentClasses = new List<StudentClass>();
        }
        public int Year { get; set; }
        public ICollection<Course> Courses { get; set; }
        public ICollection<Grade> Grades { get; set; }

        [DisplayName("Class")]
        public StudentClass StudentClass { get; set; }

        public string StudentClassId { get; set; }

        public ICollection<StudentClass> StudentClasses { get; set; }
        public Course Course { get; set; }
    }
}