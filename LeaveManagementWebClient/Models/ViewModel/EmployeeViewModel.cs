using System;

namespace LeaveManagementWebClient.Models.ViewModel
{
    public class EmployeeViewModel
    {
        public int id { get; set; } 

        public string firstname { get; set; }

        public string lasttname { get; set; }

        public int genderTypeId { get; set; }

        public string email { get; set; }

        public string phoneNumber { get; set; }

        public int departmentId { get; set; }

        public string createdAt { get; set; }

        public string updatedAt { get; set; }
    }
}
