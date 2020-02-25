using StudentManager.DomainModels;
using System;
using System.ComponentModel.DataAnnotations;

namespace StudentManager.web.ViewModels
{
    public class GradeViewModel
    {
        public string Id { get; set; }

        public double Value { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyy}", ApplyFormatInEditMode = true)]
        public DateTime DateNote { get; set; }

        public string CourseId { get; set; }

        public string StudentId { get; set; }

        public Student Student { get; set; }

        public Course Course { get; set; }
    }
}