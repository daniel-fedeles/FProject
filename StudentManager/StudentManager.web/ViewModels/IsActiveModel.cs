using System.ComponentModel;

namespace StudentManager.web.ViewModels
{
    public class IsActiveModel
    {
        [DisplayName("Active or Not")]
        public bool IsActive { get; set; }
    }
}