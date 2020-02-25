using System.Collections.Generic;

namespace StudentManager.DomainModels
{
    public class Course : Active
    {

        public string Id { get; set; }

        public string Name { get; set; }

        public int Year { get; set; }

        public int Semester { get; set; }

        public int Credits { get; set; }
        public ICollection<Student> Students { get; set; }
        public ICollection<Professor> Professor { get; set; }
        public ICollection<Grade> Grades { get; set; }
    }
}