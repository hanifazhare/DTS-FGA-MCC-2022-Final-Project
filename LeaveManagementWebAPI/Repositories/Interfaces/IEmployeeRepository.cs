using System.Collections.Generic;
using LeaveManagementWebAPI.Models;
using LeaveManagementWebAPI.Models.ViewModels;

namespace LeaveManagementWebAPI.Repositories.Interfaces
{
    interface IEmployeeRepository
    {
        List<Employee> GetData();

        Employee GetData(int id);

        int EditData(EmployeeViewModel employeeViewModel);

        int CreateData(EmployeeViewModel employeeViewModel);
        
        int DeleteData(int id);
    }
}
