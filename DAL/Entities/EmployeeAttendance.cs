using System.ComponentModel.DataAnnotations;

namespace EmployeeAttendance.DAL.Entities
{
    public class EmployeeAttendance
    {
        [Key]
        public Guid Id { get; set; }
        public Guid EmployeeId { get; set; }
        public DateTime ArrivalTime { get; set; }
        public DateTime LeavingTime { get; set; }
    }
}