using System;

namespace StudentManager.DomainModels
{
    public class Grade
    {
        public string Id { get; set; }


        public double Value { get; set; }

        public DateTime DateNote { get; set; }

        public string CourseId { get; set; }
        public string StudentId { get; set; }
        public Student Student { get; set; }
        public Course Course { get; set; }
    }
}