using EmployeeAttendance.DAL.Entities;
using EmployeeAttendance.Services;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeAttendance.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EmployeeController : ControllerBase
{
    private readonly IEmployeeService _employeeService;
    private readonly ILogger<EmployeeController> _logger;

    public EmployeeController(ILogger<EmployeeController> logger, IEmployeeService employeeService)
    {
        _logger = logger;
        _employeeService = employeeService;
    }

   
    public IActionResult Create(Employee employee)
    {
        _employeeService.Create(employee);
        return Ok();
    }

    [HttpGet]
    public IActionResult GetAll()
    {        
        var allEmployees = _employeeService.GetAll();
        return Ok(allEmployees);
    }

    public IActionResult Update(Guid id, Employee employee)
    {
        _employeeService.Update(id, employee);
        return Ok();
    }

    public IActionResult Delete(Guid id)
    {
        _employeeService.Delete(id);
        return Ok();
    }
}
