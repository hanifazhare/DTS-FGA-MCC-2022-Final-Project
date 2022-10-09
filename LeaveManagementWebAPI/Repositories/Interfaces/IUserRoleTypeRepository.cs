using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LeaveManagementWebAPI.Models.ViewModels;

namespace LeaveManagementWebAPI.Repositories.Interfaces
{
    interface IUserRoleTypeRepository
    {
        List<UserRoleTypeViewModel> Get();
        UserRoleTypeViewModel Get(int id);
        int Post(UserRoleTypeViewModel userRole);
        int Put(int id, UserRoleTypeViewModel userRole);
        int Delete(int id);
    }
}
