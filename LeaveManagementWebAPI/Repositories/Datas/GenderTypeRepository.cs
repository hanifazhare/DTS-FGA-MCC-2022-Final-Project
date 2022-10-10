using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LeaveManagementWebAPI.Models.ViewModels;
using LeaveManagementWebAPI.Repositories.Interfaces;
using LeaveManagementWebAPI.Contexts;
using LeaveManagementWebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace LeaveManagementWebAPI.Repositories.Datas
{
    public class GenderTypeRepository : IGenderTypeRepository
    {
        private readonly DBContext _dbContext;

        public GenderTypeRepository(DBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<GenderType> GetData()
        {
            return _dbContext.GenderTypes.ToList();
        }

        public GenderType GetData(int id)
        {
            return _dbContext.GenderTypes.Find(id);
        }
    }
}
