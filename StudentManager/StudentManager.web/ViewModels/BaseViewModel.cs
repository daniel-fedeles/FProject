using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace StudentManager.web.ViewModels
{
    public class BaseViewModel : IsActiveModel
    {
        public string Id { get; set; }

        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [DisplayName("Last Name")]
        public string LastName { get; set; }

        public string Email { get; set; }

        [DisplayName("Birthdate")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyy}")]
        public DateTime BirthDay { get; set; }

        public string Address1 { get; set; }

        public string Address2 { get; set; }

        public string City { get; set; }

        public string Country { get; set; }
    }
}