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
        public async Task<IActionResult> Create(Attendance attendance)
        {
            await _attendanceService.Create(attendance);
            return Ok();
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var attendance = await _attendanceService.GetById(id);
            return Ok(attendance);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var allAttendances = await _attendanceService.GetAll();
            return Ok(allAttendances);
        }

        [HttpPut]
        public async Task<IActionResult> Update(Guid id, Attendance attendance)
        {
            await _attendanceService.Update(id, attendance);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _attendanceService.Delete(id);
            return Ok();
        }


    }
}