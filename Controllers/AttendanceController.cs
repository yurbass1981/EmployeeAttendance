using EmployeeAttendance.DAL.Entities;
using EmployeeAttendance.Services;
using Microsoft.AspNetCore.Mvc;


namespace EmployeeAttendance.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttendanceController : ControllerBase
    {
        // private readonly IAttendanceService _attendanceService;

        // public AttendanceController(IAttendanceService attendanceService)
        // {
        //     _attendanceService = attendanceService;
        // }

        public IActionResult Create(Attendance attendance)
        {
            // _attendanceService.Create(attendance);
            return Ok();
        }


    }
}