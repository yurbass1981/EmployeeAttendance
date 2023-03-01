using EmployeeAttendance.DAL.Entities;
using EmployeeAttendance.DAL.Repositories;

namespace EmployeeAttendance.Services.Implementation
{
    public class AttendanceService : IAttendanceService
    {
        
        private readonly IAttendanceRepository _attendanceRepository;
        private readonly ILogger<AttendanceService> _logger;

        public AttendanceService(IAttendanceRepository attendanceRepository, ILogger<AttendanceService> logger)
        {
            _attendanceRepository = attendanceRepository;
            _logger = logger;
        }
        public void Create(Attendance attendance)
        {
            _logger.LogInformation($"Executing {nameof(Create)} method");
            _attendanceRepository.Create(attendance);
            _attendanceRepository.SaveChanges();
        }

        public void Delete(Guid id)
        {
            _logger.LogInformation($"Executing {nameof(Delete)} method");

            var attendanceToDlete = GetById(id);
            _attendanceRepository.Delete(attendanceToDlete);
            _attendanceRepository.SaveChanges();
        }

        public IEnumerable<Attendance> GetAll()
        {            
            _logger.LogInformation($"Executing {nameof(GetAll)} method");

            return _attendanceRepository.GetAll();
        }

        public Attendance GetById(Guid id)
        {            
            _logger.LogInformation($"Executing {nameof(GetById)} method");

            var attendance = _attendanceRepository.GetById(id);
            if (attendance == null)
            {
                var errorMessage = $"Attendance with id: {id} not found";
                _logger.LogError(errorMessage);
                throw new Exception(errorMessage);
            }

            return attendance;
        }

        public void Update(Guid id, Attendance attendance)
        {            
            _logger.LogInformation($"Executing {nameof(Update)} method");

            var attendanceToUpdate = GetById(id);

            attendanceToUpdate.CrossDateTime = attendance.CrossDateTime;            
            attendanceToUpdate.AttendanceType = attendance.AttendanceType;            

            _attendanceRepository.SaveChanges();
        }
    }
}