using System;

namespace LeaveManagementWebAPI.Models.ViewModels
{
    public class LeaveRequestViewModel
    {
        public int id { get; set; }

        public int leaveTypeId { get; set; }

        public int leaveStatusTypeId { get; set; }

        public int userId { get; set; }
        
        public int requestedDays { get; set; }
        
        public DateTime startDate { get; set; }
        
        public DateTime endDate { get; set; }
        
        public string reason { get; set; }
        
        public string note { get; set; }
    }
}
