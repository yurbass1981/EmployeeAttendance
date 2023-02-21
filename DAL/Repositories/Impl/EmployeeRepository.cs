using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeAttendance.DAL.Entities;

namespace EmployeeAttendance.DAL.Repositories.Impl
{
    public class EmployeeRepository : IEmployeeRepository
    {
        //Temporal MOCK
        private static readonly List<Employee> _employees = new();

        public void Create(Employee employee)
        {
            employee.Id = Guid.NewGuid();
            _employees.Add(employee);
        }

        public void Delete(Employee employeeToDelete)
        {
            _employees.Remove(employeeToDelete);
        }

        public IEnumerable<Employee> GetAll()
        {
            return _employees;
        }

        public Employee? GetById(Guid id)
        {
            return _employees.FirstOrDefault(e => e.Id == id);
        }
    }
}
