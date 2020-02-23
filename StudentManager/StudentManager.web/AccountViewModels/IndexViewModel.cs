using Microsoft.AspNet.Identity;
using StudentManager.DomainModels;
using System.Collections.Generic;

namespace StudentManager.web.AccountViewModels
{
    public class IndexViewModel
    {
        public bool HasPassword { get; set; }
        public IList<UserLoginInfo> Logins { get; set; }
        public string PhoneNumber { get; set; }
        public bool TwoFactor { get; set; }
        public bool BrowserRemembered { get; set; }

        public ApplicationUser Student { get; set; }

        public List<Grade> Grades { get; set; }

        public string StudentClassId { get; set; }

        public StudentClass StudentClass { get; set; }


        public ICollection<Course> Courses { get; set; }
    }
}