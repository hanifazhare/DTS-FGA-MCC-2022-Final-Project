namespace LeaveManagementWebClient.Models.ViewModel
{
    public class LeaveRequestViewModel
    {
        public int id { get; set; }

        public int LeaveTypeId { get; set; }

        public int LeaveTypeStatusId { get; set; }

        public int UserId { get; set; }

        public int requestedDay { get; set; }

        public string startDate { get; set; }

        public string endDate { get; set; }

        public string reason { get; set; }

        public string note { get; set; }

        public string createdAt { get; set; }

        public string updatedAt { get; set; }
    }
}
