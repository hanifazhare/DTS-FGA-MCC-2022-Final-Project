using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LeaveManagementWebAPI.Models.ViewModels;
using LeaveManagementWebAPI.Models;
using LeaveManagementWebAPI.Repositories.Interface;
using LeaveManagementWebAPI.Contexts;

namespace LeaveManagementWebAPI.Repositories.Data
{
    public class EmployeeRepository : IEmployeeRepository
    {
        DBContext dBContext;

        public EmployeeRepository(DBContext dBContext)
        {
            this.dBContext = dBContext;
        }
        public int Delete(int id)
        {
            var data = dBContext.Employees.Find(id);
            dBContext.Employees.Remove(data);
            var result = dBContext.SaveChanges();
            return result;
        }

        public List<EmployeeViewModel> Get()
        {
            var data = dBContext.Employees.Select(x => new EmployeeViewModel
            {
                id = x.id,
                firstName = x.firstName,
                lastName = x.lastName,
                genderTypeId = x.genderTypeId,
                email = x.email,
                phoneNumber = x.phoneNumber,
                departmentId = x.departmentId,
                createdAt = x.createdAt,
                updatedAt = x.updatedAt
            }).ToList();

            return data;
        }

        public EmployeeViewModel Get(int id)
        {
            var data = dBContext.Employees.Where(x => x.id == id).Select(x => new EmployeeViewModel
            {
                id = x.id,
                firstName = x.firstName,
                lastName = x.lastName,
                genderTypeId = x.genderTypeId,
                email = x.email,
                phoneNumber = x.phoneNumber,
                departmentId = x.departmentId,
                createdAt = x.createdAt,
                updatedAt = x.updatedAt
            }).FirstOrDefault();
            return data;
        }

        public int Post(EmployeeViewModel employee)
        {
            dBContext.Employees.Add(new Employee
            {
                firstName = employee.firstName,
                lastName = employee.lastName,
                genderTypeId = employee.genderTypeId,
                email = employee.email,
                phoneNumber = employee.phoneNumber,
                departmentId = employee.departmentId,
                createdAt = employee.createdAt,
                updatedAt = employee.updatedAt
            });
            var result = dBContext.SaveChanges();
            return result;
        }

        public int Put(int id, EmployeeViewModel employee)
        {
            var data = dBContext.Employees.Find(id);
            data.firstName = employee.firstName;
            data.lastName = employee.lastName;
            data.genderTypeId = employee.genderTypeId;
            data.email = employee.email;
            data.phoneNumber = employee.phoneNumber;
            data.departmentId = employee.departmentId;
            data.createdAt = employee.createdAt;
            data.updatedAt = employee.updatedAt;
            dBContext.Employees.Update(data);
            var result = dBContext.SaveChanges();
            return result;
        }
    }
}
