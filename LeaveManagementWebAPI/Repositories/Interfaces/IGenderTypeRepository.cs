using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LeaveManagementWebAPI.Models.ViewModels;

namespace LeaveManagementWebAPI.Repositories.Interfaces
{
    interface IGenderTypeRepository
    {
        List<GenderTypeViewModel> Get();
        GenderTypeViewModel Get(int id);
        int Post(GenderTypeViewModel gender);
        int Put(int id, GenderTypeViewModel gender);
        int Delete(int id);
    }
}
