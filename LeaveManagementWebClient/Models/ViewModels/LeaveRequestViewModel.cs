namespace LeaveManagementWebClient.Models.ViewModels
{
    public class LeaveRequestViewModel
    {
        public int id { get; set; }

        public int leaveTypeId { get; set; }

        public int leaveStatusTypeId { get; set; }

        public int userId { get; set; }

        public int requestedDay { get; set; }

        public string startDate { get; set; }

        public string endDate { get; set; }

        public string reason { get; set; }

        public string note { get; set; }

        public string createdAt { get; set; }

        public string updatedAt { get; set; }
    }
}
