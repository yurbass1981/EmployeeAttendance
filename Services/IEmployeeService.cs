using EmployeeAttendance.DAL.Entities;

namespace EmployeeAttendance.Services
{
    public interface IEmployeeService
    {
        Task Create (Employee employee);
        Task<Employee> GetById (Guid id);
        Task<IEnumerable<Employee>> GetAll (int page, int size); //create class PageResult<T> {int Total, T Data}
        Task Update (Guid id, Employee employee);
        Task Delete (Guid id);
    }
}