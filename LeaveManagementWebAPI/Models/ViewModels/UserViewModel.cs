using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LeaveManagementWebAPI.Models.ViewModels
{
    public class UserViewModel
    {
        public Employee Employee { get; set; }
        public int id { get; set; }

        public UserRoleTypeViewModel UserRoleType { get; set; }
        public int userRoleTypeId { get; set; }
        public int availableLeaves { get; set; }
        public string password { get; set; }
        public DateTime registeredAt { get; set; }
        public DateTime updatedAt { get; set; }
    }
}
