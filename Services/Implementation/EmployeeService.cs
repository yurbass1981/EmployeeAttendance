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

        public async Task Create(Employee employee)
        {
            _logger.LogInformation($"Executing {nameof(Create)} method");
            
            await _employeeRepository.Create(employee);
            await _employeeRepository.SaveChanges();
        }

        public async Task Delete(Guid id)
        {
            _logger.LogInformation($"Executing {nameof(Delete)} method");

            var employeeToDelete = await GetById(id);
            _employeeRepository.Delete(employeeToDelete);
            await _employeeRepository.SaveChanges();
        }

        public async Task<IEnumerable<Employee>> GetAll()
        {
            _logger.LogInformation($"Executing {nameof(GetAll)} method");

            return await _employeeRepository.GetAll();
        }

        public async Task<Employee> GetById(Guid id)
        {
            _logger.LogInformation($"Executing {nameof(GetById)} method");

            var employee = await _employeeRepository.GetById(id);
            if (employee == null)
            {
                var errorMessage = $"Employee with id: {id} not found";
                _logger.LogError(errorMessage);
                throw new Exception(errorMessage);
            }

            return employee;
        }

        public async Task Update(Guid id, Employee employee)
        {
            _logger.LogInformation($"Executing {nameof(Update)} method");

            var employeeToUpdate = await GetById(id);

            employeeToUpdate.Name = employee.Name;
            employeeToUpdate.LastName = employee.LastName;
            employeeToUpdate.Age = employee.Age;
            employeeToUpdate.HireDate = employee.HireDate;

            await _employeeRepository.SaveChanges();
        }
    }
}
