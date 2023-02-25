using EmployeeAttendance.DAL.Entities;

namespace EmployeeAttendance.DAL.Repositories
{
    public interface IEmployeeRepository
    {
        void Create(Employee employee);
        Employee? GetById(Guid id);
        IEnumerable<Employee> GetAll();
        void Delete(Employee employee);
        void SaveChanges();
    }
}