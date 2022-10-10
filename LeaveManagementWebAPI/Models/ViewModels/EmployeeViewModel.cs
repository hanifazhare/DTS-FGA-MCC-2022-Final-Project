namespace LeaveManagementWebAPI.Models.ViewModels
{
    public class EmployeeViewModel
    {
        public int id { get; set; }
        
        public string firstName { get; set; }

        public string lastName { get; set; }

        public int genderTypeId { get; set; }
        
        public string email { get; set; }
        
        public string phoneNumber { get; set; }

        public int departmentId { get; set; }

        public int managerId { get; set; }
    }
}
