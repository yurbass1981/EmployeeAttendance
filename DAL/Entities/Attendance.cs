using System.ComponentModel.DataAnnotations;
using EmployeeAttendance.Enums;

namespace EmployeeAttendance.DAL.Entities
{
    public class Attendance
    {
        public Guid Id { get; set; }
        public DateTime CrossDateTime { get; set; }
        public AttendanceType AttendanceType { get; set; }
        
        public Guid EmployeeId { get; set; }
        public Employee? Employee { get; set; }
    }
}