using LeaveManagementWebAPI.Contexts;
using LeaveManagementWebAPI.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LeaveManagementWebAPI.Models;
using LeaveManagementWebAPI.Models.ViewModels;

namespace LeaveManagementWebAPI.Repositories.Data
{
    public class LeaveStatusTypeRepository : ILeaveStatusTypeRepository
    {
        DBContext dBContext;

        public LeaveStatusTypeRepository(DBContext dBContext)
        {
            this.dBContext = dBContext;
        }
        public int Delete(int id)
        {
            var data = dBContext.LeaveStatusTypes.Find(id);
            dBContext.LeaveStatusTypes.Remove(data);
            var result = dBContext.SaveChanges();
            return result;
        }

        public List<LeaveStatusTypeViewModel> Get()
        {
            var data = dBContext.LeaveStatusTypes.Select(x => new LeaveStatusTypeViewModel
            {
                id = x.id,
                name = x.name
            }).ToList();

            return data;
        }

        public LeaveStatusTypeViewModel Get(int id)
        {
            var data = dBContext.LeaveStatusTypes.Where(x => x.id == id).Select(x => new LeaveStatusTypeViewModel
            {
                id = x.id,
                name = x.name,
            }).FirstOrDefault();
            return data;
        }

        public int Post(LeaveStatusTypeViewModel leaveStatus)
        {
            dBContext.LeaveStatusTypes.Add(new LeaveStatusType
            {
                name = leaveStatus.name
            });
            var result = dBContext.SaveChanges();
            return result;
        }

        public int Put(int id, LeaveStatusTypeViewModel leaveStatus)
        {
            var data = dBContext.LeaveStatusTypes.Find(id);
            data.name = leaveStatus.name;
            dBContext.LeaveStatusTypes.Update(data);
            var result = dBContext.SaveChanges();
            return result;
        }
    }
}

