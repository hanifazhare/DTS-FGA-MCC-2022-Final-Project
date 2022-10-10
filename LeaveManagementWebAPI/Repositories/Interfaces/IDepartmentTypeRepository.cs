using System.Collections.Generic;
using LeaveManagementWebAPI.Models;
using LeaveManagementWebAPI.Models.ViewModels;

namespace LeaveManagementWebAPI.Repositories.Interfaces
{
    interface IDepartmentTypeRepository
    {
        List<DepartmentType> GetData();

        DepartmentType GetData(int id);

        int EditData(DepartmentTypeViewModel departmentTypeViewModel);

        int CreateData(DepartmentTypeViewModel departmentTypeViewModel);

        int DeleteData(int id);
    }
}
