using EmployeeAttendance.DAL.Entities;

namespace EmployeeAttendance.DAL.Repositories.Impl
{
    public class AttendanceRepository : IAttendanceRepository
    {        
        private readonly DataContext _dataContext;

        public AttendanceRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public void Create(Attendance attendance)
        {
            attendance.Id = Guid.NewGuid();
            _dataContext.Attendances.Add(attendance);
        }

        public void Delete(Attendance attendanceToDelete)
        {
            _dataContext.Attendances.Remove(attendanceToDelete);
        }

        public IEnumerable<Attendance> GetAll()
        {
            return _dataContext.Attendances;
        }

        public Attendance? GetById(Guid id)
        {
            return _dataContext.Attendances.FirstOrDefault(a => a.Id == id);
        }

        public void SaveChanges()
        {
            _dataContext.SaveChanges();
        }
    }
}