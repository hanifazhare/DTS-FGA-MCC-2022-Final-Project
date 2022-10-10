using LeaveManagementWebAPI.Contexts;
using LeaveManagementWebAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LeaveManagementWebAPI.Models;
using LeaveManagementWebAPI.Models.ViewModels;

namespace LeaveManagementWebAPI.Repositories.Datas
{
    public class LeaveStatusTypeRepository : ILeaveStatusTypeRepository
    {
        private readonly DBContext _dbContext;

        public LeaveStatusTypeRepository(DBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<LeaveStatusType> GetData()
        {
            return _dbContext.LeaveStatusTypes.ToList();
        }

        public LeaveStatusType GetData(int id)
        {
            return _dbContext.LeaveStatusTypes.Find(id);
        }
    }
}

