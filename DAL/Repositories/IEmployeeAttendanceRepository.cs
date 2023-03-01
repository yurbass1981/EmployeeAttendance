using EmployeeAttendance.DAL.Entities;

namespace EmployeeAttendance.DAL.Repositories
{
    public interface IEmployeeAttendanceRepository
    {        
        void Create(Attendance attendance);
        Attendance? GetById(Guid id);
        IEnumerable<Attendance> GetAll();
        void Delete(Attendance attendance);
        void SaveChanges();
    }
}