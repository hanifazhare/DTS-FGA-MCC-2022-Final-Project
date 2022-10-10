using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LeaveManagementWebAPI.Models.ViewModels
{
    public class LeaveStatusTypeViewModel
    {
        public int id { get; set; }
        public string name { get; set; }
    }
}
