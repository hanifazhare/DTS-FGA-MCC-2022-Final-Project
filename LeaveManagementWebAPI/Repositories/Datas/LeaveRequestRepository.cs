using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LeaveManagementWebAPI.Models;
using LeaveManagementWebAPI.Models.ViewModels;
using LeaveManagementWebAPI.Repositories.Interfaces;
using LeaveManagementWebAPI.Contexts;

namespace LeaveManagementWebAPI.Repositories.Datas
{
    public class LeaveRequestRepository : ILeaveRequestRepository
    {
        DBContext dBContext;

        public LeaveRequestRepository(DBContext dBContext)
        {
            this.dBContext = dBContext;
        }
        public int Delete(int id)
        {
            var data = dBContext.LeaveRequests.Find(id);
            dBContext.LeaveRequests.Remove(data);
            var result = dBContext.SaveChanges();
            return result;
        }

        public List<LeaveRequestViewModel> Get()
        {
            var data = dBContext.LeaveRequests.Select(x => new LeaveRequestViewModel
            {
                id = x.id,
                leaveTypeId = x.leaveTypeId,
                leaveStatusTypeId = x.leaveStatusTypeId,
                userId = x.userId,
                requestedDays = x.requestedDays,
                startDate = x.startDate,
                endDate = x.endDate,
                reason = x.reason,
                note = x.note,
                createdAt = x.createdAt,
                updatedAt = x.updatedAt
            }).ToList();

            return data;
        }

        public LeaveRequestViewModel Get(int id)
        {
            var data = dBContext.LeaveRequests.Where(x => x.id == id).Select(x => new LeaveRequestViewModel
            {
                id = x.id,
                leaveTypeId = x.leaveTypeId,
                leaveStatusTypeId = x.leaveStatusTypeId,
                userId = x.userId,
                requestedDays = x.requestedDays,
                startDate = x.startDate,
                endDate = x.endDate,
                reason = x.reason,
                note = x.note,
                createdAt = x.createdAt,
                updatedAt = x.updatedAt
            }).FirstOrDefault();
            return data;
        }

        public int Post(LeaveRequestViewModel leaveRequest)
        {
            dBContext.LeaveRequests.Add(new LeaveRequest
            {
                id = leaveRequest.id,
                leaveTypeId = leaveRequest.leaveTypeId,
                leaveStatusTypeId = leaveRequest.leaveStatusTypeId,
                userId = leaveRequest.userId,
                requestedDays = leaveRequest.requestedDays,
                startDate = leaveRequest.startDate,
                endDate = leaveRequest.endDate,
                reason = leaveRequest.reason,
                note = leaveRequest.note,
                createdAt = leaveRequest.createdAt,
                updatedAt = leaveRequest.updatedAt
            });
            var result = dBContext.SaveChanges();
            return result;
        }

        public int Put(int id, LeaveRequestViewModel leaveRequest)
        {
            var data = dBContext.LeaveRequests.Find(id);
            data.id = leaveRequest.id;
            data.leaveTypeId = leaveRequest.leaveTypeId;
            data.leaveStatusTypeId = leaveRequest.leaveStatusTypeId;
            data.userId = leaveRequest.userId;
            data.requestedDays = leaveRequest.requestedDays;
            data.startDate = leaveRequest.startDate;
            data.endDate = leaveRequest.endDate;
            data.reason = leaveRequest.reason;
            data.note = leaveRequest.note;
            data.createdAt = leaveRequest.createdAt;
            data.updatedAt = leaveRequest.updatedAt;
            dBContext.LeaveRequests.Update(data);
            var result = dBContext.SaveChanges();
            return result;
        }
    }
}
