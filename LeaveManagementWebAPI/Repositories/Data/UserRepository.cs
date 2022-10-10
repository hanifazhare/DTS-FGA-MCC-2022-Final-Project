using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LeaveManagementWebAPI.Contexts;
using LeaveManagementWebAPI.Repositories.Interface;
using LeaveManagementWebAPI.Models;
using LeaveManagementWebAPI.Models.ViewModels;

namespace LeaveManagementWebAPI.Repositories.Data
{
    public class UserRepository : IUserRepository
    {
        DBContext dBContext;

        public UserRepository(DBContext dBContext)
        {
            this.dBContext = dBContext;
        }
        public int Delete(int id)
        {
            var data = dBContext.Users.Find(id);
            dBContext.Users.Remove(data);
            var result = dBContext.SaveChanges();
            return result;
        }

        public List<UserViewModel> Get()
        {
            var data = dBContext.Users.Select(x => new UserViewModel
            {
                id = x.id,
                userRoleTypeId = x.userRoleTypeId,
                availableLeaves = x.availableLeaves,
                password = x.password,
                registeredAt = x.registeredAt,
                updatedAt = x.updatedAt

            }).ToList();

            return data;
        }

        public UserViewModel Get(int id)
        {
            var data = dBContext.Users.Where(x => x.id == id).Select(x => new UserViewModel
            {
                id = x.id,
                userRoleTypeId = x.userRoleTypeId,
                availableLeaves = x.availableLeaves,
                password = x.password,
                registeredAt = x.registeredAt,
                updatedAt = x.updatedAt
            }).FirstOrDefault();
            return data;
        }

        public int Post(UserViewModel user)
        {
            dBContext.Users.Add(new User
            {
                userRoleTypeId = user.userRoleTypeId,
                availableLeaves = user.availableLeaves,
                password = user.password,
                registeredAt = user.registeredAt,
                updatedAt = user.updatedAt
            });
            var result = dBContext.SaveChanges();
            return result;
        }

        public int Put(int id, UserViewModel user)
        {
            var data = dBContext.Users.Find(id);
            data.id = user.id;
            data.userRoleTypeId = user.userRoleTypeId;
            data.availableLeaves = user.availableLeaves;
            data.password = user.password;
            data.registeredAt = user.registeredAt;
            data.updatedAt = user.updatedAt;
            dBContext.Users.Update(data);
            var result = dBContext.SaveChanges();
            return result;
        }
    }
}
