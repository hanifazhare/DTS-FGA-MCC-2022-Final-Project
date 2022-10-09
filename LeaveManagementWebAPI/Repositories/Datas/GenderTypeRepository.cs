using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LeaveManagementWebAPI.Models.ViewModels;
using LeaveManagementWebAPI.Repositories.Interfaces;
using LeaveManagementWebAPI.Contexts;
using LeaveManagementWebAPI.Models;

namespace LeaveManagementWebAPI.Repositories.Datas
{
    public class GenderTypeRepository : IGenderTypeRepository
    {
        DBContext dBContext;

        public GenderTypeRepository(DBContext dBContext)
        {
            this.dBContext = dBContext;
        }
        public int Delete(int id)
        {
            var data = dBContext.GenderTypes.Find(id);
            dBContext.GenderTypes.Remove(data);
            var result = dBContext.SaveChanges();
            return result;
        }

        public List<GenderTypeViewModel> Get()
        {
            var data = dBContext.GenderTypes.Select(x => new GenderTypeViewModel
            {
                id = x.id,
                name = x.name
            }).ToList();

            return data;
        }

        public GenderTypeViewModel Get(int id)
        {
            var data = dBContext.GenderTypes.Where(x => x.id == id).Select(x => new GenderTypeViewModel
            {
                id = x.id,
                name = x.name,
            }).FirstOrDefault();
            return data;
        }

        public int Post(GenderTypeViewModel genderType)
        {
            dBContext.GenderTypes.Add(new GenderType
            {
                name = genderType.name
            });
            var result = dBContext.SaveChanges();
            return result;
        }

        public int Put(int id, GenderTypeViewModel genderType)
        {
            var data = dBContext.GenderTypes.Find(id);
            data.name = genderType.name;
            dBContext.GenderTypes.Update(data);
            var result = dBContext.SaveChanges();
            return result;
        }
    }
}
