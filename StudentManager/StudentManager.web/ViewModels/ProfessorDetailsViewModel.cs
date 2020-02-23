using StudentManager.DomainModels;
using System.Collections.Generic;

namespace StudentManager.web.ViewModels
{
    public class ProfessorDetailsViewModel : BaseViewModel
    {
        public ICollection<Course> Courses { get; set; }
    }
}