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
    public class LeaveRequestController : ControllerBase
    {
        private readonly LeaveRequestRepository _leaveRequestRepository;

        public LeaveRequestController(LeaveRequestRepository leaveRequestRepository)
        {
            _leaveRequestRepository = leaveRequestRepository;
        }

        [HttpGet]
        public IActionResult GetDataService()
        {
            var data = _leaveRequestRepository.GetData();
            if (data.Count == 0)
                return Ok(new { statusCode = 200, data = "null" });

            return Ok(new { statusCode = 200, data = data });
        }

        [Route("{id}")]
        [HttpGet]
        public IActionResult GetDataService(int id)
        {
            var data = _leaveRequestRepository.GetData(id);
            if (data == null)
                return Ok(new { statusCode = 200, data = "null" });

            return Ok(new { statusCode = 200, data = data });
        }

        [Route("edit")]
        [HttpPut]
        public IActionResult EditDataService(LeaveRequestViewModel leaveRequestViewModel)
        {
            var result = _leaveRequestRepository.EditData(leaveRequestViewModel);
            if (result > 0)
                return Ok(new { statusCode = 200, message = "Success update data" });

            return BadRequest(new { statusCode = 400, message = "Failed update data" });
        }

        [Route("create")]
        [HttpPost]
        public IActionResult CreateDataService(LeaveRequestViewModel leaveRequestViewModel)
        {
            var result = _leaveRequestRepository.CreateData(leaveRequestViewModel);
            if (result > 0)
                return Ok(new { statusCode = 200, message = "Success create data" });

            return BadRequest(new { statusCode = 400, message = "Failed create data" });
        }

        [Route("delete/{id}")]
        [HttpDelete]
        public IActionResult DeleteDataService(int id)
        {
            var result = _leaveRequestRepository.DeleteData(id);
            if (result > 0)
                return Ok(new { statusCode = 200, message = "Success delete data" });

            return BadRequest(new { statusCode = 400, message = "Failed delete data" });
        }
    }
}
