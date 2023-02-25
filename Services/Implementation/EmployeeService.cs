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
            _employeeRepository.SaveChanges();
        }

        public void Delete(Guid id)
        {
            _logger.LogInformation($"Executing {nameof(Delete)} method");

            var employeeToDelete = GetById(id);
            _employeeRepository.Delete(employeeToDelete);
            _employeeRepository.SaveChanges();
        }

        public IEnumerable<Employee> GetAll()
        {
            _logger.LogInformation($"Executing {nameof(GetAll)} method");

            return _employeeRepository.GetAll();
        }

        public Employee GetById(Guid id)
        {
            _logger.LogInformation($"Executing {nameof(GetById)} method");

            var employee = _employeeRepository.GetById(id);
            if (employee == null)
            {
                var errorMessage = $"Employee with id: {id} not found";
                _logger.LogError(errorMessage);
                throw new Exception(errorMessage);
            }

            return employee;
        }

        public void Update(Guid id, Employee employee)
        {
            _logger.LogInformation($"Executing {nameof(Update)} method");

            var employeeToUpdate = GetById(id);

            employeeToUpdate.Name = employee.Name;
            employeeToUpdate.LastName = employee.LastName;
            employeeToUpdate.Age = employee.Age;
            employeeToUpdate.HireDate = employee.HireDate;

            _employeeRepository.SaveChanges();
        }
    }
}
