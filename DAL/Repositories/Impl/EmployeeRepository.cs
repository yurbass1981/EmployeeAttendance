using EmployeeAttendance.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace EmployeeAttendance.DAL.Repositories.Impl
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly DataContext _dataContext;
        public EmployeeRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        
        public async Task Create(Employee employee)
        {
            // employee.Id = Guid.NewGuid();
            await _dataContext.Employees.AddAsync(employee);
        }

        public async Task Delete(Employee employeeToDelete)
        {
            _dataContext.Employees.Remove(employeeToDelete);
            await _dataContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Employee>> GetAll()
        {
            return await _dataContext.Employees
                .Include(e => e.EmployeeAttendance)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Employee?> GetById(Guid id)
        {
            return await _dataContext.Employees
                .Include(e => e.EmployeeAttendance)
                .FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task SaveChanges()
        {
           await _dataContext.SaveChangesAsync();
        }
    }
}
