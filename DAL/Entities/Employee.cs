using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace EmployeeAttendance.DAL.Entities
{
    public class Employee
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public DateTime HireDate { get; set; }

        public List<Attendance> EmployeeAttendance { get; set; } = new List<Attendance>();
    }
}