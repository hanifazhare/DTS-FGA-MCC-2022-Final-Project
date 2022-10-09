using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LeaveManagementWebAPI.Models.ViewModels;

namespace LeaveManagementWebAPI.Repositories.Interface
{
    interface IEmployeeRepository
    {
        List<EmployeeViewModel> Get();
        EmployeeViewModel Get(int id);
        int Post(EmployeeViewModel employee);
        int Put(int id, EmployeeViewModel employee);
        int Delete(int id);
    }
}
