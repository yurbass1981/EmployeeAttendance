using EmployeeAttendance.DAL.Entities;
using EmployeeAttendance.Services;
using Microsoft.AspNetCore.Mvc;


namespace EmployeeAttendance.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttendanceController : ControllerBase
    {
        private readonly ILogger<EmployeeController> _logger;
        private readonly IAttendanceService _attendanceService;
        public AttendanceController(ILogger<EmployeeController> logger, IAttendanceService attendanceService)
        {
            _logger = logger;
            _attendanceService = attendanceService;
        }

        [HttpPost]
        public IActionResult Create(Attendance attendance)
        {
            _attendanceService.Create(attendance);
            return Ok();
        }

        [HttpGet("{id:guid}")]
        public IActionResult GetById(Guid id)
        {
            var attendance = _attendanceService.GetById(id);
            return Ok(attendance);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var allAttendances = _attendanceService.GetAll();
            return Ok(allAttendances);
        }

        [HttpPut]
        public IActionResult Update(Guid id, Attendance attendance)
        {
            _attendanceService.Update(id, attendance);
            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete(Guid id)
        {
            _attendanceService.Delete(id);
            return Ok();
        }


    }
}