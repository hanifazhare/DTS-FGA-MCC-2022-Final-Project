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
    public class LeaveTypeController : ControllerBase
    {
        private readonly LeaveTypeRepository _leaveTypeRepository;

        public LeaveTypeController(LeaveTypeRepository leaveTypeRepository)
        {
            _leaveTypeRepository = leaveTypeRepository;
        }

        [HttpGet]
        public IActionResult GetDataService()
        {
            var data = _leaveTypeRepository.GetData();
            if (data.Count == 0)
                return Ok(new { statusCode = 200, data = "null" });

            return Ok(new { statusCode = 200, data = data });
        }

        [Route("{id}")]
        [HttpGet]
        public IActionResult GetDataService(int id)
        {
            var data = _leaveTypeRepository.GetData(id);
            if (data == null)
                return Ok(new { statusCode = 200, data = "null" });

            return Ok(new { statusCode = 200, data = data });
        }

        [Route("edit")]
        [HttpPut]
        public IActionResult EditDataService(LeaveTypeViewModel leaveTypeViewModel)
        {
            var result = _leaveTypeRepository.EditData(leaveTypeViewModel);
            if (result > 0)
                return Ok(new { statusCode = 200, message = "Success update data" });

            return BadRequest(new { statusCode = 400, message = "Failed update data" });
        }

        [Route("create")]
        [HttpPost]
        public IActionResult CreateDataService(LeaveTypeViewModel leaveTypeViewModel)
        {
            var result = _leaveTypeRepository.CreateData(leaveTypeViewModel);
            if (result > 0)
                return Ok(new { statusCode = 200, message = "Success create data" });

            return BadRequest(new { statusCode = 400, message = "Failed create data" });
        }

        [Route("delete/{id}")]
        [HttpDelete]
        public IActionResult DeleteDataService(int id)
        {
            var result = _leaveTypeRepository.DeleteData(id);
            if (result > 0)
                return Ok(new { statusCode = 200, message = "Success delete data" });

            return BadRequest(new { statusCode = 400, message = "Failed delete data" });
        }
    }
}
