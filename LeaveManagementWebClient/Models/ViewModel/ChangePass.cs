using System.ComponentModel.DataAnnotations;

namespace LeaveManagementWebClient.Models.ViewModel
{
    public class ChangePass
    {
        public string email { get; set; }   

        public string oldPassword { get; set; }

        public string newPassword { get; set; }
    }
}
