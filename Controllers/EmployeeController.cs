using EmployeeAttendance.DAL.Entities;
using EmployeeAttendance.Services;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeAttendance.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EmployeeController : ControllerBase
{
    private readonly ILogger<EmployeeController> _logger;
    private readonly IEmployeeService _employeeService;

    public EmployeeController(ILogger<EmployeeController> logger, IEmployeeService employeeService)
    {
        _logger = logger;
        _employeeService = employeeService;
    }

    [HttpPost]
    public IActionResult Create(Employee employee)
    {
        _employeeService.Create(employee);
        return Ok();
    }

    [HttpGet("{id:guid}")]
    public IActionResult GetById(Guid id)
    {
        var employee = _employeeService.GetById(id);
        return Ok(employee);
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var allEmployees = _employeeService.GetAll();
        return Ok(allEmployees);
    }

    [HttpPut]
    public IActionResult Update(Guid id, Employee employee)
    {
        _employeeService.Update(id, employee);
        return Ok();
    }

    [HttpDelete]
    public IActionResult Delete(Guid id)
    {
        _employeeService.Delete(id);
        return Ok();
    }
}
