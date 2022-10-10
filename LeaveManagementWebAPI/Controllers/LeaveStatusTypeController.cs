using LeaveManagementWebAPI.Contexts;
using LeaveManagementWebAPI.Models;
using LeaveManagementWebAPI.Repositories.Datas;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LeaveManagementWebAPI.Models.ViewModels;
using Microsoft.AspNetCore.Cors;

namespace LeaveManagementWebAPI.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("AllowAllOrigins")]
    [ApiController]
    public class LeaveStatusTypeController : ControllerBase
    {
        private readonly LeaveStatusTypeRepository _leaveStatusTypeRepository;

        public LeaveStatusTypeController(LeaveStatusTypeRepository leaveStatusTypeRepository)
        {
            _leaveStatusTypeRepository = leaveStatusTypeRepository;
        }

        [HttpGet]
        public IActionResult GetDataService()
        {
            var data = _leaveStatusTypeRepository.GetData();
            if (data.Count == 0)
                return Ok(new { statusCode = 200, data = "null" });

            return Ok(new { statusCode = 200, data = data });
        }

        [Route("{id}")]
        [HttpGet]
        public IActionResult GetDataService(int id)
        {
            var data = _leaveStatusTypeRepository.GetData(id);
            if (data == null)
                return Ok(new { statusCode = 200, data = "null" });

            return Ok(new { statusCode = 200, data = data });
        }
    }
}
