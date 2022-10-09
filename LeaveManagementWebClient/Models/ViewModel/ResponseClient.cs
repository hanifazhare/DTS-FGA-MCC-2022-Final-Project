using LeaveManagementWebAPI.Models.ViewModel;

namespace LeaveManagementWebClient.Models.ViewModel
{
    public class ResponseClient
    {
        public string Message { get; set; }
        public int StatusCode { get; set; }
        public ResponseLogin Data { get; set; }
    }
}
