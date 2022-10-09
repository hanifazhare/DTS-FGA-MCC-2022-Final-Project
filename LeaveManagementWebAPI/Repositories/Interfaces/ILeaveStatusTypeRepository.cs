using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LeaveManagementWebAPI.Models.ViewModels;

namespace LeaveManagementWebAPI.Repositories.Interface
{
    interface ILeaveStatusTypeRepository
    {
        List<LeaveStatusTypeViewModel> Get();
        LeaveStatusTypeViewModel Get(int id);
        int Post(LeaveStatusTypeViewModel leaveStatus);
        int Put(int id, LeaveStatusTypeViewModel leaveStatus);
        int Delete(int id);
    }
}
