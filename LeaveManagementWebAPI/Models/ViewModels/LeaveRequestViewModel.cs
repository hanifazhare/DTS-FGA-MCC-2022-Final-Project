using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LeaveManagementWebAPI.Models.ViewModels
{
    public class LeaveRequestViewModel
    {
        public int id { get; set; }
        public LeaveTypeViewModel LeaveType { get; set; }
        public int leaveTypeId { get; set; }
        public LeaveStatusTypeViewModel LeaveStatusType { get; set; }
        public int leaveStatusTypeId { get; set; }
        public UserViewModel User { get; set; }
        public int userId { get; set; }
        public int requestedDays { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public string reason { get; set; }
        public string note { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime updatedAt { get; set; }
    }
}
