using System.Collections.Generic;
using LeaveManagementWebAPI.Models;
using LeaveManagementWebAPI.Models.ViewModels;

namespace LeaveManagementWebAPI.Repositories.Interfaces
{
    interface ILeaveRequestRepository
    {
        List<LeaveRequest> GetData();

        LeaveRequest GetData(int id);

        int EditData(LeaveRequestViewModel leaveRequestViewModel);

        int CreateData(LeaveRequestViewModel leaveRequestViewModel);
        
        int DeleteData(int id);
    }
}
