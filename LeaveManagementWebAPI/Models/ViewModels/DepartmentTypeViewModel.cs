using System.ComponentModel.DataAnnotations;

namespace LeaveManagementWebAPI.Models.ViewModels
{
    public class DepartmentTypeViewModel
    {
        [Display(Name = "ID")]
        public int id { get; set; }

        [Display(Name = "Name")]
        public string name { get; set; }
    }
}
