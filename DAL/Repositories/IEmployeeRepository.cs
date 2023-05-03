using EmployeeAttendance.DAL.Entities;

namespace EmployeeAttendance.DAL.Repositories
{
    public interface IEmployeeRepository
    {
        Task Create(Employee employee);
        Task<Employee?> GetById(Guid id);
        Task<IEnumerable<Employee>> GetAll(int page, int size);
        Task<int> Count();
        Task Delete(Employee employee);
        Task SaveChanges();
    }
}