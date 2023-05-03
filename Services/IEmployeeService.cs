using EmployeeAttendance.DAL.Entities;
using EmployeeAttendance.DTO;

namespace EmployeeAttendance.Services
{
    public interface IEmployeeService
    {
        Task Create (Employee employee);
        Task<Employee> GetById (Guid id);
        Task<PageResultDto<IEnumerable<Employee>>> GetAll (int page, int size); 
        Task Update (Guid id, Employee employee);
        Task Delete (Guid id);
    }
}