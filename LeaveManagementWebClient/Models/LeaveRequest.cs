using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LeaveManagementWebClient.Models
{
    public class LeaveRequest
    {
        [Key]
        public int id { get; set; }

        public LeaveType leaveType { get; set; }

        [ForeignKey("leaveType")]
        public int leaveTypeId { get; set; }

        public LeaveStatusType leaveStatusType { get; set; }

        [ForeignKey("leaveStatusType")]
        public int leaveStatusTypeId { get; set; }

        public User user { get; set; }

        [ForeignKey("user")]
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
