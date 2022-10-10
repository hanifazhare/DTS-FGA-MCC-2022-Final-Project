using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LeaveManagementWebAPI.Models
{
    public class UserRoleType
    {
        [Key]
        public int id { get; set; }

        [Required]
        [Column(TypeName = "varchar(255)")]
        public string name { get; set; }
    }
}