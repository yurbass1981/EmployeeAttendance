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
        //Temporal MOCK
        // private static readonly List<Employee> _employees = new();

        public void Create(Employee employee)
        {
            employee.Id = Guid.NewGuid();
            _dataContext.Add(employee);
            _dataContext.SaveChanges();
        }

        public void Delete(Employee employeeToDelete)
        {
            _dataContext.Remove(employeeToDelete);
            _dataContext.SaveChanges();
        }

        public IEnumerable<Employee> GetAll()
        {
            var employees = GetAll();
            return employees;
        }

        public Employee? GetById(Guid id)
        {
            var employee = GetById(id);
            return employee;
        }
    }
}
