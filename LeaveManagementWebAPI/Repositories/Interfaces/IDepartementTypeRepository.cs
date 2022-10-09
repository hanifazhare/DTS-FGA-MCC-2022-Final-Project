using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LeaveManagementWebAPI.Models.ViewModels;

namespace LeaveManagementWebAPI.Repositories.Interface
{
    interface IDepartementTypeRepository
    {
        List<DepartementTypeViewModel> Get();
        DepartementTypeViewModel Get(int id);
        int Post(DepartementTypeViewModel departementType);
        int Put(int id, DepartementTypeViewModel departementType);
        int Delete(int id);
    }
}
