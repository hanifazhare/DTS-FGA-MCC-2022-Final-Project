using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LeaveManagementWebAPI.Models.ViewModels;

namespace LeaveManagementWebAPI.Repositories.Interfaces
{
    interface IUserRepository
    {
        List<UserViewModel> Get();
        UserViewModel Get(int id);
        int Post(UserViewModel user);
        int Put(int id, UserViewModel user);
        int Delete(int id);
    }
}
