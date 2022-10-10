using System.Collections.Generic;
using LeaveManagementWebAPI.Models;

namespace LeaveManagementWebAPI.Repositories.Interfaces
{
    interface IUserRoleTypeRepository
    {
        List<UserRoleType> GetData();

        UserRoleType GetData(int id);
    }
}
