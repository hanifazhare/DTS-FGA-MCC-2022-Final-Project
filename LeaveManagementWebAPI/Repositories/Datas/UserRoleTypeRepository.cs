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
    public class UserRoleTypeRepository : IUserRoleTypeRepository
    {
        DBContext dBContext;

        public UserRoleTypeRepository(DBContext dBContext)
        {
            this.dBContext = dBContext;
        }
        public int Delete(int id)
        {
            var data = dBContext.UserRoleTypes.Find(id);
            dBContext.UserRoleTypes.Remove(data);
            var result = dBContext.SaveChanges();
            return result;
        }

        public List<UserRoleTypeViewModel> Get()
        {
            var data = dBContext.UserRoleTypes.Select(x => new UserRoleTypeViewModel
            {
                id = x.id,
                name = x.name
            }).ToList();

            return data;
        }

        public UserRoleTypeViewModel Get(int id)
        {
            var data = dBContext.UserRoleTypes.Where(x => x.id == id).Select(x => new UserRoleTypeViewModel
            {
                id = x.id,
                name = x.name,
            }).FirstOrDefault();
            return data;
        }

        public int Post(UserRoleTypeViewModel userRole)
        {
            dBContext.UserRoleTypes.Add(new UserRoleType
            {
                name = userRole.name
            });
            var result = dBContext.SaveChanges();
            return result;
        }

        public int Put(int id, UserRoleTypeViewModel userRole)
        {
            var data = dBContext.UserRoleTypes.Find(id);
            data.name = userRole.name;
            dBContext.UserRoleTypes.Update(data);
            var result = dBContext.SaveChanges();
            return result;
        }
    }
}
