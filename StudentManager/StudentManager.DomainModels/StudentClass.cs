using System.Collections.Generic;
using System.ComponentModel;

namespace StudentManager.DomainModels
{
    public class StudentClass : Active
    {
        public StudentClass()
        {
            Students = new List<Student>();
        }
        public string Id { get; set; }

        [DisplayName("Class Name")]
        public string Name { get; set; }
        public ICollection<Student> Students { get; set; }
    }
}