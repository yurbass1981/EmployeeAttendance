using EmployeeAttendance.DAL.Entities;

namespace EmployeeAttendance.Services
{
    public interface IEmployeeService
    {
        Task Create (Employee employee);
        Task<Employee> GetById (Guid id);
        Task<IEnumerable<Employee>> GetAll ();
        Task Update (Guid id, Employee employee);
        Task Delete (Guid id);
    }
}