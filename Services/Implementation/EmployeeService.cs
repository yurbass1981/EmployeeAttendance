using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeAttendance.DAL.Entity;
using EmployeeAttendance.Repositories;

namespace EmployeeAttendance.Services.Implementation
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly ILogger<EmployeeService> _logger;

        public EmployeeService(ILogger<EmployeeService> logger, IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
            _logger = logger;
        }

        public void Create(Employee employee)
        {
            _logger.LogInformation($"Executing {nameof(Create)} method");
            throw new NotImplementedException();
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Employee> GetAll()
        {
            throw new NotImplementedException();
        }

        public void GetEmployee(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Update(Guid id, Employee employee)
        {
            throw new NotImplementedException();
        }
    }
}