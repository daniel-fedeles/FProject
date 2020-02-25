using System.Collections.Generic;

namespace StudentManager.DomainModels
{
    public class StudentClass : Active
    {
        public StudentClass()
        {
            Students = new List<Student>();
        }
        public string Id { get; set; }

        public string Name { get; set; }
        public ICollection<Student> Students { get; set; }
    }
}