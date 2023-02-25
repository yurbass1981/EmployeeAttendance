using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeAttendance.DAL.Entities;

namespace EmployeeAttendance.DAL.Repositories.Impl
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly DataContext _dataContext;
        public EmployeeRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        
        public void Create(Employee employee)
        {
            employee.Id = Guid.NewGuid();
            _dataContext.Employees.Add(employee);
        }

        public void Delete(Employee employeeToDelete)
        {
            _dataContext.Employees.Remove(employeeToDelete);
        }

        public IEnumerable<Employee> GetAll()
        {
            return _dataContext.Employees;
        }

        public Employee? GetById(Guid id)
        {
            return _dataContext.Employees.FirstOrDefault(e => e.Id == id);
        }

        public void SaveChanges()
        {
           _dataContext.SaveChanges();
        }
    }
}
