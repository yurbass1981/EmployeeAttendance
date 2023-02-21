using System.ComponentModel.DataAnnotations;

namespace EmployeeAttendance.DAL.Entities
{
    public class Employee
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; } 

        [Required]
        [MaxLength(100)]
        public string LastName { get; set; }

        [Required]
        public int Age { get; set; }

        [Required]
        public DateTime HireDate { get; set; }
    }
}