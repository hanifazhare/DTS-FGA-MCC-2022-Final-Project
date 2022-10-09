namespace LeaveManagementWebClient.Models.ViewModels
{
    public class ResponseClientViewModel
    {
        public string Message { get; set; }
        public int StatusCode { get; set; }
        public ResponseLoginViewModel Data { get; set; }
    }
}
