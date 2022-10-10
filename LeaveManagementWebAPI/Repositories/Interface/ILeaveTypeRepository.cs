using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LeaveManagementWebAPI.Models.ViewModels;

namespace LeaveManagementWebAPI.Repositories.Interface
{
    interface ILeaveTypeRepository
    {
        List<LeaveTypeViewModel> Get();
        LeaveTypeViewModel Get(int id);
        int Post(LeaveTypeViewModel leaveType);
        int Put(int id, LeaveTypeViewModel leaveType);
        int Delete(int id);
    }
}
