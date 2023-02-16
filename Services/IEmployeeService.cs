using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeAttendance.DAL.Entity;

namespace EmployeeAttendance.Services
{
    public interface IEmployeeService
    {
        void Create (Employee employee);
        void GetEmployee (Guid id);
        IEnumerable<Employee> GetAll ();
        void Update (Guid id, Employee employee);
        void Delete (Guid id);
    }
}