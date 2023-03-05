using EmployeeAttendance.DAL.Entities;

namespace EmployeeAttendance.Services
{
    public interface IAttendanceService
    {
        Task Create(Attendance attendance);
        Task<Attendance> GetById(Guid id);
        Task<IEnumerable<Attendance>> GetAll();
        Task Update(Guid id, Attendance attendance);
        Task Delete(Guid id);
    }
}