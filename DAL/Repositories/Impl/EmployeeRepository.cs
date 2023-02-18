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

        public void Delete(Guid id)
        {
            var employeeToDelete = _employees.FirstOrDefault(e => e.Id == id);

            if (employeeToDelete == null)
            {
                throw new Exception($"Employee with id: {id} not found.");
            }

            _employees.Remove(employeeToDelete);
        }

        public IEnumerable<Employee> GetAll()
        {
            return _employees;
        }

        public Employee GetById(Guid id)
        {
            return _employees.FirstOrDefault(e => e.Id == id);
        }

        public void Update(Guid id, Employee employee)
        {
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