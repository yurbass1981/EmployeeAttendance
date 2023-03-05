using EmployeeAttendance.DAL.Entities;

namespace EmployeeAttendance.DAL.Repositories
{
    public interface IAttendanceRepository
    {        
        Task Create(Attendance attendance);
        Task<Attendance?> GetById(Guid id);
        Task<IEnumerable<Attendance>> GetAll();
        void Delete(Attendance attendance);
        Task SaveChanges();
    }
}