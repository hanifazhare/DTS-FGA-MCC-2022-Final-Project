using System.Collections.Generic;
using LeaveManagementWebAPI.Models;

namespace LeaveManagementWebAPI.Repositories.Interfaces
{
    interface IGenderTypeRepository
    {
        List<GenderType> GetData();

        GenderType GetData(int id);
    }
}
