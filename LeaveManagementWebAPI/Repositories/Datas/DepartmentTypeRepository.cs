using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LeaveManagementWebAPI.Contexts;
using LeaveManagementWebAPI.Models.ViewModels;
using LeaveManagementWebAPI.Repositories.Interfaces;
using LeaveManagementWebAPI.Models;

namespace LeaveManagementWebAPI.Repositories.Datas
{
    public class DepartmentTypeRepository : IDepartmentTypeRepository
    {
        private readonly DBContext _dbContext;

        public DepartmentTypeRepository(DBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<DepartmentType> GetData()
        {
            return _dbContext.DepartmentTypes.ToList();
        }

        public DepartmentType GetData(int id)
        {
            return _dbContext.DepartmentTypes.Find(id);
        }

        public int EditData(DepartmentTypeViewModel departmentTypeViewModel)
        {
            int result = 0;
            var data = GetData(departmentTypeViewModel.id);

            if (data != null)
            {
                data.name = departmentTypeViewModel.name;
                _dbContext.DepartmentTypes.Update(data);
                result = _dbContext.SaveChanges();

                return result;

            }
            
            return result;
        }

        public int CreateData(DepartmentTypeViewModel departmentTypeViewModel)
        {
            _dbContext.DepartmentTypes.Add(new DepartmentType
            {
                name = departmentTypeViewModel.name
            });
            var result = _dbContext.SaveChanges();

            return result;
        }

        public int DeleteData(int id)
        {
            var data = GetData(id);

            _dbContext.DepartmentTypes.Remove(data);
            var result = _dbContext.SaveChanges();

            return result;
        }
    }
}
