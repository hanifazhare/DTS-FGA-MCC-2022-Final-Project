using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LeaveManagementWebAPI.Models.ViewModels;

namespace LeaveManagementWebAPI.Repositories.Interface
{
    interface ILeaveRequestRepository
    {
        List<LeaveRequestViewModel> Get();
        LeaveRequestViewModel Get(int id);
        int Post(LeaveRequestViewModel leaveRequest);
        int Put(int id, LeaveRequestViewModel leaveRequest);
        int Delete(int id);
    }
}
