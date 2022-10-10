using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LeaveManagementWebAPI.Contexts;
using LeaveManagementWebAPI.Models.ViewModels;
using LeaveManagementWebAPI.Repositories.Interface;
using LeaveManagementWebAPI.Models;

namespace LeaveManagementWebAPI.Repositories.Data
{
    public class DepartementTypeRepository : IDepartementTypeRepository
    {
        DBContext dBContext;

        public DepartementTypeRepository(DBContext dBContext)
        {
            this.dBContext = dBContext;
        }
        public int Delete(int id)
        {
            var data = dBContext.DepartmentTypes.Find(id);
            dBContext.DepartmentTypes.Remove(data);
            var result = dBContext.SaveChanges();
            return result;
        }

        public List<DepartementTypeViewModel> Get()
        {
            var data = dBContext.DepartmentTypes.Select(x => new DepartementTypeViewModel
            {
                id = x.id,
                name = x.name
            }).ToList();

            return data;
        }

        public DepartementTypeViewModel Get(int id)
        {
            var data = dBContext.DepartmentTypes.Where(x => x.id == id).Select(x => new DepartementTypeViewModel
            {
                id = x.id,
                name = x.name,
            }).FirstOrDefault();
            return data;
        }

        public int Post(DepartementTypeViewModel departementType)
        {
            dBContext.DepartmentTypes.Add(new DepartmentType
            {
                name = departementType.name
            });
            var result = dBContext.SaveChanges();
            return result;
        }

        public int Put(int id, DepartementTypeViewModel departementType)
        {
            var data = dBContext.DepartmentTypes.Find(id);
            data.name = departementType.name;
            dBContext.DepartmentTypes.Update(data);
            var result = dBContext.SaveChanges();
            return result;
        }
    }
}
