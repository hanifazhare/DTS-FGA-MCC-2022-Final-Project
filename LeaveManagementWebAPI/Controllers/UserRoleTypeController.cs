using LeaveManagementWebAPI.Models.ViewModels;
using LeaveManagementWebAPI.Repositories.Datas;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeaveManagementWebAPI.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("AllowAllOrigins")]
    [ApiController]
    public class UserRoleTypeController : ControllerBase
    {
        private readonly UserRoleTypeRepository _userRoleTypeRepository;

        public UserRoleTypeController(UserRoleTypeRepository userRoleTypeRepository)
        {
            _userRoleTypeRepository = userRoleTypeRepository;
        }

        [HttpGet]
        public IActionResult GetDataService()
        {
            var data = _userRoleTypeRepository.GetData();
            if (data.Count == 0)
                return Ok(new { statusCode = 200, data = "null" });

            return Ok(new { statusCode = 200, data = data });
        }

        [Route("{id}")]
        [HttpGet]
        public IActionResult GetDataService(int id)
        {
            var data = _userRoleTypeRepository.GetData(id);
            if (data == null)
                return Ok(new { statusCode = 200, data = "null" });

            return Ok(new { statusCode = 200, data = data });
        }
    }
}
