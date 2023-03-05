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
    public async Task<IActionResult> Create(Employee employee)
    {
        await _employeeService.Create(employee);
        return Ok();
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var employee = await _employeeService.GetById(id);
        return Ok(employee);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var allEmployees = await _employeeService.GetAll();
        return Ok(allEmployees);
    }

    [HttpPut]
    public async Task<IActionResult> Update(Guid id, Employee employee)
    {
        await _employeeService.Update(id, employee);
        return Ok();
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _employeeService.Delete(id);
        return Ok();
    }
}
