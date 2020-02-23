using System.Collections.Generic;

namespace StudentManager.DomainModels
{
    public class Professor : UserBase
    {
        public ICollection<Course> Courses { get; set; }
    }
}