using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using LeaveManagementWebAPI.Models.ViewModels;

namespace LeaveManagementWebAPI.Models
{
    public class Employee
    {
        [Key]
        public int id { get; set; }

        [Required]
        [Column(TypeName = "varchar(255)")]
        public string firstName { get; set; }

        [Column(TypeName = "varchar(255)")]
        public string lastName { get; set; }

        public GenderType GenderType { get; set; }

        [ForeignKey("GenderType")]
        public int genderTypeId { get; set; }

        [Required]
        [Column(TypeName = "varchar(255)")]
        public string email { get; set; }

        [Required]
        [Column(TypeName = "varchar(15)")]
        public string phoneNumber { get; set; }

        public DepartmentType DepartmentType { get; set; }

        [ForeignKey("DepartmentType")]
        public int departmentId { get; set; }

        [Required]
        [Column(TypeName = "datetime")]
        public DateTime createdAt { get; set; }

        [Required]
        [Column(TypeName = "datetime")]
        public DateTime updatedAt { get; set; }
    }
}
