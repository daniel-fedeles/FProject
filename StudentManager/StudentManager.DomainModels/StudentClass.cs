using System.Collections.Generic;

namespace StudentManager.DomainModels
{
    public class StudentClass : Active
    {

        public string ClassId { get; set; }

        public string ClassName { get; set; }
        public ICollection<Student> Students { get; set; }
    }
}