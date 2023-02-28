using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using EmployeeAttendance.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace EmployeeAttendance.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeAttendanceController : Controller
    {
        private readonly ILogger<EmployeeAttendanceController> _logger;
        private readonly IEmployeeAttendanceService _employeeAttendanceService;

        public EmployeeAttendanceController(ILogger<EmployeeAttendanceController> logger, 
                                        IEmployeeAttendanceService employeeAttendanceService)
        {
            _logger = logger;
            _employeeAttendanceService = employeeAttendanceService;
        }

        public IActionResult Create(EmployeeAttendance employeeAttendance)
    {
        _employeeAttendanceService.Create(employeeAttendance);
        return Ok();
    }

       
    }
}