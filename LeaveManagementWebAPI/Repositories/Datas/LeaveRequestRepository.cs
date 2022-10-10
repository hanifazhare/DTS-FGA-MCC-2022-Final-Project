using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LeaveManagementWebAPI.Models;
using LeaveManagementWebAPI.Models.ViewModels;
using LeaveManagementWebAPI.Repositories.Interfaces;
using LeaveManagementWebAPI.Contexts;
using Microsoft.EntityFrameworkCore;

namespace LeaveManagementWebAPI.Repositories.Datas
{
    public class LeaveRequestRepository : ILeaveRequestRepository
    {
        private readonly DBContext _dbContext;

        public LeaveRequestRepository(DBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<LeaveRequest> GetData()
        {
            return _dbContext.LeaveRequests
                .Include(model => model.leaveType)
                .Include(model => model.leaveStatusType)
                .Include(model => model.user)
                .ToList();
        }

        public LeaveRequest GetData(int id)
        {
            return _dbContext.LeaveRequests
                .Include(model => model.leaveType)
                .Include(model => model.leaveStatusType)
                .Include(model => model.user)
                .FirstOrDefault(model => model.id == id);
        }

        public int EditData(LeaveRequestViewModel leaveRequestViewModel)
        {
            int result = 0;
            var data = GetData(leaveRequestViewModel.id);

            if (data != null)
            {
                data.leaveStatusTypeId = leaveRequestViewModel.leaveStatusTypeId;
                data.note = leaveRequestViewModel.note;
                data.updatedAt = DateTime.Now;

                _dbContext.LeaveRequests.Update(data);
                result = _dbContext.SaveChanges();

                return result;

            }

            return result;
        }

        public int CreateData(LeaveRequestViewModel leaveRequestViewModel)
        {
            _dbContext.LeaveRequests.Add(new LeaveRequest
            {
                leaveTypeId = leaveRequestViewModel.leaveTypeId,
                leaveStatusTypeId = leaveRequestViewModel.leaveStatusTypeId,
                userId = leaveRequestViewModel.userId,
                requestedDays = leaveRequestViewModel.requestedDays,
                startDate = leaveRequestViewModel.startDate,
                endDate = leaveRequestViewModel.endDate,
                reason = leaveRequestViewModel.reason,
                createdAt = DateTime.Now,
                updatedAt = DateTime.Now
            });
            var result = _dbContext.SaveChanges();

            return result;
        }

        public int DeleteData(int id)
        {
            var data = GetData(id);

            _dbContext.LeaveRequests.Remove(data);
            var result = _dbContext.SaveChanges();
            
            return result;
        }
    }
}
