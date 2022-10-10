using LeaveManagementWebAPI.Repositories.Datas;
using LeaveManagementWebAPI.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace LeaveManagementWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartementTypeController : ControllerBase
    {
        private readonly DepartmentTypeRepository _departmentTypeRepository;

        public DepartementTypeController(DepartmentTypeRepository departmentTypeRepository)
        {
            _departmentTypeRepository = departmentTypeRepository;
        }

        [HttpGet]
        public IActionResult GetDataService()
        {
            var data = _departmentTypeRepository.GetData();
            if (data.Count == 0)
                return Ok(new { statusCode = 200, data = "null" });

            return Ok(new { statusCode = 200, data = data });
        }

        [Route("{id}")]
        [HttpGet]
        public IActionResult GetDataService(int id)
        {
            var data = _departmentTypeRepository.GetData(id);
            if (data == null)
                return Ok(new { statusCode = 200, data = "null" });

            return Ok(new { statusCode = 200, data = data });
        }

        [Route("edit")]
        [HttpPut]
        public IActionResult EditDataService(DepartmentTypeViewModel departmentTypeViewModel)
        {
            var result = _departmentTypeRepository.EditData(departmentTypeViewModel);
            if (result > 0)
                return Ok(new { statusCode = 200, message = "Success update data" });

            return BadRequest(new { statusCode = 400, message = "Failed update data" });
        }

        [Route("create")]
        [HttpPost]
        public IActionResult CreateDataService(DepartmentTypeViewModel departmentTypeViewModel)
        {
            var result = _departmentTypeRepository.CreateData(departmentTypeViewModel);
            if (result > 0)
                return Ok(new { statusCode = 200, message = "Success create data" });

            return BadRequest(new { statusCode = 400, message = "Failed create data" });
        }

        [Route("delete/{id}")]
        [HttpDelete]
        public IActionResult DeleteDataService(int id)
        {
            var result = _departmentTypeRepository.DeleteData(id);
            if (result > 0)
                return Ok(new { statusCode = 200, message = "Success delete data" });

            return BadRequest(new { statusCode = 400, message = "Failed delete data" });
        }
    }
}
