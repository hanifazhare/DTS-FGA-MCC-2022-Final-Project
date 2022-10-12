using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace LeaveManagementWebClient.Models.ViewModels
{
    public class AccountViewModel
    {
        public string firstName { get; set; }

        public string lastName { get; set; }

        public string email { get; set; }

        public string password { get; set; }

        public string repeatPassword { get; set; }
    }
}
