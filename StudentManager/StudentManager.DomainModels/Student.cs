using System.Collections.Generic;

namespace StudentManager.DomainModels
{
    public class Student : UserBase
    {
        public int Year { get; set; }
        public ICollection<Course> Courses { get; set; }
        public ICollection<Grade> Grades { get; set; }
        public StudentClass StudentClass { get; set; }
        public string StudentClassId { get; set; }

    }
}
