using System.ComponentModel.DataAnnotations;

namespace LeaveManagementWebAPI.Models.ViewModels
{
    public class ChangePasswordViewModel
    {
        [Display(Name = "Email")]
        public string email { get; set; }

        [Display(Name = "Old Password")]
        public string oldPassword { get; set; }

        [Display(Name = "New Password")]
        public string newPassword { get; set; }
    }
}
