using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LeaveManagementWebAPI.Contexts;
using LeaveManagementWebAPI.Models.ViewModels;
using LeaveManagementWebAPI.Models;
using LeaveManagementWebAPI.Repositories.Interfaces;

namespace LeaveManagementWebAPI.Repositories.Datas
{
    public class UserRoleTypeRepository : IUserRoleTypeRepository
    {
        private readonly DBContext _dbContext;

        public UserRoleTypeRepository(DBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<UserRoleType> GetData()
        {
            return _dbContext.UserRoleTypes.ToList();
        }

        public UserRoleType GetData(int id)
        {
            return _dbContext.UserRoleTypes.Find(id);
        }
    }
}
