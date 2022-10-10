using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LeaveManagementWebAPI.Contexts;
using LeaveManagementWebAPI.Models.ViewModels;
using LeaveManagementWebAPI.Models;
using LeaveManagementWebAPI.Repositories.Interface;

namespace LeaveManagementWebAPI.Repositories.Data
{
    public class LeaveTypeRepository : ILeaveTypeRepository
    {
        DBContext dBContext;

        public LeaveTypeRepository(DBContext dBContext)
        {
            this.dBContext = dBContext;
        }
        public int Delete(int id)
        {
            var data = dBContext.LeaveTypes.Find(id);
            dBContext.LeaveTypes.Remove(data);
            var result = dBContext.SaveChanges();
            return result;
        }

        public List<LeaveTypeViewModel> Get()
        {
            var data = dBContext.LeaveTypes.Select(x => new LeaveTypeViewModel
            {
                id = x.id,
                name = x.name
            }).ToList();

            return data;
        }

        public LeaveTypeViewModel Get(int id)
        {
            var data = dBContext.LeaveTypes.Where(x => x.id == id).Select(x => new LeaveTypeViewModel
            {
                id = x.id,
                name = x.name,
            }).FirstOrDefault();
            return data;
        }

        public int Post(LeaveTypeViewModel leaveType)
        {
            dBContext.LeaveTypes.Add(new LeaveType
            {
                name = leaveType.name
            });
            var result = dBContext.SaveChanges();
            return result;
        }

        public int Put(int id, LeaveTypeViewModel leaveType)
        {
            var data = dBContext.LeaveTypes.Find(id);
            data.name = leaveType.name;
            dBContext.LeaveTypes.Update(data);
            var result = dBContext.SaveChanges();
            return result;
        }
    }
}
