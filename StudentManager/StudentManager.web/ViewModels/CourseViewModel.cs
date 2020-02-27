using StudentManager.DomainModels;
using System.Collections.Generic;

namespace StudentManager.web.ViewModels
{
    public class CourseViewModel
    {
        public CourseViewModel()
        {
            Students = new List<StudentsViewModel>();
            Professor = new List<ProfessorsViewModel>();
        }
        public string Id { get; set; }

        public string Name { get; set; }

        public int Year { get; set; }

        public int Semester { get; set; }

        public int Credits { get; set; }
        public ICollection<StudentsViewModel> Students { get; set; }
        public ICollection<ProfessorsViewModel> Professor { get; set; }
        public ICollection<Grade> Grades { get; set; }
    }
}