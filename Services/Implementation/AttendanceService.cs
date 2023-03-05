using EmployeeAttendance.DAL.Entities;
using EmployeeAttendance.DAL.Repositories;

namespace EmployeeAttendance.Services.Implementation
{
    public class AttendanceService : IAttendanceService
    {
        private readonly IEmployeeService _employeeService;
        private readonly IAttendanceRepository _attendanceRepository;
        private readonly ILogger<AttendanceService> _logger;

        public AttendanceService(IEmployeeService employeeService,
            IAttendanceRepository attendanceRepository,
            ILogger<AttendanceService> logger
            )
        {
            _employeeService = employeeService;
            _attendanceRepository = attendanceRepository;
            _logger = logger;
        }

        public async Task Create(Attendance attendance)
        {
            _logger.LogInformation($"Executing {nameof(Create)} method");

            await _employeeService.GetById(attendance.EmployeeId);
            await _attendanceRepository.Create(attendance);
            await _attendanceRepository.SaveChanges();
        }

        public async Task Delete(Guid id)
        {
            _logger.LogInformation($"Executing {nameof(Delete)} method");

            var attendanceToDlete = await GetById(id);
            _attendanceRepository.Delete(attendanceToDlete);
            await _attendanceRepository.SaveChanges();
        }

        public async Task<IEnumerable<Attendance>> GetAll()
        {
            _logger.LogInformation($"Executing {nameof(GetAll)} method");

            return await _attendanceRepository.GetAll();
        }

        public async Task<Attendance> GetById(Guid id)
        {
            _logger.LogInformation($"Executing {nameof(GetById)} method");

            var attendance = await _attendanceRepository.GetById(id);
            if (attendance == null)
            {
                var errorMessage = $"Attendance with id: {id} not found";
                _logger.LogError(errorMessage);
                throw new Exception(errorMessage);
            }

            return attendance;
        }

        public async Task Update(Guid id, Attendance attendance)
        {
            _logger.LogInformation($"Executing {nameof(Update)} method");

            var attendanceToUpdate = await GetById(id);

            attendanceToUpdate.CrossDateTime = attendance.CrossDateTime;
            attendanceToUpdate.AttendanceType = attendance.AttendanceType;

            await _attendanceRepository.SaveChanges();
        }
    }
}