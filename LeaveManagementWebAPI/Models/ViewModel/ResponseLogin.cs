﻿namespace LeaveManagementWebAPI.Models.ViewModel
{
    public class ResponseLogin
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }
        public string Role { get; set; }
        public int JabatanId { get; set; }
    }
}
