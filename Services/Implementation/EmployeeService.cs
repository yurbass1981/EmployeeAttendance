using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeAttendance.DAL.Entities;
using EmployeeAttendance.DAL.Repositories;

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
            _employeeRepository.Create(employee);
        }

        public void Delete(Guid id)
        {   
            _employeeRepository.Delete(id);
        }

        public IEnumerable<Employee> GetAll()
        {
            return _employeeRepository.GetAll();
        }

        public Employee GetById(Guid id)
        {
            return _employeeRepository.GetById(id);
        }

        public void Update(Guid id, Employee employee)
        {
            // _employeeRepository.Update(id, employee);

            var employeeToUpdate = GetById(id);

            if (id != null)
            {
                employeeToUpdate.Name = employee.Name;
                employeeToUpdate.LastName = employee.LastName;
                employeeToUpdate.Age = employee.Age;
                employeeToUpdate.HireDate = employee.HireDate;
            }
        }
    }
}