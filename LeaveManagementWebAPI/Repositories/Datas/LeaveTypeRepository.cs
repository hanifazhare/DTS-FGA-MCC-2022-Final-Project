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
    public class LeaveTypeRepository : ILeaveTypeRepository
    {
        private readonly DBContext _dbContext;

        public LeaveTypeRepository(DBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<LeaveType> GetData()
        {
            return _dbContext.LeaveTypes.ToList();
        }

        public LeaveType GetData(int id)
        {
            return _dbContext.LeaveTypes.Find(id);
        }

        public int EditData(LeaveTypeViewModel leaveTypeViewModel)
        {
            int result = 0;
            var data = GetData(leaveTypeViewModel.id);

            if (data != null)
            {
                data.name = leaveTypeViewModel.name;

                _dbContext.LeaveTypes.Update(data);
                result = _dbContext.SaveChanges();

                return result;

            }

            return result;
        }

        public int CreateData(LeaveTypeViewModel leaveTypeViewModel)
        {
            _dbContext.LeaveTypes.Add(new LeaveType
            {
                name = leaveTypeViewModel.name
            });
            var result = _dbContext.SaveChanges();
            
            return result;
        }

        public int DeleteData(int id)
        {
            var data = GetData(id);

            _dbContext.LeaveTypes.Remove(data);
            var result = _dbContext.SaveChanges();
            
            return result;
        }
    }
}
