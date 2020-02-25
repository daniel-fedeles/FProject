using System.Collections.Generic;
using System.ComponentModel;

namespace StudentManager.web.ViewModels
{
    public class ClassViewModel
    {
        public ClassViewModel()
        {
            Students = new List<StudentsViewModel>();
        }
        public string Id { get; set; }

        [DisplayName("Class Name")]
        public string ClassName { get; set; }

        [DisplayName("Number of students")]
        public int NrOfStudentsAllocated { get; set; }

        [DisplayName("Active Class")]
        public bool IsActive { get; set; }

        public ICollection<StudentsViewModel> Students { get; set; }
    }
}