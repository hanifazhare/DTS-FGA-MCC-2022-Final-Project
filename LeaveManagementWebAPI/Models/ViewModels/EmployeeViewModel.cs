using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LeaveManagementWebAPI.Models.ViewModels
{
    public class EmployeeViewModel
    {
        public int id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }

        public GenderTypeViewModel GenderType { get; set; }

        public int genderTypeId { get; set; }
        public string email { get; set; }
        public string phoneNumber { get; set; }

        public DepartmentType DepartmentType { get; set; }
        public int departmentId { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime updatedAt { get; set; }
    }
}
