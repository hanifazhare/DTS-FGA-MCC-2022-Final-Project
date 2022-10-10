using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LeaveManagementWebAPI.Models
{
    public class LeaveRequest
    {
        [Key]
        public int id { get; set; }

        public LeaveType LeaveType { get; set; }

        [ForeignKey("LeaveType")]
        public int leaveTypeId { get; set; }

        public LeaveStatusType LeaveStatusType { get; set; }

        [ForeignKey("LeaveStatusType")]
        public int leaveStatusTypeId { get; set; }

        public User User { get; set; }

        [ForeignKey("User")]
        public int userId { get; set; }

        [Required]
        public int requestedDays { get; set; }

        [Required]
        [Column(TypeName = "datetime")]
        public DateTime startDate { get; set; }

        [Required]
        [Column(TypeName = "datetime")]
        public DateTime endDate { get; set; }

        [Column(TypeName = "text")]
        public string reason { get; set; }

        [Column(TypeName = "text")]
        public string note { get; set; }

        [Required]
        [Column(TypeName = "datetime")]
        public DateTime createdAt { get; set; }

        [Required]
        [Column(TypeName = "datetime")]
        public DateTime updatedAt { get; set; }
    }
}