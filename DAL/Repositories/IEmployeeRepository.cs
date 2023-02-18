using EmployeeAttendance.DAL.Entities;

namespace EmployeeAttendance.DAL.Repositories
{
    public interface IEmployeeRepository
    {
        void Create (Employee employee);
        Employee GetById (Guid id);
        IEnumerable<Employee> GetAll ();
        void Update (Guid id, Employee employee);
        void Delete (Guid id);
    }
}