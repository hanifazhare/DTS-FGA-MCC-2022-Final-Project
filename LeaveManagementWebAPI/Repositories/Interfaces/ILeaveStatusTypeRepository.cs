using System.Collections.Generic;
using LeaveManagementWebAPI.Models;

namespace LeaveManagementWebAPI.Repositories.Interfaces
{
    interface ILeaveStatusTypeRepository
    {
        List<LeaveStatusType> GetData();

        LeaveStatusType GetData(int id);
    }
}
