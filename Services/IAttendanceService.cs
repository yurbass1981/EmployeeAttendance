using EmployeeAttendance.DAL.Entities;

namespace EmployeeAttendance.Services
{
    public interface IAttendanceService
    {
        void Create(Attendance attendance);
        Attendance GetById(Guid id);
        IEnumerable<Attendance> GetAll();
        void Update(Guid id, Attendance attendance);
        void Delete(Guid id);
    }
}