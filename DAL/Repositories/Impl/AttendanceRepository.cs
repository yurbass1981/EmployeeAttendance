using EmployeeAttendance.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace EmployeeAttendance.DAL.Repositories.Impl
{
    public class AttendanceRepository : IAttendanceRepository
    {
        private readonly DataContext _dataContext;

        public AttendanceRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task Create(Attendance attendance)
        {
            // attendance.Id = Guid.NewGuid();
            await _dataContext.Attendances.AddAsync(attendance);
        }

        public async Task Delete(Attendance attendanceToDelete)
        {
            _dataContext.Attendances.Remove(attendanceToDelete);
            await _dataContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Attendance>> GetAll()
        {
            return await _dataContext.Attendances
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Attendance?> GetById(Guid id)
        {
            return await _dataContext.Attendances.FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task SaveChanges()
        {
            await _dataContext.SaveChangesAsync();
        }
    }
}