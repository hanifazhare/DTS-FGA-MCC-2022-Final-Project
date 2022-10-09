using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LeaveManagementWebAPI.Models
{
    public class User
    {
        public Employee employee { get; set; }

        [Key]
        [ForeignKey("employee")]
        public int id { get; set; }

        public UserRoleType userRoleType { get; set; }

        [ForeignKey("userRoleType")]
        public int userRoleTypeId { get; set; }

        [Required]
        public int availableLeaves { get; set; }

        [Required]
        [Column(TypeName = "varchar(255)")]
        public string password { get; set; }

        [Required]
        [Column(TypeName = "datetime")]
        public DateTime registeredAt { get; set; }

        [Required]
        [Column(TypeName = "datetime")]
        public DateTime updatedAt { get; set; }
    }
}